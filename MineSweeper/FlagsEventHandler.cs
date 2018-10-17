using System;

namespace MineSweeper
{
    public class FlagsEventHandler : EventArgs
    {
        public int FlagsCount { get; set; }
    }
}
