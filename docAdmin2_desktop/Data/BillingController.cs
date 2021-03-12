using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Microsoft.Win32;
using System.Diagnostics;
using Fortnox.SDK.Entities;
using docAdmin2_desktop.Model;
using docAdmin2_desktop.Fortnox;


namespace docAdmin2_desktop.Data
{
    public class BillingController
    {
        private static ClientSettingsModel CSM;
        private static List<ExamModel> FileRows = new List<ExamModel>();

        public BillingController(int clientId, string filepath)
        {
            CSM = ClientSettingsController.Retrive(clientId);
            FileRows = FileProcessor.Process(filepath, CSM);
        }
        public static List<Order> CreateOrders(int clientid, string filepath)
        {
            List<Order> orders = new List<Order>();

            foreach (ExamModel row in FileRows)
            {
                //TODO: Implement Exams to Orders loop

            }
            return orders;
        }
        public static string FileOpenDialog()
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();
            Nullable<bool> result = openFileDlg.ShowDialog();
            string ret = "";
            if (result == true)
            {
                ret = openFileDlg.FileName;
            }
            return ret;
        }

    }
}
