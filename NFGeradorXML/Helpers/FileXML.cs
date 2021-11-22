using NFGeradorXML.Model;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NFGeradorXML.Helpers
{
    public class FileXML
    {
        public static void NotasFiscalToXML(IEnumerable<NotaFiscal> notaFiscals) 
        {
            var xml = new XDocument(new XElement("NotaFiscais",
                                                notaFiscals.Select(p => new XElement("NotaFiscal",
                                                    new XAttribute("CodNota", p.CodNota)
                                                    , new XAttribute("CodVenda", p.CodVenda ?? 0)
                                                    , new XAttribute("DestinatarioRemetente", p.DestinatarioRemetente ?? string.Empty)
                                                    , new XAttribute("DTEmissao", p.DTEmissao != null ? p.DTEmissao : "-" )
                                                    , new XAttribute("DtSaidaEntrada", p.DtSaidaEntrada != null ? p.DtSaidaEntrada : "-")
                                                    , new XAttribute("NumNota", p.NumNota ?? 0)
                                                    , new XAttribute("ValorTotalProdutos", p.ValorTotalProdutos ?? 0)
                                                    , new XAttribute("ValorTotalNota", p.ValorTotalNota ?? 0)
                                                    , new XAttribute("TransFrete", p.TransFrete ?? 0)
                                                    , new XAttribute("NumeroRecibo", p.NumeroRecibo ?? string.Empty)
                                                    ))));
            xml.Save("NotaFiscais.xml");
        }
    }
}
