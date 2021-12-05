using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatUP.Models
{
    public class Food_Item
    {
        public int Food_ItemID { get; set; }

        public string Item_Name { get; set; }

        public float Item_Price { get; set; }

        public string Item_Discription { get; set; }

        public string Item_Category { get; set; }

        public string Iten_ImageURL { get; set; }

        public int Item_Status { get; set; }

        public byte[] Item_Imagecode { get; set; }

    }
}
