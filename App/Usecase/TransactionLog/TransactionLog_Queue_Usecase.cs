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

			try
			{
                for (int counter = 0; counter < data.Rows.Count; counter++)
                {
                    param.CustomerID = data.Rows[counter]["SAPCustomerID"].ToString();
                    param.Sequence = Convert.ToInt16(data.Rows[counter]["Sequence"]);
                    param.Status = Convert.ToInt16(data.Rows[counter]["Status"]);
                    param.Return = Convert.ToInt16(data.Rows[counter]["Return"]);

                    TransactionLog_Queue_Repository storedProcedure = new TransactionLog_Queue_Repository();
                    await Task.Run(() => storedProcedure.Update(param));
                }
                Console.WriteLine("3. Successed to update data on Queue_TransactionLog table.");
            }
			catch (Exception)
			{
                Console.WriteLine("3. Failed to update data on Queue_TransactionLog table.");
            }
        }
    }
}
