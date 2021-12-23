using bsi_push_data_into_api.App.Model;
using System;
using System.Data;
using System.Threading.Tasks;

namespace bsi_push_data_into_api
{
	public class TransactionLog_Sfid_Usecase
	{
        public static async Task Insert(DataTable dataRecord, DataTable response)
        {
            Sfid_Model param = new Sfid_Model();

            param.TrxID = Convert.ToInt32(dataRecord.Rows[0]["TrxID"]);
            param.SalesmanCode = Convert.ToString(dataRecord.Rows[0]["SalesmanCode"]);
            param.Endpoint = Convert.ToString(dataRecord.Rows[0]["Endpoint"]);
            param.Input = Convert.ToString(dataRecord.Rows[0]["Input"]);
            param.Output = Convert.ToString(response.Rows[0]["Output"]);
            param.Status = Convert.ToString(response.Rows[0]["Status"]);
            param.StartTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            param.EndTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            param.CreatedBy = "Scheduller";
            param.CreatedTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            param.UpdatedBy = "Scheduller";
            param.UpdatedTime = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt");
            param.Remarks = null;

            TransactionLog_Sfid_Repository storedProcedure = new TransactionLog_Sfid_Repository();
			await Task.Run(() => storedProcedure.Insert(param));
        }
    }
}
