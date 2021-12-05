using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatUP.Models
{
    public class Cart_model
    {
        public int CItemID { get; set; }

        public string CItem_Name { get; set; }

        public float CItem_Price { get; set; }

        public int CQuantity { get; set; }

    }
}
