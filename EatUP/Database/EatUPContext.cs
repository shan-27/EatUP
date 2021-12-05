using EatUP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatUP.Database
{
    public class EatUPContext : DbContext
    {

        public DbSet<Customer> customerList { get; set; }

        public DbSet<Admin> AdminList { get; set; }

        public DbSet<Food_Item> fooditemList { get; set; }

        public DbSet<Order> OrderList { get; set; }

        public DbSet<Main_Order_Details> Main_Order_DetailsList { get; set; }

        public DbSet<CS_form> CSform_list { get; set; }
    }
}
