using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaSapatos.Model;

namespace LojaSapatos
{
    class FacadeClientes
    {
        public IList<Cliente> ObterCliente()
        {
            ModelContext ctx = new ModelContext();
            return ctx.Clientes.ToList();
        }
    }
}
