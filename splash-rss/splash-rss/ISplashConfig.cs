using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss
{
    interface ISplashConfig
    {
        Dictionary<string, string> GetCommands();

        void AddCommand(string key, string value);

        void RemoveCommand(string key);
    }
}
