using NFGeradorXML.Model;
using System;
using System.Collections.Generic;

namespace NFGeradorXML.DAL.Interfaces
{
    public interface INotaFiscalDAO : IDisposable
    {
        public IEnumerable<NotaFiscal> GetNotaFiscalByEmissionDate(DateTime dataDaEmissao);
    }
}
