using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos.Model
{
    public class Pedido
    {
        public int id { get; set; }

        public ItemPedido ItemPedido { get; set; }

        public Cliente Cliente { get; set; }
    }
}
