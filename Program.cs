using System;
using System.Net;
using System.Text;
using System.Threading;

namespace bsi_push_data_into_api
{
	class Program
	{
        private static Timer _timer = null;
		static void Main(string[] args)
		{
			_timer = new Timer(TimerCallback, null, 0, (60*1000));
            Console.ReadLine();
        }

        private static void TimerCallback(Object o)
        {
			string apiUrl = "https://qa-interface.mitsubishi-motors.co.id/QA-Api/Master/SendASBSFID/SendProspectCreate";

			string requestBody = @"{'lead':{'ID':2032246,'SalesforceID':'','DealerID':172,'SalesmanHeaderID':26489,'VechileTypeID':null,
            'CustomerCode':'','CustomerName':'Des BUMN 1','CustomerType':2,'CustomerAddress':null,'PhoneType':0,'Phone':'88132100100',
            'Email':'','Sex':0,'AgeSegment':0,'CustomerPurpose':5,'InformationType':0,'InformationSource':5,'Status':2,'Qty':1,'ProspectDate':'2021-12-02T00:00:00','isSPK':false,'CurrVehicleBrand':'','Rating':2,'CurrVehicleType':'','Note':'Catatan','WebID':'','BirthDate':'1753-01-01T00:00:00','PreferedVehicleModel':null,'Description':null,'EstimatedCloseDate':'1753-01-01T00:00:00','OriginatingLeadId':'ba63eb33-1053-ec11-8f8e-000d3ac79e2f','StatusCode':1,'LeadStatus':3,'StateCode':0,'CampaignName':null,'BusinessSectorDetailID':null,'VehicleModel':null,'Variant':'','Sequence':0,'Name2':'','Telp':'','IdentityType':8,'IdentityNumber':'','JobKind':0,'VechileColorID':null,'DealerVehiclePriceDetailID':null,'CusReqPrice':385600100.0,'CusReqDiscount':0.0,'BookingFee':0.0,'BBNType':0,'BlankoSPKNo':'','BlankoSPKDoc':'','InterfaceStatus':1,'InterfaceMessage':'On Progress Update Data SFID','GUIDUpdate':'2112000712','Topic':'Topic Desember 3','VechileModelID':65,'CurrVehicleBrandDesc':'','VehicleComparison':'','GUID':'ba63eb33-1053-ec11-8f8e-000d3ac79e2f','CountryCode':'Indonesia','RowStatus':0,'CreatedBy':'S-123346','CreatedTime':'2021-12-02T08:32:06.977','LastUpdateBy':'S-123346','LastUpdateTime':'2021-12-02T08:41:32.295296+07:00'},'activity':{'SalesmanCode':'S-123346','DealerID':172,'CustomerDataID':2032246,'DataType':2,'JanjiTemu':[],'Email':[],'Telp':[],'Tugas':[]}}";

			WebClient client = new WebClient();
			client.Headers["Content-type"] = "application/json";
			client.Encoding = Encoding.UTF8;
			client.Headers.Add("Authorization:B.. ....");
			string json = client.UploadString(apiUrl, requestBody);
			Console.WriteLine(Environment.NewLine + json);
		}
    }
}
