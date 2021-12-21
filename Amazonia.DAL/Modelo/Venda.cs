using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    [Table("Orders")]
    public class Venda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public Cliente Cliente { get; set; }
        public List<Livro> Livros { get; set; }
    }
}
