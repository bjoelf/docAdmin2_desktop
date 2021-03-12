using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
using System.Data;
using docAdmin2_desktop.Model;

namespace docAdmin2_desktop.Data
{
    class FileProcessor
    {
        public static List<ExamModel> Process(string filepath, ClientSettingsModel csm)
        {
            List<ExamModel> Exams = new List<ExamModel>();
            DataSet ds = new DataSet();

            string fileEnding = csm.FileFormat.Extension;
            switch (fileEnding)
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

            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    ExamModel exam = new ExamModel();

                    //TODO: Implement DataSet to ExamModel loop



                    Exams.Add(exam);
                }
            }

            return Exams;
        }
        ///Read excel and return object.
        ///https://dotnetcoretutorials.com/2019/12/09/reading-excel-files-in-net-core/
        ///https://github.com/ExcelDataReader/ExcelDataReader/issues/300
        private static DataSet ReadExcel(string filePath)
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
