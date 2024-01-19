namespace PaperLess.DataAccess.Entities{

    public class TagDAL {
        public long Id { get; set; }
        public string? Slug { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
        public string? Match { get; set; }
        public long MatchingAlgorithm { get; set; }
        public bool IsInsensitive { get; set; }
        public bool IsInboxTag { get; set; }
        public long DocumentCount { get; set; }
    }

}