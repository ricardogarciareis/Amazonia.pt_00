using System;
using System.IO;

namespace Amazonia.DAL.Infraestrutura
{
    public class AmazoniaException : Exception
    {
        public AmazoniaException(string tipoErro)
        {
            var path = @"c:\temp\";
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);                
            }

            var log = $"{DateTime.Now} :: {tipoErro}";
            File.WriteAllText($@"{path}log.txt", log);
        }
    }
}
