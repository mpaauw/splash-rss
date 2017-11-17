using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;
using splash_rss.Model;

namespace splash_rss.Data
{
    public class Storage : IStorage
    {
        private List<Feed> feeds;

        private Validator validator;

        private JavaScriptSerializer serializer;

        private const string dataFileName = "data.json";

        public Storage()
        {
            feeds = new List<Feed>();
            validator = new Validator();
            serializer = new JavaScriptSerializer();
            LoadStorage();
        }

        ~Storage()
        {
            SaveStorage();
        }

        public void LoadStorage()
        {
            using(StreamReader reader = new StreamReader(dataFileName))
            {
                string json = reader.ReadToEnd();
                feeds = serializer.Deserialize<List<Feed>>(json);
            }
        }

        public void SaveStorage()
        {
            using(StreamWriter writer = new StreamWriter(dataFileName))
            {
                string data = serializer.Serialize(feeds);
                writer.Write(data);
            }
        }

        public List<Feed> GetStorage()
        {
            return feeds;
        }

        public void AddStorageItem(Feed item)
        {
            if(validator.ValidateFeed(item))
            {
                feeds.Add(item);
            }
        }
    }
}
