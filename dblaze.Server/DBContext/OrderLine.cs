using System;
using System.Collections.Generic;

namespace dblaze.Shared.DBContext
{
    public partial class OrderLine
    {
        public short LineNum { get; set; }
        public int? OrderId { get; set; }
        public string BookId { get; set; }
        public int? Quantity { get; set; }
    }
}
