﻿using System.ComponentModel.DataAnnotations;

namespace PSTodos.Application.ViewModels
{
    public class PerfilViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public bool Ativo { get; set; }
    }
}
