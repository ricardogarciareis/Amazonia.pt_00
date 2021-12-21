using System.ComponentModel.DataAnnotations;

namespace Amazonia.DAL.Modelo
{
    public class Morada : Entidade
    {
        [Required]
        public string Distrito { get; set; }
        [Required]
        public string Localidade { get; set; }
        [Required]
        public string Endereco { get; set; }
        
        [Required]
        [MinLength(7),MaxLength(7)]
        public string CodigoPostal { get; set; }
    }
}
