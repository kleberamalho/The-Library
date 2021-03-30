using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CadastroEmprestimoLivros
    {
        [Key]
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string DataRetirada { get; set; }
        public string DataEntrega { get; set; }
    }
}

