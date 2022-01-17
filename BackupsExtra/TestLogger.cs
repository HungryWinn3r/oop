using System;

namespace BackupsExtra
{
    public class TestLogger
    {
        private string log = string.Empty;
        public bool Timecode { get; set; }
        public void Write(string message)
        {
            if (Timecode)
            {
                log = log.Insert(log.Length, $"{DateTime.Now} {message}");
            }
            else
            {
                log = log.Insert(log.Length, $"{message}");
            }
        }
    }
}