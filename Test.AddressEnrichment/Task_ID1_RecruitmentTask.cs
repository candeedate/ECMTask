using Base.BaseTest;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using Test.Pages;

namespace Test.AddressEnrichment.Task_ID1_RecruitmentTask
{
    public partial class Tests : BaseTest
    {
        [Test]
        public void TC_ID11_AuthenticatedUser()
        {

            // --- STEP 1 ---
            Assert.AreEqual(expected: true,
                            actual: pLogin.CheckIfSignInWithGoogleButtonIsVisible(),
                            message: "Button 'Sign In With Google' is not visible for user");

            // --- STEP 2 ---
            pLogin.ClickSignInWithGoogleButton();
            Assert.AreEqual(expected: "accounts.google.com",
                            actual: pLogin.GetDomain(),
                            message: "Google Authentication Login page has not been opened (domain is not correct)");

            // --- STEP 3 ---
            pGoogleAuthentication.EnterEmailAddress("firsttesterlast@gmail.com");
            pGoogleAuthentication.ClickNextButtonAfterEmail();
            pGoogleAuthentication.EnterPassword("zmalqp10");
            pGoogleAuthentication.ClickNextButtonAfterPassword();
            sNavbar.ClickHomeLink(); // TO DELETE - DELIVERED.IO EMAIL NEEDED

            Assert.AreEqual(expected: pHome.pageURL,
                            actual: pHome.GetURL(),
                            message: "Home Page has not been opened - URL is wrong");

            Assert.IsTrue(condition: pHome.CheckIfAddressTextboxIsVisible(),
                          message: "Textarea for address data is not visible on home page");

            // --- STEP 4 ---
            pHome.EnterAddress("Scaleworks Inc, 118 Broadway Suite 627 San Antonio, TX 78205");
            pHome.ClickSubmitButton();

            Assert.IsTrue(condition: pHome.CheckIfAddressLabelIsVisible(),
                          message: "Check if Addresses: label (results) is visible");

            Assert.IsTrue(condition: pHome.CheckIfContactInfoLabelIsVisible(),
                          message: "Check if Contact info: label (results) is visible");
        }

        [Test]
        public void TC_ID12_GoogleAuthenticationWithWrongDomain()
        {
            // --- PRECONDITIONS ---
            pLogin.ClickSignInWithGoogleButton();

            // --- STEP 1 ---
            pGoogleAuthentication.EnterEmailAddress("firsttesterlast@gmail.com");
            pGoogleAuthentication.ClickNextButtonAfterEmail();
            pGoogleAuthentication.EnterPassword("zmalqp10");
            pGoogleAuthentication.ClickNextButtonAfterPassword();

            Assert.IsTrue(condition: pLogin.CheckIfNotAllowedErrorLabelIsVisible(),
                          message: "Proper error message has not been displayed for user with not @delivered.io email");
            

            // --- STEP 2 ---
            sNavbar.ClickHomeLink();

            Assert.AreEqual(expected: pLogin.pageURL,
                            actual: pLogin.GetURL(),
                            message: "Non-authorized user clicks on the Home Page link and is no more on the Login Page");
        }

        [Test]
        public void TC_ID13_ProtectedLogoutInterface()
        {
            // --- STEP 1 ---
            Assert.IsFalse(condition: sNavbar.CheckIfLogoutLinkIsVisible(timeOut: 3),
                           message: "Logout link in navbar is visible for not authorized user");

            // --- STEP 2 ---
            pGoogleAuthentication.EnterEmailAddress("firsttesterlast@gmail.com"); // TO REPLACE - DELIVERED.IO EMAIL NEEDED
            pGoogleAuthentication.ClickNextButtonAfterEmail();
            pGoogleAuthentication.EnterPassword("zmalqp10");
            pGoogleAuthentication.ClickNextButtonAfterPassword();
            sNavbar.ClickHomeLink(); // TO DELETE - DELIVERED.IO EMAIL NEEDED

            Assert.IsTrue(condition: sNavbar.CheckIfLogoutLinkIsVisible(),
                           message: "Logout link in navbar is not visible for authorized user");

            // --- STEP 3 ---
            sNavbar.ClickLogoutLink();

            Assert.AreEqual(expected: pLogin.pageURL,
                            actual: pLogin.GetURL(),
                            message: "User has not been directed to login page after logout");

            Assert.IsFalse(condition: sNavbar.CheckIfLogoutLinkIsVisible(timeOut: 3),
                           message: "Logout link in navbar is visible for not authorized user (after logout)");
        }
    }
}