using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace PinnacleSample
{
    public class PartInvoiceRepositoryDB : IPartInvoiceRepository
    {
        public void Add(PartInvoice invoice)
        {
            string _ConnectionString = ConfigurationManager.ConnectionStrings["appDatabase"].ConnectionString;

            using (SqlConnection _Connection = new SqlConnection(_ConnectionString))
            {
                SqlCommand _Command = new SqlCommand
                {
                    Connection = _Connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "PMS_AddPartInvoice"
                };

                SqlParameter _StockCodeParameter = new SqlParameter("@StockCode", SqlDbType.VarChar, 50) { Value = invoice.StockCode };
                _Command.Parameters.Add(_StockCodeParameter);
                SqlParameter QuantityParameter = new SqlParameter("@Quantity", SqlDbType.Int) { Value = invoice.Quantity };
                _Command.Parameters.Add(QuantityParameter);
                SqlParameter CustomerIDParameter = new SqlParameter("@CustomerID", SqlDbType.Int) { Value = invoice.CustomerID };
                _Command.Parameters.Add(CustomerIDParameter);

                _Connection.Open();
                _Command.ExecuteNonQuery();
            }
        }
    }
}
