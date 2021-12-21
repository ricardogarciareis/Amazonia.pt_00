using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public abstract class Entidade
    {
        //[Key] // Desnecessario já que vamos optar por usar o mecanismo de Convenção (CoC)
        //[Required] // Desnecessario já que vamos optar por usar o mecanismo de Convenção (CoC) 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }

        public override string ToString() => $"Nome: {Nome} => Identificador: {Id}";
    }
}
