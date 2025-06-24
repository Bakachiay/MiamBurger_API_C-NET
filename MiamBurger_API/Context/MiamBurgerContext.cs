using MiamBurger.Model;
using MiamBurger_API.Model;
using Microsoft.EntityFrameworkCore;

namespace MiamBurger_API.Context
{
    public class MiamBurgerContext : DbContext
    {
        //Je reçois les options de connexion à la DB
        public MiamBurgerContext(DbContextOptions<MiamBurgerContext> options) : base(options)
        {
            
        }

        //TODO : C'est ici que je fais le lien entre mes classes et les tables de la DB
        public DbSet<Burger> Burgers => Set<Burger>();
        DbSet<Order> Orders => Set<Order>();
        DbSet<OrderLine> OrderLines => Set<OrderLine>();

        public DbSet<User> Users => Set<User>();

    }
}
