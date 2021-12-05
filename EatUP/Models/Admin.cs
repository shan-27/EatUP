using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatUP.Models
{
    public class Admin
    {
        [Key]
        public string Admin_username { get; set; }

        public string Admin_password { get; set; }



    }
}
