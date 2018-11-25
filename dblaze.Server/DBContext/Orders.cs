using System;
using System.Collections.Generic;

namespace dblaze.Shared.DBContext
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public Guid? UserId { get; set; }
        public DateTime? Date { get; set; }
        public string CardNo { get; set; }
        public string SecurityNo { get; set; }
        public string CardType { get; set; }
        public decimal? TotalCost { get; set; }
    }
}
