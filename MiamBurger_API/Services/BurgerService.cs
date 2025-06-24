using MiamBurger.Model;
using MiamBurger_API.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MiamBurger_API.Services
{
    public class BurgerService
    {
        MiamBurgerContext _context;

        public BurgerService(MiamBurgerContext context)
        {
            _context = context;
        }

        public List<Burger> GetAll() => _context.Burgers.ToList();

        public Burger GetById(int id)
        {
            //Je vais aller chercher dans la liste burgers celui qui a le bon id
            //Linq => fonctionnalités C# qui permettent de faire des requètes sur des collections
            Burger burgerToReturn = _context.Burgers.FirstOrDefault(b => b.Number == id);

            return burgerToReturn;
        }

        public Burger GetByName(string name)
        {
            //Je vais aller chercher dans la liste burgers celui qui a le bon id
            //Linq => fonctionnalités C# qui permettent de faire des requètes sur des collections
            Burger burgerToReturn = _context.Burgers.FirstOrDefault(b => b.Name == name);

            return burgerToReturn;
        }

        public List<Burger> GetMinus10()
        {
            List<Burger> burgersToReturn = _context.Burgers.Where(b => b.Price < 10).ToList();

            return burgersToReturn;
        }

        public  List<Burger> GetNoPlaceHolder()
        {
            List<Burger> burgersToReturn = _context.Burgers.Where(b => b.Image != "https://brownbagkelowna.com/img/placeholders/burger_placeholder.png").ToList();

            return burgersToReturn;
        }

        public  void Create(Burger newburger)
        {
            _context.Burgers.Add(newburger);

            try
            {
                _context.SaveChanges();
            }
            catch(DbUpdateException ex)
            {
                throw new DbUpdateException("Duplicata à la création d'un burger (attention de vérifier que le number n'est pas entré manuellement + attention pas de nom en double).");
            }
        }

        public  void Delete(int id)
        {

            _context.Burgers.Remove(GetById(id));

            _context.SaveChanges();
        }

        internal  void Update(Burger updatedBurger)
        {
            Burger? burgerToUpdate = _context.Burgers.FirstOrDefault(b => b.Number == updatedBurger.Number);



            if (burgerToUpdate is null)
                throw new InvalidOperationException("Le burger à modifier n'existe pas/plus !");


            burgerToUpdate.Name = updatedBurger.Name;
            burgerToUpdate.Price = updatedBurger.Price;
            burgerToUpdate.Description = updatedBurger.Description;
            burgerToUpdate.Image = updatedBurger.Image;

            _context.SaveChanges();
        }
    }
}
