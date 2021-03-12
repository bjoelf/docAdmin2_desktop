using Xunit;
using docAdmin2_desktop.Fortnox;
using System.Diagnostics;


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



    }
}
