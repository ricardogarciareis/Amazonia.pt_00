<Query Kind="Program" />

void Main()
{
	var listaLivros = new List<Livro>();
	
	var dig = new LivroDigital{Nome="Digital", preco = 100};
	var pap = new Livro{Nome="Papel", preco = 100};
	
	listaLivros.Add(dig);
	listaLivros.Add(pap);
	
	foreach (var element in listaLivros)
	{
		Console.WriteLine(element.Nome + " - " + element.ObterPreco());	
	}
}

interface ICalcula{
	double ObterPreco();
}

interface IImpressora
{
	double Imprimir();
}


class Livro : ICalcula, IImpressora {
	public string Nome { get; set; }
	public double preco { get; set; }

	public double Imprimir()
	{
		throw new NotImplementedException();
	}

	public virtual double ObterPreco(){
		return preco;
	}
}


class LivroDigital : Livro
{
	public override double ObterPreco()
	{
		return preco * 0.9;
	}
}


class Refrigerador : ICalcula
{
	public double ObterPreco()
	{
		throw new NotImplementedException();
	}
}