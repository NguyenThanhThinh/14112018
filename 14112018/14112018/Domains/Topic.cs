using System;

namespace _14112018.Domains
{
    public class Topic : Entity<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsPublished { get; set; }
        public DateTime PublishedDate { get; set; } = DateTime.Now;
        
    }
}
