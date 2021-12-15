using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Data;


namespace bsi_push_data_into_api
{
    public class SP_Update_Exec
    {
        public static async Task SPUpdateExec(IDataRecord dataRecord)
        { 
        string custId = (string)dataRecord[1];
        int sequence = (int)dataRecord[2];
        int status = 2;
        int returnVal = 1;

        Console.WriteLine(Environment.NewLine + $"Updating SAPCustomerID {dataRecord[1]} with sequence {dataRecord[2]} in TransactionLog...");
        
        SP_Update_Connect update = new SP_Update_Connect();
        await Task.Run(() => update.SPUpdateConnect(custId, sequence, status, returnVal));

        Console.WriteLine(Environment.NewLine + "The data has been successfully updated." + Environment.NewLine);
        Console.WriteLine(Environment.NewLine + string.Concat(Enumerable.Repeat("-", 50)) + Environment.NewLine);
        }
    }
}
