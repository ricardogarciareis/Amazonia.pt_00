
namespace Amazonia.DAL.Infraestrutura
 {
    public class ImpressoraPapel : IImpressora
    {
        public void Imprimir()
        {
            System.Console.WriteLine("Usando Impressora em papel");            
            //Aqui entrariam as regras para gerar um PDF....
            
        }
    }
}
