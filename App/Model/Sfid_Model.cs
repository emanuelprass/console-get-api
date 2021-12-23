using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bsi_push_data_into_api.App.Model
{
	public class Sfid_Model
	{
		public int TrxID { get; set; }
		public string SalesmanCode { get; set; }
		public string Endpoint { get; set; }
		public string Input { get; set; }
		public string Output { get; set; }
		public string Status { get; set; }
		public string StartTime { get; set; }
		public string EndTime { get; set; }
		public string CreatedBy { get; set; }
		public string CreatedTime { get; set; }
		public string UpdatedBy { get; set; }
		public string UpdatedTime { get; set; }
		public string Remarks { get; set; }
	}
}
