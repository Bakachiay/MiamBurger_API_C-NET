using System.ComponentModel.DataAnnotations;

namespace MiamBurger_API.Model
{
    public class User
    {
        [Key]
        public int Number { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Firstname { get; set; }
    }
}
