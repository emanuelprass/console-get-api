using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Data;

namespace bsi_push_data_into_api
{
    internal class Endpoint_Post
    {
        public static async Task EndpointPost(IDataRecord dataRecord)
        {
            Console.WriteLine(Environment.NewLine + "Requesting to POST to endpoint..." + Environment.NewLine);

            string token = (string)dataRecord[5];

            string endpoint = (string)dataRecord[6];

            string input = (string)dataRecord[7];


            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Authorization:Bearer " + token);


            string json = await Task.Run(() => client.UploadString(endpoint, input));

            
            Console.WriteLine($"Posting SAPCustomerID {dataRecord[1]} with sequence {dataRecord[2]} ...");
            Console.WriteLine(Environment.NewLine + json);
        }
    }
}
