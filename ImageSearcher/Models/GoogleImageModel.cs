using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageSearcher.Models
{
    public class GoogleImageModel
    {
        public GoogleImageModel(string url, string text)
        {
            imgUrl = url;
            imageText = text;
        }

        public string imgUrl { get; set; }
        public string imageText { get; set; }
    }
}