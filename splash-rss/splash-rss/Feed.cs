using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace splash_rss
{
    public class Feed
    {
        public Feed(string name, string endpoint)
        {
            this.name = name;
            this.endpoint = endpoint;
        }

        public string name { get; set; }

        public string endpoint { get; set; }
    }
}
