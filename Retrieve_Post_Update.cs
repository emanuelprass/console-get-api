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

        public async void Execute()
        {
            using (sqlConn = new SqlConnection(connString))
            {
                Console.WriteLine(Environment.NewLine + "Retrieving data from TransactionLog..." + Environment.NewLine);
                SqlCommand sqlCmd = new SqlCommand("dbo.sp_CustomerGroupBySequence", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();

                using (SqlDataReader sqlDR = await sqlCmd.ExecuteReaderAsync())
                {
                    try
                        {
                            await Endpoint_Post.EndpointPost((IDataRecord)sqlDR);
                            await SP_Update_Exec.SPUpdateExec((IDataRecord)sqlDR);

                        }
                        catch (WebException ex)
                        {
                            Console.WriteLine($"Failed to post SAPCustomerID {sqlDR[1]} with sequence {sqlDR[2]}. {Environment.NewLine}");

                            if (ex.Status == WebExceptionStatus.ProtocolError)
                            {
                                var response = ex.Response as HttpWebResponse;
                                if ((int)response.StatusCode == 401)
                                {
                                    Console.WriteLine($"HTTP Status Code {(int)response.StatusCode}: Invalid or expired token. {Environment.NewLine}");
                                    Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("-", 50)) + Environment.NewLine);
                                }
                                else if ((int)response.StatusCode == 500)
                                {
                                    Console.WriteLine($"HTTP Status Code {(int)response.StatusCode}: Internal server error. {Environment.NewLine}");
                                    Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("-", 50)) + Environment.NewLine);
                                }
                                else if ((int)response.StatusCode == 404)
                                {
                                    Console.WriteLine($"HTTP Status Code {(int)response.StatusCode}: Not found. Invalid endpoint. {Environment.NewLine}");
                                    Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("-", 50)) + Environment.NewLine);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Other Exception");
                            }

                        }
                    sqlDR.Close();                
                }
                
                Console.WriteLine(Environment.NewLine + "All valid data has been posted to endpoint.");
                Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("=", 50)) + Environment.NewLine);
            }
        }

    }
}
