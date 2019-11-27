using Base.BasePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    public class PageGoogleAuthentication : BasePage
    {
        public PageGoogleAuthentication(IWebDriver driver) : base(driver)
        {
        }

        //
        // Locators
        //
        public readonly By textboxEmailAddress = By.Name("identifier");
        public readonly By textboxPassword = By.Name("password");
        public readonly By buttonNextAfterEmail = By.Id("identifierNext");
        public readonly By buttonNextAfterPassword = By.Id("passwordNext");

        //
        // Page Object methods
        //
        public void EnterEmailAddress(string emailAddress)
        {
            EnterText(textboxEmailAddress, emailAddress);
        }

        public void EnterPassword(string password)
        {
            EnterText(textboxPassword, password);
        }

        public void ClickNextButtonAfterEmail()
        {
            ClickElement(buttonNextAfterEmail);
        }

        public void ClickNextButtonAfterPassword()
        {
            ClickElement(buttonNextAfterPassword);
        }
    }
}
