using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Amazonia.DAL.Modelo
{
    public class Periodico : Livro
    {
        public Periodico()
        {
            if(DataLancamento == new DateTime()) //0001, 01, 01
            {
                DataLancamento = DateTime.Today;
            }
        }

        [Required]
        public DateTime DataLancamento { get; set; }


        [NotMapped]
        public override string TipoPorEscrito => "Periódico";

        //public override decimal ObterPreco()
        //{
        //    var valorCalculado = base.ObterPreco();
        //    var percentualDesconto = 0M;
        //    var ativarPromocoes = Convert.ToBoolean(ConfigurationManager.AppSettings["ativarPromocoes"]);


        //    if (ativarPromocoes)
        //    {
        //        var numeroMinimoDias = Convert.ToInt32(ConfigurationManager.AppSettings["numeroMinimoDias"]); //30
        //        if (DataLancamento < DateTime.Today.AddDays(-numeroMinimoDias)) //Datalancamento = 20211102 
        //        {
        //            percentualDesconto = Convert.ToDecimal(ConfigurationManager.AppSettings["valorDescontoMinimo"]); 

        //            var numeroMaximoDias = Convert.ToInt32(ConfigurationManager.AppSettings["numeroMaximoDias"]);                   
        //            if (DataLancamento < DateTime.Today.AddDays(-numeroMaximoDias))
        //            {
        //                percentualDesconto = Convert.ToDecimal(ConfigurationManager.AppSettings["valorDescontoMaximo"]); 
        //            }
        //        }
        //    }

        //    var result = valorCalculado - (valorCalculado * (percentualDesconto / 100));
        //    return result;
        //}
    }
}
