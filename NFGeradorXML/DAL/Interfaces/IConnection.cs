using System;
using System.Data;

namespace NFGeradorXML.DAL.Interfaces
{
    public interface IConnection : IDisposable
    {
        IDbConnection Conn { get; }
        IDbTransaction Transaction { get; }

        void Open();
        void Close();
        void BeginTrasaction();
        void RollBack();
    }
}
