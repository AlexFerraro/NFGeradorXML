using NFGeradorXML.DAL.Interfaces;
using System;
using System.Data;

namespace NFGeradorXML.DAL
{
    public sealed class Connection : IConnection
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool disposedValue = false;

        public IDbConnection Conn => _connection;
        public IDbTransaction Transaction => _transaction;

        public Connection(IDbConnection connection, IDbTransaction transaction) => (_connection, _transaction) = (connection, transaction);

        public void Open() =>
            _connection.Open();

        public void Close() =>
            _connection.Close();


        public void BeginTrasaction() =>
            _transaction = _connection.BeginTransaction();

        public void Commit() =>
            _transaction.Commit();

        public void RollBack() =>
            _transaction.Rollback();

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection.Dispose();
                    if (_transaction != null)
                        _transaction.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
