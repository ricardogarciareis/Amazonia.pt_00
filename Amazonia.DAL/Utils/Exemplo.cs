using System.Configuration;

namespace Amazonia.DAL.Utils
{
    public static class Exemplo
    {
        public static string ObterValorDoConfig(string chave)
        {
            var valorDaChave = ConfigurationManager.AppSettings[chave];
            return valorDaChave;
        }
    }
}
