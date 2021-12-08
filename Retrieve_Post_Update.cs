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
    internal class Retrieve_Post_Update
    {
        //set the connection string
        SqlConnection sqlConn = null;
        string connString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public void Execute()
        {
            using (sqlConn = new SqlConnection(connString))
            {
                Console.WriteLine(Environment.NewLine + "Retrieving data from TransactionLog..." + Environment.NewLine);

                SqlCommand sqlCmd = new SqlCommand("dbo.sp_CustomerGroupBySequence", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();

                SqlDataReader sqlDR = sqlCmd.ExecuteReader();

                // Call Read before accessing data.
                while (sqlDR.Read())
                {
                    Endpoint_Post.EndpointPost((IDataRecord)sqlDR);

                    SP_Update_Exec.SPUpdateExec((IDataRecord)sqlDR);
                }

                Console.WriteLine(Environment.NewLine + "All data status is 2, no data posted to endpoint." + Environment.NewLine);

                // Call Close when done reading.
                sqlDR.Close();

            }
        }

    }
}
