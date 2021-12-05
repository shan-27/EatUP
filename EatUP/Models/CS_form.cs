using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatUP.Models
{
    public class CS_form
    {
        public int CS_formID { get; set; }

        public string CS_form_Name { get; set; }

        [Required]
        public string CS_form_Email { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string CS_form_Subject { get; set; }

        [MinLength(20)]
        [MaxLength(500)]
        public string CS_form_Message { get; set; }

        public int CS_ID { get; set; }

        public ICollection<Customer> Customers { get; set; }

    
    }
}
