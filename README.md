# pronuncify - automate incrementally producing word pronunciation recordings for Wiktionary through Wikimedia Commons
##Goal
Make it easy to quickly record batches of word pronunciations in [Ogg files](https://en.wikipedia.org/wiki/Ogg) suitable for upload to [Wikimedia Commons](https://commons.wikimedia.org) on Windows (Visa or newer) machines.

It does so using a .NET app, showing the user a word at a time and recording a 5-second file.  Then there is a brief pause, and the next word is shown and recorded.  At the end of a run, you have cute new Ogg files ready for upload, and named according to the standard in the [Pronunciation page](https://commons.wikimedia.org/wiki/Category:Pronunciation) on Commons.

The word list is loaded from a plaintext file.  The user can save the remaining words for a later session using the "save word list" button (usually one would overwrite the loaded word-file; otherwise, the next time to tool is run it would load the same unchanged word-file, and would try re-recording words already covered).

Currently, the app only handles ingesting word lists and recording batches of word pronunciations.  The resultant Ogg files are just deposited in a specified directory, and it is up to the user to upload them to Commons appropriately (and to keep track of what's been uploaded already; ideally move it away from the output directory once uploaded).  In the future, I may implement OAuth-based authentication so that the app would also be able to upload the files on your behalf.

##Prerequisites
* .NET 4.x Framework
* the [Sox audio processor package](http://sourceforge.net/projects/sox/?source=typ_redirect)

To report issues or contribute to the code, see http://github.com/abartov/pronuncify.net

## License
The code is in the public domain.  See the LICENSE file for details.
