using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace bsi_push_data_into_api
{
    public class SP_Update_Connect
    {
        //set the connection string
        SqlConnection sqlConn = null;
        string connString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public void SPUpdateConnect(string custId, int sequence, int status, int returnVal)
        {
            using (sqlConn = new SqlConnection(connString))
            {
                Console.WriteLine(Environment.NewLine + "Updating data in TransactionLog...");

                SqlCommand sqlCmd = new SqlCommand("dbo.sp_UpdateTransactionLog", sqlConn);

                sqlCmd.Parameters.AddWithValue("@SAPCustomerID", SqlDbType.NVarChar).Value = custId;
                sqlCmd.Parameters.AddWithValue("@Sequence", SqlDbType.Int).Value = sequence;
                sqlCmd.Parameters.AddWithValue("@Status", SqlDbType.Int).Value = status;
                sqlCmd.Parameters.AddWithValue("@Return", SqlDbType.Bit).Value = returnVal;

                sqlConn.Open();
                sqlCmd.CommandType = CommandType.StoredProcedure;

                sqlCmd.ExecuteNonQuery();
                Console.WriteLine(Environment.NewLine + "The data has been successfully updated." + Environment.NewLine);
                sqlConn.Close();
            }
        }
    }
}
