using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using bsi_push_data_into_api.App.Model;

namespace bsi_push_data_into_api
{
	public class TransactionLog_Sfid_Repository
    {
        SqlConnection sqlConn = null;
        string connString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public void Insert(Sfid_Model param)
        {
            using (sqlConn = new SqlConnection(connString))
            {
                SqlCommand sqlCmd = new SqlCommand("dbo.sp_SFID_InsertTransactionLog", sqlConn);

                sqlCmd.Parameters.AddWithValue("@TrxID", SqlDbType.Int).Value = param.TrxID;
                sqlCmd.Parameters.AddWithValue("@SalesmanCode", SqlDbType.NVarChar).Value = param.SalesmanCode;
                sqlCmd.Parameters.AddWithValue("@Endpoint", SqlDbType.NVarChar).Value = param.Endpoint;
                sqlCmd.Parameters.AddWithValue("@Input", SqlDbType.NVarChar).Value = param.Input;
                sqlCmd.Parameters.AddWithValue("@Output", SqlDbType.NVarChar).Value = param.Output;
                sqlCmd.Parameters.AddWithValue("@Status", SqlDbType.Bit).Value = param.Status;
                sqlCmd.Parameters.AddWithValue("@StartTime", SqlDbType.NVarChar).Value = param.StartTime;
                sqlCmd.Parameters.AddWithValue("@EndTime", SqlDbType.NVarChar).Value = param.EndTime;
                sqlCmd.Parameters.AddWithValue("@CreatedBy", SqlDbType.NVarChar).Value = param.CreatedBy;
                sqlCmd.Parameters.AddWithValue("@CreatedTime", SqlDbType.NVarChar).Value = param.CreatedTime;
                sqlCmd.Parameters.AddWithValue("@LastUpdateBy", SqlDbType.NVarChar).Value = param.UpdatedBy;
                sqlCmd.Parameters.AddWithValue("@LastUpdateTime", SqlDbType.NVarChar).Value = param.UpdatedTime;
                sqlCmd.Parameters.AddWithValue("@Remarks", SqlDbType.NVarChar).Value = param.Remarks;

                sqlConn.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.ExecuteNonQuery();
                sqlConn.Close();
            }
        }
    }
}
