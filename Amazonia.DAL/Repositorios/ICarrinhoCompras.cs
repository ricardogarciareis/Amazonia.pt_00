using Amazonia.DAL.Desconto;

namespace Amazonia.DAL.Repositorios
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();
        //Comentado s� para guardar o hist�rico
        //decimal AplicarDesconto(decimal valorDesconto);
        decimal AplicarDesconto(IDesconto tipoDeDesconto);
    }
}
