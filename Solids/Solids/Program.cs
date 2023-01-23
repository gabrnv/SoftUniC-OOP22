using System;

namespace Stream_Progress_Info
{
    public class Program
    {
        static void Main()
        {
            Music music = new Music("Jake", "Bread", "musicFile01", 50, 300);
            StreamProgressInfo info = new StreamProgressInfo(music);
            Console.WriteLine(info.CalculateCurrentPercent());
        }
    }
}
