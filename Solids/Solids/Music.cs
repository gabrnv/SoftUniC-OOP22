using System;
using System.Collections.Generic;
using System.Text;

namespace Stream_Progress_Info
{
    public class Music : File
    {
        private string artist;
        private string album;

        public Music(string artist, string album, string name, int length, int bytesSent) : base(name, length, bytesSent)
        {
            this.artist = artist;
            this.album = album;
            this.Length = length;
            this.BytesSent = bytesSent;
        }
    }
}
