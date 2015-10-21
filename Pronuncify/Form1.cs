using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using System.Diagnostics;

namespace Pronuncify
{
    public partial class Form1 : Form
    {
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        private IWaveIn waveIn;
        private WaveFileWriter writer;
        String outputFilename;
        String outputFolder;
        bool batchMode = false;

        public Form1()
        {
            InitializeComponent();
            Font font = new Font(this.labelWord.Font.FontFamily, 50);
            this.labelWord.Font = font; // default
            this.labelWord.Text = "[word here]";
            textLang.Text = Properties.Settings.Default.lang;
            textSox.Text = Properties.Settings.Default.sox;
            textOutputFolder.Text = Properties.Settings.Default.outputFolder;
            textWordFile.Text = Properties.Settings.Default.wordFile;
            if (textWordFile.Text != "")
                loadWords(textWordFile.Text);
            
            this.outputFolder = textOutputFolder.Text;
            //this.outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            if (Environment.OSVersion.Version.Major >= 6)
            {
                LoadWasapiDevicesCombo();
            }
            myTimer.Tick += new EventHandler(timer_Tick);
            myTimer.Interval = (1000) * 4; // 4 seconds
        }
        void timer_Tick(object sender, EventArgs e)
        {
            myTimer.Stop();
            myTimer.Enabled = false;
            nextword();
        }

        private void LoadWasapiDevicesCombo()
        {
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            comboWasapiDevices.DataSource = devices;
            comboWasapiDevices.DisplayMember = "FriendlyName";
            if (devices.Count == 0)
            { 
                MessageBox.Show("Can't find any input devices!  Recording won't work...");
                btnStart.Enabled = false;
                btnNext.Enabled = false;
            }
        }

        private void record()
        {
			if (textLang.Text == "") {
				MessageBox.Show ("Please set the language code (e.g. 'en', 'ar')");
                listWords.Items.Insert(0, labelWord.Text); // re-insert the dequeued word
            }
            else if (textSox.Text == "")
            {
                MessageBox.Show("Please install the Sox package -- http://sourceforge.net/projects/sox/?source=typ_redirect -- and navigate to it using the sox.exe button");
                listWords.Items.Insert(0, labelWord.Text); // re-insert the dequeued word
            }
            else {
				// start recording
				String word = labelWord.Text;
				Cleanup (); // WaveIn is still unreliable in some circumstances to being reused

				if (waveIn == null) {
					waveIn = CreateWaveInDevice ();
				}
				// Forcibly turn on the microphone (some programs (Skype) turn it off).
				var device = (MMDevice)comboWasapiDevices.SelectedItem;
				device.AudioEndpointVolume.Mute = false;

                outputFilename = textLang.Text + "-" + cleanFileName(word);
                
				writer = new WaveFileWriter (Path.Combine (outputFolder, outputFilename + ".wav"), waveIn.WaveFormat);
				waveIn.StartRecording ();
                textLog.AppendText("Recording...");
                panel1.BackColor = Color.Green;
                labelOnAir.Text = "ON AIR";
				SetControlStates (true);
			}
        }
        private void fontButton_Click(object sender, EventArgs e)
        {
            // Show the dialog.
            DialogResult result = fontDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                // Get Font.
                Font font = fontDialog1.Font;
                // Set TextBox properties.
                //this.textWord.Text = string.Format("Font is­: {0}", font.Name);
                this.labelWord.Font = font;
            }
        }

