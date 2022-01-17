using System;
using System.IO;

namespace BackupsExtra
{
    public class Logger
    {
        private FileStream _fileStream;
        public Logger(string filename)
        {
            _fileStream = new FileStream(filename, FileMode.Append);
        }

        public bool Timecode { get; set; }
        public void Write(string message)
        {
            if (Timecode)
                _fileStream.Write(System.Text.Encoding.Default.GetBytes(DateTime.Now + ": " + message));
            _fileStream.Write(System.Text.Encoding.Default.GetBytes(message));
        }
    }
}
