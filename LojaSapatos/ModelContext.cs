using LojaSapatos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos
{
    class ModelContext:DbContext
    {
        public ModelContext() : base("name=ModelContext")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Sapatos> Sapatos { get; set; }
    }
}
