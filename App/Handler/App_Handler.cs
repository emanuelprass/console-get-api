using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;

namespace bsi_push_data_into_api
{
    internal class App_Handler
    {        
        SqlConnection sqlConn = null;
        string connString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public async void Execute()
        {
            var datas = new DataTable();

            using (sqlConn = new SqlConnection(connString))
            {
                try
                {
                    SqlCommand sqlCmd = new SqlCommand("dbo.sp_Queue_GroupingTransactionLogBySequence", sqlConn);
                    sqlCmd.CommandType = CommandType.StoredProcedure;
                    sqlConn.Open();
                    SqlDataReader sqlDR = await sqlCmd.ExecuteReaderAsync();
                    datas.Load(sqlDR);
                    sqlConn.Close();

                    Console.WriteLine("1. Transaction Log Collected.");

                    var response = await Middleware_TransactionLog_Usecase.Post(datas);
                    await TransactionLog_Queue_Usecase.Update(response);
                    await TransactionLog_Sfid_Usecase.Insert(response);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error while process >>>> ", ex.Message);

                }
            }
            Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("=", 87)) + Environment.NewLine);
        }
    }
}
