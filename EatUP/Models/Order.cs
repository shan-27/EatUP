using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatUP.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public int _DetailsID { get; set; }

        public string Itemname { get; set; }

        public int Item_id { get; set; }

        public int Quantity { get; set; }

        public virtual Main_Order_Details Order_Details { get; set; }
    }
}
