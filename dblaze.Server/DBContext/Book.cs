using System;
using System.Collections.Generic;

namespace dblaze.Shared.DBContext
{
    public partial class Book
    {
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? CategoryId { get; set; }
        public decimal? Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
