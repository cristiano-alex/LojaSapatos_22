using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LojaSapatos.Model
{
    public class Cliente
    {
        [Key]
        public int Id_Cliente { get; set; }

        public string Cl_Nome { get; set; }

        public string Cl_Endereco { get; set; }

        public int CL_Numero { get; set; }

        public string CL_Cidade { get; set; }

        public string CL_Estado { get; set; }

        public string CL_Cep { get; set; }


        public string CL_Telefone { get; set; }

        public string CL_CPF { get; set; }

        public string CL_RZ { get; set; }

        public string CL_Genero { get; set; }

        public string CL_Email { get; set; }

        public DateTime CL_DataNasc { get; set; }

        
    }
}
