using MiamBurger_API.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiamBurger.Model
{
    public class Order
    {
        [Key]
        public int Number { get; set; }

        [Required]
        public DateTime DTOrder { get; set; }


        //Ajouter une foreign key
        public int NbUser { get; set; }
        [ForeignKey(nameof(NbUser))]
        public User user { get; set; }

    }
}
