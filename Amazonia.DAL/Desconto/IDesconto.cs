namespace Amazonia.DAL.Desconto
{
    public interface IDesconto
    {
        decimal Aplicar(decimal valorSemDesconto);
    }
}
