using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class JqlData
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
