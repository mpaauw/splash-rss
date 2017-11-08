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
            if(data.Count < 1)
            {
                Console.WriteLine("No data to display.");
            }
            foreach(SyndicationItem item in data)
            {
                Console.WriteLine(item.Title.Text);
            }
            Console.WriteLine("\n(Press ESC to quit.)");
        }
    }
}
