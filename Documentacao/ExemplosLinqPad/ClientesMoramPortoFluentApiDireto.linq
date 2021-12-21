<Query Kind="Statements">
  <Connection>
    <ID>87f48b56-22d2-43e7-8714-9972b6fbb9bb</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>(localdb)\MSSQLLocalDB</Server>
    <Database>Amazonia.pt</Database>
  </Connection>
</Query>

Clientes.Where(x => x.Morada.Localidade == "Porto").ToList().Dump();