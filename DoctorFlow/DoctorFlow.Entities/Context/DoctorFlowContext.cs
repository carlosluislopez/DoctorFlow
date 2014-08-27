using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; 
using DoctorFlow.Entities;
using DoctorFlow.Entities.Models;

namespace DoctorFlow.Entities.Context
{
    public class DoctorFlowContext : DbContext
    {
        public DbSet<User> Users {set; get;}
        public DbSet<Rol> Roles { set; get; }
    }
}
