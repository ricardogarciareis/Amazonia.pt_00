using Amazonia.DAL.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Amazonia.ConsoleAPP
{
    public static class ExemploJSON
    {
        public static void Carregar()
        {
            var conteudo = System.IO.File.ReadAllText(@"\\ASUSN750J\Compartilhar\Amazonia.PT\Amazonia.pt\Amazonia.pt-main\exemploJSON.json");
            //Newtonsoft

            Rootobject m = JsonConvert.DeserializeObject<Rootobject>(conteudo);
            m.glossary.title = "Novo Titulo do Documento";


            var jsonNovo = JsonConvert.SerializeObject(m);
            var path = @"\\ASUSN750J\Compartilhar\Amazonia.PT\Amazonia.pt\Amazonia.pt-main\exemploJSONNOVO.json";
            System.IO.File.WriteAllText(path, jsonNovo);
        }

        public static void CriarArquivoNovo()
        {
            var l = new List<Cliente>
            {
                new Cliente { DataNascimento = new DateTime(2021, 01, 01), Nome = "Joao" },
                new Cliente
                {
                    DataNascimento = new DateTime(2021, 01, 01),
                    Nome = "Maria",
                    Morada = new Morada
                    {
                        CodigoPostal = "2830280",
                        Distrito = "Setubal",
                        Endereco = "Rua das Casas"
                    }
                },
                new Cliente { DataNascimento = new DateTime(2021, 01, 01), Nome = "Marta" }
            };


            var jsonNovo = JsonConvert.SerializeObject(l);
            var path = @"\\ASUSN750J\Compartilhar\Amazonia.PT\Amazonia.pt\Amazonia.pt-main\exemploJSONNOVO.json";
            System.IO.File.WriteAllText(path, jsonNovo);
        }






        public class Rootobject
        {
            public Glossary glossary { get; set; }
        }

        public class Glossary
        {
            public string title { get; set; }
            public Glossdiv GlossDiv { get; set; }
        }

        public class Glossdiv
        {
            public string title { get; set; }
            public Glosslist GlossList { get; set; }
        }

        public class Glosslist
        {
            public Glossentry GlossEntry { get; set; }
        }

        public class Glossentry
        {
            public string ID { get; set; }
            public string SortAs { get; set; }
            public string GlossTerm { get; set; }
            public string Acronym { get; set; }
            public string Abbrev { get; set; }
            public Glossdef GlossDef { get; set; }
            public string GlossSee { get; set; }
        }

        public class Glossdef
        {
            public string para { get; set; }
            public string[] GlossSeeAlso { get; set; }
        }

    }
}
