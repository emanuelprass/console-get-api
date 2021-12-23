using bsi_push_data_into_api.App.Model;
using System;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace bsi_push_data_into_api.app.Repository.Middleware
{
	public class Middleware_TransactionLog_Repository
	{
        public static async Task<String> Execute(Queue_Model param)
        {
            try
            {
                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                client.Headers.Add("Authorization:Bearer " + param.Token);
                string json = await Task.Run(() => client.UploadString(param.Endpoint, param.Input));
                return json;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}
