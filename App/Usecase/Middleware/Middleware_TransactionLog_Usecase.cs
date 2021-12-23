using System;
using System.Threading.Tasks;
using System.Data;
using bsi_push_data_into_api.App.Model;
using bsi_push_data_into_api.app.Repository.Middleware;

namespace bsi_push_data_into_api
{
    internal class Middleware_TransactionLog_Usecase
    {
        public static async Task<DataTable> Post(DataTable data)
        {
            Queue_Model param = new Queue_Model();

            data.Columns.AddRange(new DataColumn[1]
            {
                new DataColumn("Output", typeof(string))
            });
			
			for (int counter = 0; counter < data.Rows.Count; counter++)
			{
                param.CustomerID = data.Rows[counter]["SAPCustomerID"].ToString();
                param.Sequence = Convert.ToInt32(data.Rows[counter]["Sequence"]);
                param.Token = data.Rows[counter]["Token"].ToString();
                param.Endpoint = data.Rows[counter]["Endpoint"].ToString();
                param.Input = data.Rows[counter]["Input"].ToString();

                var jsonString = await Middleware_TransactionLog_Repository.Execute(param);
                data.Rows[counter]["Output"] = jsonString;
                data.Rows[counter]["Status"] = jsonString.Contains(@"""success"":true") ? 2 : 1;
                data.Rows[counter]["Return"] = jsonString.Contains(@"""success"":true") ? 1 : 0;                
            }
            Console.WriteLine("2. Success to retrieve API data.");
            return data;
        }
}
}
