using MiamBurger.Model;
using MiamBurger_API.Context;
using MiamBurger_API.Model;
using Microsoft.EntityFrameworkCore;

namespace MiamBurger_API.Services
{
    public class UserService
    {
        MiamBurgerContext _MiamBurgerdb;

        public UserService(MiamBurgerContext context)
        {
            _MiamBurgerdb = context;
        }


        //Create
        public void Create(User newUser)
        {
            _MiamBurgerdb.Users.Add(newUser);
            _MiamBurgerdb.SaveChanges();
        }


        //Read
        public List<User> ReadAll() => _MiamBurgerdb.Users.ToList();


        //Read
        public User Read(int id)
        {
            //Je vais aller chercher dans la liste users celui qui a le bon id
            //Linq => fonctionnalités C# qui permettent de faire des requètes sur des collections
            User userToReturn = _MiamBurgerdb.Users.FirstOrDefault(u => u.Number == id);

            return userToReturn;
        }

        //Read
        public List<User> ReadByName(string name)
        {
            //Je vais aller chercher dans la liste users celui qui a le bon id
            //Linq => fonctionnalités C# qui permettent de faire des requètes sur des collections
            List<User> usersToReturn = _MiamBurgerdb.Users.Where(u => u.Name == name).ToList();

            return usersToReturn;
        }
    


        //Update
        internal void Update(User updatedUser) //Je recois la nouvelle version
        {
            //Je récupère l'ancienne version'
            User? oldUser = _MiamBurgerdb.Users.FirstOrDefault(u => u.Number == updatedUser.Number);



            if (updatedUser is null)
                throw new InvalidOperationException("Le user à modifier n'existe pas/plus !");


            oldUser.Name = updatedUser.Name;
            oldUser.Firstname = updatedUser.Name;

            _MiamBurgerdb.SaveChanges();
        }

        //Delete
        public void Delete(int id)
        {

            _MiamBurgerdb.Users.Remove(Read(id));

            _MiamBurgerdb.SaveChanges();
        }
    }
}
