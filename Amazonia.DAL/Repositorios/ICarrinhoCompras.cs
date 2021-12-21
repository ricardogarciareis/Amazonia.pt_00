using Amazonia.DAL.Desconto;

namespace Amazonia.DAL.Repositorios
{
    interface ICarrinhoCompras
    {
        decimal CalcularPreco();
        //Comentado só para guardar o histórico
        //decimal AplicarDesconto(decimal valorDesconto);
        decimal AplicarDesconto(IDesconto tipoDeDesconto);
    }
}
