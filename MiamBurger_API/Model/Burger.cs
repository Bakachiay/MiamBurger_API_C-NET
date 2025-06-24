using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiamBurger.Model
{
    [Index(nameof(Name), IsUnique = true)]
    public class Burger
    {
        [Key]
        public int Number { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [DefaultValue("https://brownbagkelowna.com/img/placeholders/burger_placeholder.png")]
        public string Image { get; set; }

        [Required]
        [Range(1,100)]
        public double Price { get; set; }

        public string Description { get; set; }


    }
}
