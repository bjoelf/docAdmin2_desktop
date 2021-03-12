using System;
using System.Collections.Generic;
using Fortnox.SDK;
using Fortnox.SDK.Connectors;
using Fortnox.SDK.Entities;
using System.Diagnostics;
using System.Net.Http;

namespace docAdmin2_desktop.Fortnox
{
    public class FortnoxStuff
    {
        //TODO: Lägg lite settings i constructorn!

        static FortnoxClient client()
        {
            FortnoxClient fortnoxClient = new FortnoxClient()
            {
                //SandBox AccessToken
                AccessToken = "8c688358-181e-4d6e-a0c1-7ba50618c32d",
                //AccessToken = AppSettings.ReadAppSetting("AccessToken"),   // prod
                ClientSecret = "PqQ6cN3Qk7",
                //ClientSecret = AppSettings.ReadAppSetting("ClientSecret"), // prod
                HttpClient = new HttpClient()
                {
                    Timeout = TimeSpan.FromSeconds(10)
                }
            };
            return fortnoxClient;
        }
        public static int Send(List<Order> orders)
        {
            FortnoxClient fnc = client();
            OrderConnector ocon = fnc.Get<OrderConnector>();
            foreach (Order item in orders)
            {
                ocon.Create(item);
            }
            return orders.Count;
        }
        public static int Send(Order order)
        {
            FortnoxClient fnc = client();
            OrderConnector ocon = fnc.Get<OrderConnector>();
            ocon.Create(order);
            return 1;
        }
        public static string GetCustomerComment(int ClientId)
        {
            FortnoxClient fnc = client();
            var c = GetCustomer(fnc, ClientId);
            return c.Comments;
        }
        public static Customer GetCustomer(FortnoxClient fortnoxClient, int custId)
        {
            var customerConnector = fortnoxClient.Get<CustomerConnector>();
            Customer customer = new Customer();
            try
            {
                customer = customerConnector.Get(custId.ToString());
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
            }
            return customer;
        }
    }
}
