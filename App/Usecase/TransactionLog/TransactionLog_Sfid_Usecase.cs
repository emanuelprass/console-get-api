using bsi_push_data_into_api.App.Model;
using System;
using System.Data;
using System.Threading.Tasks;

namespace bsi_push_data_into_api
{
	public class TransactionLog_Sfid_Usecase
	{
        public static async Task Insert(DataTable data)
        {
            Sfid_Model param = new Sfid_Model();

			try
			{
                for (int counter = 0; counter < data.Rows.Count; counter++)
				{
                    param.TrxID = Convert.ToInt32(data.Rows[counter]["TrxID"]);
                    param.SalesmanCode = Convert.ToString(data.Rows[counter]["SalesmanCode"]);
                    param.Endpoint = Convert.ToString(data.Rows[counter]["Endpoint"]);
                    param.Input = Convert.ToString(data.Rows[counter]["Input"]);
                    param.Output = Convert.ToString(data.Rows[counter]["Output"]);
                    param.Status = Convert.ToString(data.Rows[counter]["Status"]);
                    param.StartTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    param.EndTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    param.CreatedBy = Convert.ToString(data.Rows[counter]["SalesmanCode"]);
                    param.CreatedTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    param.UpdatedBy = Convert.ToString(data.Rows[counter]["SalesmanCode"]);
                    param.UpdatedTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
                    param.Remarks = null;

                    TransactionLog_Sfid_Repository storedProcedure = new TransactionLog_Sfid_Repository();
                    await Task.Run(() => storedProcedure.Insert(param));
                }
                Console.WriteLine("4. Successed to add data at SFID_TransactionLog table.");
            }
			catch (Exception)
			{
                Console.WriteLine("4. Failed to add data at SFID_TransactionLog table.");
			}
        }
    }
}
