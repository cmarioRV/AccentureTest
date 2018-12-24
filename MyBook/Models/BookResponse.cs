using System;
using System.Collections.Generic;

namespace MyBook.Models
{
    public class BookResponse
    {
        public int Error { get; set; }
        public int Total { get; set; }
        public int Page { get; set; }
        public IList<Item> Books { get; set; }
    }
}
