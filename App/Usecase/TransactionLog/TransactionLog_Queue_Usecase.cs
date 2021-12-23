using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using bsi_push_data_into_api.App.Model;

namespace bsi_push_data_into_api
{
    public class TransactionLog_Queue_Usecase
    {
        public static async Task Update(DataTable data)
        {
			Queue_Model param = new Queue_Model();
            
            for(int counter = 0; counter <= data.Rows.Count; counter ++)
			{
                param.CustomerID = data.Rows[counter]["SAPCustomerID"].ToString();
                param.Sequence = Convert.ToInt16(data.Rows[counter]["Sequence"]);
                param.Status = 2;
                param.Return = 1;
            }

            Console.WriteLine(Environment.NewLine + $"Updating SAPCustomerID {param.CustomerID} with sequence {param.Sequence} in TransactionLog...");
        
            TransactionLog_Queue_Repository storedProcedure = new TransactionLog_Queue_Repository();
            await Task.Run(() => storedProcedure.Update(param));

            Console.WriteLine(Environment.NewLine + "The data has been successfully updated." + Environment.NewLine);
            Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("-", 50)) + Environment.NewLine);
        }
    }
}
