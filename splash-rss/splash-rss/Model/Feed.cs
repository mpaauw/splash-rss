namespace splash_rss.Model
{
    public class Feed
    {
        public Feed() { }

        public Feed(string name, string endpoint)
        {
            this.name = name;
            this.endpoint = endpoint;
        }

        public string name { get; set; }

        public string endpoint { get; set; }
    }
}
