using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

namespace bsi_push_data_into_api
{
    internal class Usecase
    {        
        SqlConnection sqlConn = null;
        string connString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public async void Execute()
        {
            var datas = new DataTable();

            using (sqlConn = new SqlConnection(connString))
            {
                Console.WriteLine(Environment.NewLine + "Retrieving data from TransactionLog..." + Environment.NewLine);
                SqlCommand sqlCmd = new SqlCommand("dbo.sp_Queue_GroupingTransactionLogBySequence", sqlConn);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlConn.Open();

                using (SqlDataReader sqlDR = await sqlCmd.ExecuteReaderAsync())
                {
                    datas.Load(sqlDR);
                    try
                    {
                        var response = await API_Request.Post(datas);
                        await Queue_TransactionLog.Update(datas);
                        await SFID_TransactionLog.Insert(datas, response);
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
                }
            }
            Console.WriteLine(Environment.NewLine + "All valid data has been posted to endpoint.");
            Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("=", 50)) + Environment.NewLine);
        }
    }
}
