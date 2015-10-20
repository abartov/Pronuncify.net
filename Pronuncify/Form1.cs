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
        private IWaveIn waveIn;
        private WaveFileWriter writer;
        String outputFilename;
        String outputFolder;

        public Form1()
        {
            InitializeComponent();
            Font font = new Font(this.labelWord.Font.FontFamily, 50);
            this.labelWord.Font = font; // default
            this.labelWord.Text = "[word here]";
            this.outputFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            textOutputFolder.Text = this.outputFolder;
            textLang.Text = "XX";
            if (Environment.OSVersion.Version.Major >= 6)
            {
                LoadWasapiDevicesCombo();
            }
        }

        private void LoadWasapiDevicesCombo()
        {
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumerateAudioEndPoints(DataFlow.Capture, DeviceState.Active).ToList();

            comboWasapiDevices.DataSource = devices;
            comboWasapiDevices.DisplayMember = "FriendlyName";
            MessageBox.Show("Can't find any input devices!  Recording won't work...");
            btnStart.Enabled = false;
            btnNext.Enabled = false;
        }

        private void record()
        {
            // start recording
            String word = labelWord.Text;
            Cleanup(); // WaveIn is still unreliable in some circumstances to being reused

            if (waveIn == null)
            {
                waveIn = CreateWaveInDevice();
            }
            // Forcibly turn on the microphone (some programs (Skype) turn it off).
            var device = (MMDevice)comboWasapiDevices.SelectedItem;
            device.AudioEndpointVolume.Mute = false;

            outputFilename = textLang.Text + "-" + word + ".wav";
            writer = new WaveFileWriter(Path.Combine(outputFolder, outputFilename), waveIn.WaveFormat);
            textLog.AppendText("Recording...");
            waveIn.StartRecording();
            SetControlStates(true);

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

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                String file = openFileDialog1.FileName;
                textWordFile.Text = file;
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
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SetControlStates(true);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SetControlStates(false);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
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
                textLog.AppendText("done.  Saved to: " + this.outputFilename+"\n");
                progressBar1.Value = 0;
                if (e.Exception != null)
                {
                    MessageBox.Show(String.Format("A problem was encountered during recording {0}",
                                                  e.Exception.Message));
                }
                SetControlStates(false);
            }
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
            Debug.WriteLine("StopRecording");
            if (waveIn != null) waveIn.StopRecording();
        }

        private void OnButtonStopRecordingClick(object sender, EventArgs e)
        {
            StopRecording();
        }

        private void SetControlStates(bool isRecording)
        {
            btnStart.Enabled = !isRecording;
            btnNext.Enabled = !isRecording;
            btnStop.Enabled = isRecording;
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
                textOutputFolder.Text = this.outputFolder;
            }
        }

    }
}
