using System.Diagnostics;

using Xunit;

using docAdmin2_desktop.Fortnox;
using docAdmin2_desktop.Data;
using docAdmin2_desktop.Model;

namespace docAdmin2_desktop.Test.Data
{
    public class ClientSettingsControllerTests
    {
        [Fact]
        public void GetCustomerComment()
        {
            string com = FortnoxStuff.GetCustomerComment(1);
            Debug.Print(com);
            Assert.True(com.Length > 0);
        }
        [Fact]
        public void FortnoxFieldToJSON()
        {
            string com = @"('ExamToArticle':('Elective':('CO':'KOELMF','CT':'DTELMF','CT2':'DT2ELMF','MR':'MRELMF','M2':'MR2ELMF'),'Acute':('CO':'KOAKMF','CT':'DTAKMF','CT2':'DT2AKMF','MR':'MRAKMF','M2':'MR2AKMF'),'Jour':('CO':'KOJOMF','CT':'DTJOMF','CT2':'DT2JOMF','MR':'MRJOMF','M2':'MR2JOMF')),'Doctors':&('Sign':'SVEVA20','Type':'SUPP','Number':'1'),('Sign':'JONOL20','Type':'SUPP','Number':'13')%,'ExamType':('3':'CO','6':'CO','8':'CT','8_':'CT2','M':'MR','M2':'MR2'),'Priority':('0':'Elective','-1':'Acute','99':'Jour'),'FileFormat':('extension':'xlsx','table':'DOC','col_signdoc':'1','col_prio':'4','col_type':'3','index_examtype':'2'))";
            string json = FortnoxStuff.FortnoxToJSON(com);
            
            Assert.False(json.Contains('&'));
            Assert.False(json.Contains('%'));
            Assert.False(json.Contains('('));
            Assert.False(json.Contains(')'));
        }

        [Fact]
        public void JSONtoFortnoxFormat()
        {
            string json = @"{'ExamToArticle':{'Elective':{'CO':'KOELMF','CT':'DTELMF','CT2':'DT2ELMF','MR':'MRELMF','M2':'MR2ELMF'},'Acute':{'CO':'KOAKMF','CT':'DTAKMF','CT2':'DT2AKMF','MR':'MRAKMF','M2':'MR2AKMF'},'Jour':{'CO':'KOJOMF','CT':'DTJOMF','CT2':'DT2JOMF','MR':'MRJOMF','M2':'MR2JOMF'}},'Doctors':[{'Sign':'SVEVA20','Type':'SUPP','Number':'1'},{'Sign':'JONOL20','Type':'SUPP','Number':'13'}],'ExamType':{'3':'CO','6':'CO','8':'CT','8_':'CT2','M':'MR','M2':'MR2'},'Priority':{'0':'Elective','-1':'Acute','99':'Jour'},'FileFormat':{'extension':'xlsx','table':'DOC','col_signdoc':'1','col_prio':'4','col_type':'3','index_examtype':'2'}}";
            string fnox = FortnoxStuff.JSONtoFortnox(json);

            Assert.False(fnox.Contains('{'));
            Assert.False(fnox.Contains('}'));
            Assert.False(fnox.Contains(']'));
            Assert.False(fnox.Contains('['));
        }

        [Fact]
        public void ParseJsonStringToClientSettingsModel()
        {
            ClientSettingsModel csm = ClientSettingsController.Retrive(1);
            Debug.Print(csm.ToString());
            Assert.True(true);
        }

        [Fact]
        public void BestInTest()
        {
            Assert.True(true);
        }
    }
}
