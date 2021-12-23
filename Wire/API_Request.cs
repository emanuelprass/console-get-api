using System;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data;

namespace bsi_push_data_into_api
{
    internal class API_Request
    {
        public static async Task<DataTable> Post(DataTable dataRecord)
        {
            Console.WriteLine(Environment.NewLine + "Requesting to POST to endpoint..." + Environment.NewLine);

            string token = dataRecord.Rows[0]["Token"].ToString();

            string endpoint = dataRecord.Rows[0]["Endpoint"].ToString();

            string input = dataRecord.Rows[0]["Input"].ToString();


            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Authorization:Bearer " + token);
            string json = await Task.Run(() => client.UploadString(endpoint, input));            
            

            //Console.WriteLine($"Posting SAPCustomerID {dataRecord[1]} with sequence {dataRecord[2]} ...");
            Console.WriteLine(Environment.NewLine + json);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { 
                new DataColumn("Status", typeof(string)),                    
                new DataColumn("Output",typeof(string))
            });
            dt.Rows.Add(1, json);

            return dt;
        }


}
}
