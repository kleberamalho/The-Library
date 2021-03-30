﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CadastroAlunos
    {
        [Key]
        public int Id { get; set; }
        public string RA { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string DataNascimento { get; set; }

    }
}
