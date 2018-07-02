using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaSapatos.Model
{
    public class ItemPedido
    {
        [Key]
        public int id { get; set; }

        public int Quantidade { get; set; } = 0;

        public double Preco { get; set; } = 0;

       
        public Sapatos Sapatos { get; set; }

    }
}
