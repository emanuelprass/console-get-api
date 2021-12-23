using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using bsi_push_data_into_api.App.Model;

namespace bsi_push_data_into_api
{
    public class TransactionLog_Queue_Repository
    {        
        SqlConnection sqlConn = null;
        string connString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public void Update(Queue_Model param)
        {
            using (sqlConn = new SqlConnection(connString))
            {
                SqlCommand sqlCmd = new SqlCommand("dbo.sp_Queue_UpdateTransactionLog", sqlConn);

                sqlCmd.Parameters.AddWithValue("@SAPCustomerID", SqlDbType.NVarChar).Value = param.CustomerID;
                sqlCmd.Parameters.AddWithValue("@Sequence", SqlDbType.Int).Value = param.Sequence;
                sqlCmd.Parameters.AddWithValue("@Status", SqlDbType.Int).Value = param.Status;
                sqlCmd.Parameters.AddWithValue("@Return", SqlDbType.Bit).Value = param.Return;

                sqlConn.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
    }
}
