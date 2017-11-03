using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordpressAutomation;

namespace WordpressTest
{
    [TestClass]
    public class PageTest
    {
        [TestInitialize]
        public void Init()
        {
            Driver.Initialize();
        }

        [TestMethod]
        public void Can_Edit_A_Page()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs("user").WithPassword("Password1").Login();

            ListPostPage.GoTo(PostType.Page);
            ListPostPage.SelectPost("Sample Page");

            Assert.IsTrue(NewPostPage.IsInEditMode(), "Wasn't in edit Mode");
            Assert.AreEqual("Sample Page", NewPostPage.Title, "Title did not match");
           
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }
    }
}
