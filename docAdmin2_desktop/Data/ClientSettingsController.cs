using System;
using System.Collections.Generic;
using System.Text;
using docAdmin2_desktop.Model;
using docAdmin2_desktop.Fortnox;
using Newtonsoft.Json;

namespace docAdmin2_desktop.Data
{
    public class ClientSettingsController
    {
        public static ClientSettingsModel Retrive(int clientID)
        {
            string com = FortnoxStuff.GetCustomerComment(clientID);
            string json = FortnoxStuff.FortnoxToJSON(com);
            ClientSettingsModel ret = GetObject(json);
            return ret;
        }
        public static ClientSettingsModel GetObject(string json)
        {
            /// https://app.quicktype.io/
            ClientSettingsModel ret = JsonConvert.DeserializeObject<ClientSettingsModel>(json);
            return ret;
        }
    }
}
