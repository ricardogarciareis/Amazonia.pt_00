namespace Amazonia.DAL.Desconto
{
    public class DescontoPercentual : IDesconto
    {
        public decimal PercentualDesconto { get; set; }
        public decimal Aplicar(decimal valorSemDesconto)
        {
            var result = valorSemDesconto - (valorSemDesconto * (PercentualDesconto / 100));
            return result;
        }
    }
}
