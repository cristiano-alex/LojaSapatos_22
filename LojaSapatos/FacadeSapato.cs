using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaSapatos.Model;

namespace LojaSapatos
{
    class FacadeSapato
    {
        public IList<Sapatos> ObterSapatos()
        {
            ModelContext ctx = new ModelContext();
            return ctx.Sapatos.ToList();
        }
    }
}
