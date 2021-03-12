using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Data;
using docAdmin2_desktop.Model;

namespace docAdmin2_desktop.Data
{
    public class FileProcessor
    {
        public static List<ExamModel> Process(string filepath, ClientSettingsModel csm)
        {
            DataSet ds = ReadFile(filepath);
            List<ExamModel> x = GetExams(ds,csm);
            return x;
        }

        public static List<ExamModel> GetExams(DataSet ds, ClientSettingsModel csm)
        {
            List<ExamModel> ex = new List<ExamModel>();
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    ExamModel exam = new ExamModel();

                    //TODO: Implement DataSet to ExamModel loop



                    ex.Add(exam);
                }
            }
            return ex;
        }

        public static DataSet ReadFile(string filepath)
        {
            DataSet ds = new DataSet();
            string x = Path.GetExtension(filepath);
            switch (x)
            {
                case ".xlsx":
                    ds = ReadExcel(filepath);
                    break;
                case ".txt":
                    ReadText(filepath);
                    break;
                default:
                    throw new NotImplementedException();
            }
            return ds;
        }
        ///Read excel and return object.
        ///https://dotnetcoretutorials.com/2019/12/09/reading-excel-files-in-net-core/
        ///https://github.com/ExcelDataReader/ExcelDataReader/issues/300
        public static DataSet ReadExcel(string filePath)
        {
            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    return result;
                }
            }
        }
        private static DataSet ReadText(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
