<Query Kind="Statements">
  <Connection>
    <ID>87f48b56-22d2-43e7-8714-9972b6fbb9bb</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Amazonia.pt</Database>
  </Connection>
</Query>

var clientesQueMoramPorto = from c in Clientes
							join m in Moradas
							on c.Morada.Id equals m.Id
							where m.Localidade == "Porto"
							select new
							{
								c.Nome,
								m.Endereco
							};
														
	clientesQueMoramPorto.Dump();						