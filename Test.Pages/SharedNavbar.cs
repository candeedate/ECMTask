using Base.BasePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    public class SharedNavbar : BasePage
    {
        public SharedNavbar(IWebDriver driver) : base(driver)
        {
        }

        //
        // Locators
        //
        public readonly By linkHome = By.LinkText("Home");
        public readonly By linkLogout = By.LinkText("Logout");

        //
        // Page Object methods
        //
        public void ClickHomeLink()
        {
            ClickElement(linkHome);
        }

        public void ClickLogoutLink()
        {
            ClickElement(linkLogout);
        }

        public bool CheckIfLogoutLinkIsVisible(int timeOut=10)
        {
            return CheckIfElementIsVisible(linkLogout, timeOut);
        }
    }
}
