using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Test.Pages;

namespace Test.AddressEnrichment.Task_ID1_RecruitmentTask
{
    public partial class Tests
    {
        public PageLogin pLogin;
        public PageHome pHome;
        public PageGoogleAuthentication pGoogleAuthentication;
        public SharedNavbar sNavbar;

        [OneTimeSetUp]
        public void SetupClass()
        {
            pLogin = new PageLogin(driver);
            pHome = new PageHome(driver);
            pGoogleAuthentication = new PageGoogleAuthentication(driver);
            sNavbar = new SharedNavbar(driver);
        }

        [SetUp]
        public void SetupMethod()
        {
            // Get Login Page at the beginning of each test case
            driver.Navigate().GoToUrl(pLogin.pageURL);
        }
    }
}
