namespace WebApplication1
{
    public class Incident
    {
        public string Value { get; set; }
        public string DisplayName { get; set; }
        public bool Auto { get; set; }
        public bool Orderable { get; set; }
        public bool Searchable { get; set; }
        public List<string> Operators { get; set; }
        public List<string> Types { get; set; }
    }
}
