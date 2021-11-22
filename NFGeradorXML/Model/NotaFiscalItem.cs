using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFGeradorXML.Model
{
    public class NotaFiscalItem
    {
        public int CodItem { get; set; }
        public int? CodNota { get; set; }
        public int? CodPro { get; set; }
        public string DescrPro { get; set; }
        public string Unidade { get; set; }
        public decimal? QTDE { get; set; }
        public decimal? ValorTotal { get; set; }
        public string CodigoProdutoExterno { get; set; }
        public decimal? ValorUnitario { get; set; }

        public NotaFiscal NotaFiscal { get; set; }
    }
}
