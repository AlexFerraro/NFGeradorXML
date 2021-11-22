using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace NFGeradorXML.Model
{
    public class NotaFiscal
    {
        public int CodNota { get; set; }
        public int? CodVenda { get; set; }
        public string DestinatarioRemetente { get; set; }
        public DateTime? DTEmissao { get; set; }
        public DateTime? DtSaidaEntrada { get; set; }
        public int? NumNota { get; set; }
        public decimal? ValorTotalProdutos { get; set; }
        public decimal? ValorTotalNota { get; set; }
        public int? TransFrete { get; set; }
        public string NumeroRecibo { get; set; }

        public ICollection<NotaFiscalItem> NotaFiscalItens;

        public NotaFiscal() => NotaFiscalItens = new Collection<NotaFiscalItem>();
    }
}
