using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public class Cliente : Entidade
    {
        [Required]
        [MinLength(5), MaxLength(255)]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [MinLength(32), MaxLength(32)]
        public string Password { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }     
        
        [Required]
        [MinLength(9),MaxLength(9)]
        public string NumeroIdentificacaoFiscal { get; set; }

        [NotMapped]
        public int Idade => DateTime.Now.Year - DataNascimento.Year;

        public virtual Morada Morada { get; set; }
    }
}