        private void loadWords(string file)
        {
            try
            {
                string[] lines = File.ReadAllLines(file);
                foreach (string line in lines)
                {
                    listWords.Items.Add(line);
                }
                    
                Console.WriteLine(lines.Count());
            }
            catch (IOException)
            {
            }
        }
        private void btnLoadWords_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                String file = openFileDialog1.FileName;
                Properties.Settings.Default.wordFile = file;
                Properties.Settings.Default.Save();
                textWordFile.Text = file;
                loadWords(file);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            batchMode = true;
            SetControlStates(true);
            nextword();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetControlStates(false);
            batchMode = false;
        }
        public void nextword() {
            if (listWords.Items.Count > 0)
            {
                String word = listWords.Items[0].ToString();
                listWords.Items.RemoveAt(0);
                labelWord.Text = word;
                record();
            }
            else
            {
                MessageBox.Show("No more words.  Load some more on the right.");
            }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            nextword();
        }
        void OnRecordingPanelDisposed(object sender, EventArgs e)
        {
            Cleanup();
        }

        private void OnButtonStartRecordingClick(object sender, EventArgs e)
        {
            record();
        }

        private IWaveIn CreateWaveInDevice()
        {
            IWaveIn newWaveIn;
            newWaveIn = new WaveIn();
            newWaveIn.WaveFormat = new WaveFormat(8000, 1);
            newWaveIn.DataAvailable += OnDataAvailable;
            newWaveIn.RecordingStopped += OnRecordingStopped;
            return newWaveIn;
        }

        void OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new EventHandler<StoppedEventArgs>(OnRecordingStopped), sender, e);
            }
            else
            {
                FinalizeWaveFile();
                textLog.AppendText("recorded, now converting to Ogg Vorbis... ");
                oggify();
                textLog.AppendText("done.  Saved to: " + this.outputFilename+".ogg\n");
                progressBar1.Value = 0;
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                                  e.Exception.Message));
                }
                SetControlStates(false);
            }
        }
        private static string cleanFileName(string filename)
        {            
            string file = filename;

            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                file = file.Replace(c, '_');
            }                                 
            return file;
        }   
        private void Cleanup()
        {
            if (waveIn != null)
            {
                waveIn.Dispose();
                waveIn = null;
            }
            FinalizeWaveFile();
        }

        private void FinalizeWaveFile()
        {
            if (writer != null)
            {
                writer.Dispose();
                writer = null;
            }
        }

        void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (InvokeRequired)
            {
                //Debug.WriteLine("Data Available");
                BeginInvoke(new EventHandler<WaveInEventArgs>(OnDataAvailable), sender, e);
            }
            else
            {
                //Debug.WriteLine("Flushing Data Available");
                writer.Write(e.Buffer, 0, e.BytesRecorded);
                int secondsRecorded = (int)(writer.Length / writer.WaveFormat.AverageBytesPerSecond);
                if (secondsRecorded >= 5)
                {
                    StopRecording();
                }
                else
                {
                    progressBar1.Value = secondsRecorded;
                }
            }
        }

        void StopRecording()
        {
            if (waveIn != null) waveIn.StopRecording();
            panel1.BackColor = Color.Red;
            if (batchMode)
                labelOnAir.Text = "ready?";
            else
                labelOnAir.Text = "off air";
        }

        private void OnButtonStopRecordingClick(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void SetControlStates(bool isRecording)
        {
            btnStart.Enabled = !isRecording && !batchMode;
            btnNext.Enabled = !isRecording && !batchMode; 
            btnStop.Enabled = isRecording && batchMode;
        }

        private void OnOpenFolderClick(object sender, EventArgs e)
        {
            Process.Start(outputFolder);
        }

        private void btnOutputFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            // See if OK was pressed.
            if (result == DialogResult.OK)
            {
                this.outputFolder = folderBrowserDialog1.SelectedPath;
                Properties.Settings.Default.outputFolder = this.outputFolder;
                Properties.Settings.Default.Save();
                textOutputFolder.Text = this.outputFolder;
            }
        }
        private void oggify()
        {
            string fullpath = Path.Combine(outputFolder, outputFilename);
            Process proc = Process.Start(textSox.Text, "\"" + fullpath + ".wav \" \"" + fullpath + ".ogg\" norm vad -p .25 reverse vad -p .25 reverse");
            proc.WaitForExit();
            File.Delete(fullpath + ".wav");
            if (batchMode && listWords.Items.Count > 0)
            {
                myTimer.Enabled = true;
                myTimer.Start();
            } else
            {
                batchMode = false;
                labelOnAir.Text = "off air";
            }
        }
        private void textLang_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.lang = textLang.Text;
            Properties.Settings.Default.Save();
        }

        private void linkHomepage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/abartov/pronuncify.net");
        }

        private void btnFindSox_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                String file = openFileDialog2.FileName;
                Properties.Settings.Default.sox = file;
                Properties.Settings.Default.Save();
                textSox.Text = file;
            }

        }

    }
}
