using System;

namespace RazorPagesCV.Models
{
    public class CuriculumVitae
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }
}
