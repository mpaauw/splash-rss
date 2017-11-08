using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss.Interface
{
    public class ConsoleManager : IConsoleManager
    {
        public void Navigate(List<SyndicationItem> data, int cursorPosition)
        {
            PrintData(data);
            Console.SetCursorPosition(0, 0);
            int currentPosition = -1;
            if (data.Count > 0)
            {
                currentPosition = 0;
            }
            ConsoleKeyInfo keyInfo;
            while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape) 
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:   
                        if(currentPosition < data.Count - 1)
                        {
                            currentPosition += 1;
                        }
                        Console.SetCursorPosition(0, currentPosition);
                        break;
                    case ConsoleKey.UpArrow:
                        if(currentPosition > 0)
                        {
                            currentPosition -= 1;
                        }
                        Console.SetCursorPosition(0, currentPosition);
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.WriteLine("You have chosen topic: " + data[currentPosition].Title.Text);
                        break;
                }
            }
        }

        public void PrintData(List<SyndicationItem> data)
        {
            var evenBackground = ConsoleColor.Black;
            var evenForeground = ConsoleColor.Green;
            var oddBackground = ConsoleColor.Green;
            var oddForeground = ConsoleColor.Black;

            if(data.Count < 1)
            {
                Console.WriteLine("No data to display.");
            }
            for(int i = 0; i < data.Count; i++)
            {
                Console.BackgroundColor = (i % 2 == 0) ? evenBackground : oddBackground;
                Console.ForegroundColor = (i % 2 == 0) ? evenForeground : oddForeground;
                Console.WriteLine(data[i].Title.Text);
            }
            Console.WriteLine("\n(Press ESC to quit.)");
        }
    }
}
