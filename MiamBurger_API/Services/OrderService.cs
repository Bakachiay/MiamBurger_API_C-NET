using MiamBurger.Model;
using Microsoft.AspNetCore.Mvc;

namespace MiamBurger_API.Services
{
    public static class OrderService
    {
        static List<Order> orders = new List<Order>
            {
                new Order { Number = 1, DTOrder = DateTime.Now },
                new Order { Number = 2, DTOrder = DateTime.Now.AddDays(-1) },
                new Order { Number = 3, DTOrder = DateTime.Now.AddDays(-2) },
                new Order { Number = 4, DTOrder = new DateTime(2025, 6, 1, 14, 30, 0) },
                new Order { Number = 5, DTOrder = new DateTime(2025, 6, 2, 9, 0, 0) },
                new Order { Number = 6, DTOrder = new DateTime(2025, 1, 1, 9, 0, 0) },
                new Order { Number = 7, DTOrder = new DateTime(2024, 6, 2, 9, 0, 0) }
            };


        public static List<Order> GetOrders() => orders;

        public static Order GetById(int id)
        {
            Order orderToReturn = orders.FirstOrDefault(o => o.Number == id);

            return orderToReturn;
        }


        public static List<Order> GetBeforeFebruary()
        {
            List<Order> ordersToReturn = orders.Where(o => o.DTOrder < new DateTime(2025, 2, 1, 0, 0, 0)).ToList();

            return ordersToReturn;
        }

        public static List<Order> GetLast7Days()
        {
            List<Order> ordersToReturn = orders.Where(o => o.DTOrder > DateTime.Now.AddDays(-7) && o.DTOrder <= DateTime.Now).ToList();

            return ordersToReturn;
        }

        //Post
        public static void Create(Order order)
        {
            orders.Add(order);
        }

        internal static void Delete(int id)
        {
            Order order = GetById(id);

            if (order is null)
                throw new InvalidOperationException("L'order que vous souhaitez supprimer est introuvable...");
            
            orders.Remove(order);
        }

        internal static void Update(Order updatedOrder)
        {
            Order? orderToUpdate = orders.FirstOrDefault(b => b.Number == updatedOrder.Number);



            if (orderToUpdate is null)
                throw new InvalidOperationException("L'order à modifier n'existe pas/plus !");


            orderToUpdate.DTOrder = updatedOrder.DTOrder;

        }

        //Put 

    }
}
