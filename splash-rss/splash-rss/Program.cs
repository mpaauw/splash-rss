using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss
{
    class Splash
    {
        static void Main(string[] args)
        {
            SplashConfig config = new SplashConfig();
            var commands = config.GetCommands();

            // invalid add:
            config.AddCommand("foo", "bar");

            // valid add:
            config.AddCommand("south", "park");

            // invalid delete:
            config.RemoveCommand("dog");

            // valid delete:
            config.RemoveCommand("foo");

        }
    }
}
