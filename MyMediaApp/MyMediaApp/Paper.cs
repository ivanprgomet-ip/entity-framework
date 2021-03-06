﻿using System.Collections.Generic;

namespace MyMediaApp
{
    public enum PaperType
    {
        Poem, Prose, Essay, Manuscript, Custom
    }
    internal class Paper
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PaperType Type { get; set; }
        public string Author { get; set; }
    }
}