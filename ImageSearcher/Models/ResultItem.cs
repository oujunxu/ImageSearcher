using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSearcher.Models
{
    public class ResultItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Snippet { get; set; }
        public string Source { get; set; }
        public string Query { get; set; }
        public int Index { get; set; }
        public string Image { get; set;}
    }
}