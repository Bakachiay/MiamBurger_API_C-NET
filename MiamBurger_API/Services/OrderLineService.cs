using MiamBurger.Model;
using Microsoft.AspNetCore.Mvc;

namespace MiamBurger_API.Services
{
    public static class OrderLineService
    {
        public static List<OrderLine> orderLines = new List<OrderLine>
            {
                // Order 1 (today)
                new OrderLine { Number = 1, Quantity = 2, NbBurger = 1, NbOrder = 1 },
                new OrderLine { Number = 2, Quantity = 1, NbBurger = 2, NbOrder = 1 },

                // Order 2 (yesterday)
                new OrderLine { Number = 3, Quantity = 1, NbBurger = 3, NbOrder = 2 },
                new OrderLine { Number = 4, Quantity = 1, NbBurger = 1, NbOrder = 2 },

                // Order 3 (two days ago)
                new OrderLine { Number = 5, Quantity = 3, NbBurger = 2, NbOrder = 3 },

                // Order 4 (2025-06-01)
                new OrderLine { Number = 6, Quantity = 1, NbBurger = 4, NbOrder = 4 },
                new OrderLine { Number = 7, Quantity = 2, NbBurger = 5, NbOrder = 4 },

                // Order 5 (2025-06-02)
                new OrderLine { Number = 8, Quantity = 1, NbBurger = 6, NbOrder = 5 },

                // Order 6 (2025-01-01)
                new OrderLine { Number = 9, Quantity = 2, NbBurger = 3, NbOrder = 6 },

                // Order 7 (2024-06-02)
                new OrderLine { Number = 10, Quantity = 1, NbBurger = 1, NbOrder = 7 },
                new OrderLine { Number = 11, Quantity = 1, NbBurger = 2, NbOrder = 7 }
            };

        public static List<OrderLine> GetAll() => orderLines;


        //Un Get qui permet de récupérer toutes les lignes liées à une commande
        public static List<OrderLine> GetByOrder(int id)
        {
            List<OrderLine> orderLinesToReturn = orderLines.Where(ol => ol.NbOrder == id).ToList();
            //TODO : à tester
            /*.Where(ol => ol.NbOrder == id)
            .Include(ol => ol.burger)
            .Include(ol => ol.order)
            .ToList();*/
            return orderLinesToReturn;
        }


        //Un Get qui permet de récupérer toutes les lignes liées à un burger par l'id
        public static List<OrderLine> GetByBurger(int id)
        {
            List<OrderLine> orderLinesToReturn = orderLines.Where(ol => ol.NbBurger == id).ToList();

            return orderLinesToReturn;
        }

        internal static void Delete(int id)
        {
            OrderLine orderLineToDelete = GetById(id);

            if (orderLineToDelete is null)
                throw new InvalidOperationException("La ligne que vous voulez supprimer est introuvable...");
            
            orderLines.Remove(orderLineToDelete);
        }

        internal static OrderLine GetById(int id)
        {
            return orderLines.FirstOrDefault(ol => ol.Number == id);
        }

        internal static void Update(OrderLine updatedOrderLine)
        {
            OrderLine? orderLineToUpdate = orderLines.FirstOrDefault(ol => ol.Number == updatedOrderLine.Number);



            if (orderLineToUpdate is null)
                throw new InvalidOperationException("L'orderline à modifier n'existe pas/plus !");


            orderLineToUpdate.Quantity = updatedOrderLine.Quantity;
        }

        internal static void Create(OrderLine orderLine)
        {
            orderLines.Add(orderLine);
        }
    }
}
