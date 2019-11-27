using Base.BasePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Pages
{
    public class PageLogin : BasePage
    {
        public PageLogin(IWebDriver driver) : base(driver)
        {
        }

        //
        // Page data
        //
        public readonly string pageURL = "http://addressenrichment.azurewebsites.net/Login";

        //
        // Locators
        //
        public readonly By buttonSignInWithGoogle = By.XPath("//div[@class='row']//a");
        public readonly By labelNotAllowedError = By.XPath("//div[@role='alert'][contains(text(), 'Sorry, you are not allowed to log in to this site. Please contact the administrator')]");

        //
        // Page Object methods
        //
        public bool CheckIfSignInWithGoogleButtonIsVisible()
        {
            return CheckIfElementIsVisible(buttonSignInWithGoogle);
        }

        public bool CheckIfNotAllowedErrorLabelIsVisible(int timeOut = 10)
        {
            return CheckIfElementIsVisible(labelNotAllowedError, timeOut);
        }

        public void ClickSignInWithGoogleButton()
        {
            ClickElement(buttonSignInWithGoogle);
        }

    }
}
