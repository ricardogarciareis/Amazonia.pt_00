using System.ComponentModel.DataAnnotations;

namespace Amazonia.WebApi.Dto
{
    public class ClienteDto
    {
        [Required]
        public string Nome { get; set; }        
        public string NumeroIdentificacaoFiscal { get; set; }
    }
}
