using NFGeradorXML.DAL;
using NFGeradorXML.DAL.Dao;
using NFGeradorXML.DAL.Interfaces;
using NFGeradorXML.Helpers;
using System;
using System.Data.SqlClient;

namespace NFGeradorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionDB = "Server=(local);DataBase=VendasDB;Integrated Security=SSPI";

            using (INotaFiscalDAO notaFiscalDAO = new NotaFiscalDAO(new Connection(new SqlConnection(connectionDB), null)))
            {
                var result = notaFiscalDAO.GetNotaFiscalByEmissionDate(Convert.ToDateTime("2020-12-12"));

                FileXML.NotasFiscalToXML(result);
            }
        }
    }
}
