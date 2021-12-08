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
        public static void SPUpdateExec(IDataRecord dataRecord)
        { 
        string custId = (string)dataRecord[1];
        int sequence = (int)dataRecord[2];
        int status = 2;
        int returnVal = 1;
        
        SP_Update_Connect update = new SP_Update_Connect();
        update.SPUpdateConnect(custId, sequence, status, returnVal);
        }
    }
}
