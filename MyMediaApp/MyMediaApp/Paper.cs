using System.Collections.Generic;

namespace MyMediaApp
{
    public enum PaperType
    {
        Poem, Prose, Essay, Manuscript, Custom
    }
    internal class Paper
    {
        public int Id { get; set; }
        public PaperType type { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
    }
}