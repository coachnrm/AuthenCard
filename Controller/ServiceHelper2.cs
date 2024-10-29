using AuthenCard.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AuthenCard.Controller
{
    public class ServiceHelper2
    {
        private static Uri DataBaseAddress {get; set;} = new Uri("http://localhost:5094");
        public async static Task<LoginHos> GetLogin(string username, string password)
        {
            

            var client = new HttpClient();
            client.BaseAddress = DataBaseAddress;
            var response = await client.GetAsync("api/Hos/getUser?uname=" + username+ "&para=" + password);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            var json = await response.Content.ReadAsStringAsync();
            //return  JsonConvert.DeserializeObject<List<Cid>>(json);
            // return JArray.Parse(json).ToObject<List<Cid>>();
            return JsonConvert.DeserializeObject<LoginHos>(json);
             

        }
        else return new LoginHos();
        }

        public async static Task<LoginHos> PostLogin(string username, string password)
        {
           var param = new Dictionary<string, string>();
           param.Add("uname", username);
           param.Add("para", password);

           var content = new FormUrlEncodedContent(param);

           var clientData = GetClientData();
           var response = await clientData.PostAsync("api/Hos/PostUser", content);
           if (response.StatusCode == System.Net.HttpStatusCode.OK)
           {
                var json = await response.Content.ReadAsStringAsync();
                return JObject.Parse(json).ToObject<LoginHos>();
           }
           else return null;
        }

        public async static Task<Ovst> PostOpenVisit(string hn, string hcode, string doctor, string hospmain, string hospsub, string ovstist, string ovstost, string pttype, string spclty, string lastDep, string mainDep)
        {
            var param = new Dictionary<string, string>();
            param.Add("hn", hn);
            param.Add("hcode", hcode);
            param.Add("doctor", doctor);
            param.Add("hospmain", hospmain);
            param.Add("hospsub", hospsub);
            param.Add("ovstist", ovstist);
            param.Add("ovstost", ovstost);
            param.Add("pttype", pttype);
            param.Add("spclty", spclty);
            param.Add("lastDep", lastDep);
            param.Add("mainDep", mainDep);

            var content = new FormUrlEncodedContent(param);

            var clientData = GetClientData();
            var response = await clientData.PostAsync("api/Hos/OpenVisit", content);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JObject.Parse(json).ToObject<Ovst>();
            }
            else return null;
        }

         private static HttpClient GetClientData()
        {
            var clientData = new HttpClient();
            clientData.BaseAddress = DataBaseAddress;
            return clientData;
        }
    }
}