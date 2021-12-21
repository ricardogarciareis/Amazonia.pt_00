<Query Kind="Program">
  <Namespace>System.Globalization</Namespace>
</Query>

void Main()
{
	var culturas = new List<NumberFormatInfo>
	{
		new CultureInfo("pt-BR", false).NumberFormat,
		new CultureInfo("pt-PT", false).NumberFormat,
		new CultureInfo("en-US", false).NumberFormat,
		new CultureInfo("en-GB", false).NumberFormat,
	};
	
	var valor = -1234.123M;
	foreach (var nfi in culturas)
	{
		Console.WriteLine(valor.ToString("c", nfi));	
	}
}