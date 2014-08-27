using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity; 
using DoctorFlow.Entities;
using DoctorFlow.Entities.Context;
using DoctorFlow.Entities.Models;

namespace DoctorFlow.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DoctorFlowContext())
            {
                Console.Write("Ingrese un Rol: ");
                var name = Console.ReadLine();

                var rol = new Rol { Name = name, Status = true };
                db.Roles.Add(rol);
                db.SaveChanges();

                var query = from r in db.Roles
                            orderby r.Name
                            select r;

                Console.WriteLine("Todos los roles:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey(); 
            }
        }
    }
}
