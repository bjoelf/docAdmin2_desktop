using System.IO;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Data;
using docAdmin2_desktop.Data;
using docAdmin2_desktop.Model;


namespace docAdmin2_desktop.Test.Model
{
    public class FileProcessorTests
    {
        [Fact]
        public void ReadExcel()
        {
            string path = @"C:\Users\Björn\Google Drive\Företag och affärsidéer\DOC\Kunder\Aleris\";
            path = path + @"Granskning Feb 2021 Röntgen Aleris Närsjukhus.xlsx";

            DataSet ds = FileProcessor.ReadExcel(path);

            Assert.NotNull(ds);
        }
        [Fact]
        public void ReadFile()
        {
            string path = @"C:\Users\Björn\Google Drive\Företag och affärsidéer\DOC\Kunder\Aleris\";
            path = path + @"Granskning Feb 2021 Röntgen Aleris Närsjukhus.xlsx";

            DataSet ds = FileProcessor.ReadFile(path);
            Assert.NotNull(ds);
        }
        [Fact]
        public void GetExams()
        {
            string path = @"C:\Users\Björn\Google Drive\Företag och affärsidéer\DOC\Kunder\Aleris\";
            path = path + @"Granskning Feb 2021 Röntgen Aleris Närsjukhus.xlsx";
            
            DataSet ds = FileProcessor.ReadFile(path);
            ClientSettingsModel csm = ClientSettingsController.Retrive(1);

            List<ExamModel> ems = FileProcessor.GetExams(ds,csm);
            Assert.NotNull(ems);
        }
        [Fact]
        public void Process()
        {

        }

    }
}
