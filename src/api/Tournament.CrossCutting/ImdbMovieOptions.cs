namespace Tournament.CrossCutting
{
    public class ImdbMovieOptions
    {
        public string BaseEndpoint { get; set; }
        public string Key { get; set; }
        public string DefaultPoster { get; set; }
        public bool Enabled { get; set; }

        public string FindByIdEndPoint(string id) =>
            string.Format(BaseEndpoint, id, Key);
    }
}