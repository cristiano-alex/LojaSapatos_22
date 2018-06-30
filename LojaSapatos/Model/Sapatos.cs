using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSapatos.Model
{
    public class Sapatos
    {
        [Key]
        public int SP_Id { get; set; }
        public string SP_Nome { get; set; }

        public bool SP_Cadarco { get; set; }

        public string SP_Material { get; set; }

        public string SP_Cor { get; set; }

        public decimal SP_Preco { get; set; }

        
    }
}
