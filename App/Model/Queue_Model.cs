namespace bsi_push_data_into_api.App.Model
{
	public class Queue_Model
	{
		public string CustomerID { get; set; }
		public int Sequence { get; set; }
		public string Token { get; set; }
		public string Endpoint { get; set; }
		public string Input { get; set; }
		public string Output { get; set; }
		public int Status { get; set; }
		public int Return { get; set; }
	}
}
