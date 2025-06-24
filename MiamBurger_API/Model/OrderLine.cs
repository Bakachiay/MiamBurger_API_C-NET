using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiamBurger.Model
{
    public class OrderLine
    {
        [Key]
        public int Number { get; set; }

        [Required]
        [Range(1,100)]
        [DefaultValue(1)]
        public int Quantity { get; set; }

        
        public int NbBurger { get; set; }
        [ForeignKey(nameof(NbBurger))]
        public Burger burger { get; set; }


        
        public int NbOrder { get; set; }
        [ForeignKey(nameof(NbOrder))]
        public Order order { get; set; }
    }
}
