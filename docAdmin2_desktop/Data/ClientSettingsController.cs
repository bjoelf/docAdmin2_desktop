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
            string json = FortnoxToJSON(com);
            ClientSettingsModel ret = GetObject(json);
            return ret;
        }
        /// <summary>
        /// Replaces chars not allowed in fortnox to proper json chars.
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        public static string FortnoxToJSON(string comment)
        {
            //replace  { > ( , } > ) , } > ) , [ > / , ] > \
            string ret = comment.Replace('(', '{').Replace(')', '}').Replace('/', '[').Replace('\\', ']');
            return ret;
        }
        public static string JSONtoFortnox(string comment)
        {
            string ret = comment.Replace('{', '(').Replace('}', ')').Replace('[', '/').Replace(']', '\\');
            return comment;
        }

        /// <summary>
        /// Parses json string to ClientSettingsModel object
        /// https://app.quicktype.io/
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static ClientSettingsModel GetObject(string json)
        {
            /// https://app.quicktype.io/
            ClientSettingsModel ret = JsonConvert.DeserializeObject<ClientSettingsModel>(json);
            return ret;
        }

    }
}
