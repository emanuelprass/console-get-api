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
			client.Headers.Add("Authorization:Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiT0NSX1VzZXJARE1TLkNPTSIsIkRlYWxlckNvZGUiOiIxMDAxNzAiLCJVc2VySWQiOiI0MzgiLCJDbGllbnRJZCI6IjQ2OTRmODBkLWZhNTMtNDQ5OC1iNGE4LWNjMTE0YTY3YTlkNiIsIkRlYWxlcklkIjoiMTcyIiwiYXVkIjpbImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL0NSLUFwaSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL01JRy1BcGkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9ERVYtQXBpIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvUUEtVUkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9RQS1BcGkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9ETVNUZXN0VUkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9NSUctVUkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9UcmFpbmluZy1VSSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL1RyYWluaW5nLUFwaSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL0RFVi1VSSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL1dlYlVJIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvRE1TVGVzdEFwaSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL0FDQy1VSSIsImh0dHA6Ly9sb2NhbGhvc3QvTU1LU0lXZWJVSSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL1VBVEFwaSIsImh0dHA6Ly9sb2NhbGhvc3QvTU1LU0lXZWJBcGkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9ETVNVSSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL1dlYkFwaSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL1VBVFVJIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvRE1TQXBpIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvV2ViIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvQUNDLUFQSSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL0NSLVVJIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvQ1IxLUFwaSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL0NSMS1VSSIsImh0dHBzOi8vcWEtaW50ZXJmYWNlLm1pdHN1YmlzaGktbW90b3JzLmNvLmlkL0NSMi1BcGkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9DUjItVUkiLCJodHRwczovL3FhLWludGVyZmFjZS5taXRzdWJpc2hpLW1vdG9ycy5jby5pZC9DUjMtQXBpIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvQ1IzLVVJIiwiaHR0cHM6Ly9xYS1pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQvQVBJIl0sImV4cCI6MTYzOTU5ODQwMCwiaXNzIjoiaHR0cHM6Ly9pbnRlcmZhY2UubWl0c3ViaXNoaS1tb3RvcnMuY28uaWQifQ.cpyNUubi10X2nONiRBPfNJT_zHnGr3IyT95ScUdxiCY");
			string json = client.UploadString(apiUrl, requestBody);
			Console.WriteLine(Environment.NewLine + json);
		}
    }
}
