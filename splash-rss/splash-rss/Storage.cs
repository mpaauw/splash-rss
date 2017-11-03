using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;

namespace splash_rss
{
    public class Storage : IStorage
    {
        private List<Feed> feeds;

        private JavaScriptSerializer serializer;

        private const string dataFileName = "data.json";

        public Storage()
        {
            feeds = new List<Feed>();
            serializer = new JavaScriptSerializer();
            LoadStorage();
        }

        public void LoadStorage()
        {
            using(StreamReader reader = new StreamReader(dataFileName))
            {
                string json = reader.ReadToEnd();
                feeds = serializer.Deserialize<List<Feed>>(json);
            }
        }

        public List<Feed> GetStorage()
        {
            return feeds;
        }

        public void AddStorageItem(Feed item)
        {
            throw new NotImplementedException();
        }
    }
}
