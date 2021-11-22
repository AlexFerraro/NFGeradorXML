using NFGeradorXML.DAL.Interfaces;
using NFGeradorXML.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;

namespace NFGeradorXML.DAL.Dao
{
    public class NotaFiscalDAO : INotaFiscalDAO
    {
        private IConnection _conn;
        private bool disposedValue = false;

        public NotaFiscalDAO(IConnection conn) => _conn = conn;

        public IEnumerable<NotaFiscal> GetNotaFiscalByEmissionDate(DateTime dataDaEmissao)
        {
            ICollection<NotaFiscal> notaFiscais = null;

            try
            {
                using (var command = new SqlCommand("Sp_GetNotaFiscalByEmission", (SqlConnection)_conn.Conn))
                {
                    _conn.Open();

                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandTimeout = 5;

                    command.Parameters.Add("@DataEmissao", SqlDbType.Date).Value = dataDaEmissao;

                    using (var result = command.ExecuteReader())
                    {
                        notaFiscais = new Collection<NotaFiscal>();

                        while (result.Read())
                        {
                            notaFiscais.Add(new NotaFiscal
                                                {
                                                    CodNota = result.GetInt32(0)
                                                    , CodVenda = result["CODVENDA"] != DBNull.Value ? Convert.ToInt32(result["CODVENDA"]) : null
                                                    , DestinatarioRemetente = result["DESTINATARIOREMETENTE"] != DBNull.Value ? result["DESTINATARIOREMETENTE"].ToString() : null
                                                    , DTEmissao = result["DTEMISSAO"] != DBNull.Value ? Convert.ToDateTime(result["DTEMISSAO"]) : null
                                                    , DtSaidaEntrada = result["DTSAIDAENTRADA"] != DBNull.Value ? Convert.ToDateTime(result["DTSAIDAENTRADA"]) : null
                                                    , NumNota = result["NUMNOTA"] != DBNull.Value ? Convert.ToInt32(result["NUMNOTA"]) : null
                                                    , ValorTotalProdutos = result["VALORTOTALPRODUTOS"] != DBNull.Value ? Convert.ToDecimal(result["VALORTOTALPRODUTOS"]) : null
                                                    , ValorTotalNota = result["VALORTOTALNOTA"] != DBNull.Value ? Convert.ToDecimal(result["VALORTOTALNOTA"]) : null
                                                    , TransFrete = result["TRANSFRETE"] != DBNull.Value ? Convert.ToInt32(result["TRANSFRETE"]) : null
                                                    , NumeroRecibo = result["NUMERORECIBO"] != DBNull.Value ? result["NUMERORECIBO"].ToString() : null
                                                }
                            );
                        }

                        return notaFiscais;
                    }
                }
            }
            catch (SqlException)
            {
                //Criar log de falha!
                throw;
            }finally
            {
                _conn.Close();
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _conn.Dispose();
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
