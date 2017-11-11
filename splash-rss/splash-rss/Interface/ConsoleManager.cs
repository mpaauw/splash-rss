using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using splash_rss.Data;

namespace splash_rss.Interface
{
    public class ConsoleManager : IConsoleManager
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int HIDE = 0;
        private const int MAXIMIZE = 3;
        private const int MINIMIZE = 6;
        private const int RESTORE = 9;

        public ConsoleManager()
        {
            MaximizeConsoleWindow();
        }

        public void NavigateTopics(List<SyndicationItem> data, int cursorPosition)
        {
            PrintTopics(data);
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
                        SyndicationItem datum = data[currentPosition];
                        Console.Clear();
                        Console.WriteLine("You have chosen topic: " + datum.Title.Text);
                        PrintTopicData(datum);
                        break;
                }
            }
        }

        public void PrintTopics(List<SyndicationItem> data)
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

        public void PrintTopicData(SyndicationItem datum)
        {
            HTMLHandler handler = new HTMLHandler();
            foreach(SyndicationLink link in datum.Links)
            {
                var doc = handler.LoadHTMLDocumentFromWeb(link.Uri.AbsoluteUri);
                string topicData = handler.ParseHTMLDocument(doc);
                Console.WriteLine(topicData);
            }
        }

        public void MaximizeConsoleWindow()
        {
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
        }
    }
}
