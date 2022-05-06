using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Entities
{
    public class PrintOrders
    {
        public int OrderID { get; set; }
        public bool isBlack { get; set; }
        public bool isHighQuality { get; set; }
        public bool isBorderless { get; set; }
        public string Size { get; set; }
        public bool? isDoubleSide { get; set; }
        public string? PaperType { get; set; }
        public string OrderStatus { get; set; }
        public int Price { get; set; }
        public DateTime OrderedDateTime { get; set; }
        public int whoOrderedID { get; set; }
       // public virtual CustomerAccounts? whoOrdered { get; set; }
    }
}
