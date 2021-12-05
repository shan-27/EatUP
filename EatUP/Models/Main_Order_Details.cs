using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatUP.Models
{
    public class Main_Order_Details
    {
        [Key]
        public int Main_Order_DetailsID { get; set; }

        public int Rand_Order_id { get; set; }

        public int _Customer_iD { get; set; }

        public string Order_Date { get; set; }

        public string Order_Time { get; set; }

        public string TotalBill { get; set; }

    }
}
