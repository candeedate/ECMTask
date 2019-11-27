using Base.BasePage;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Pages
{
    public class PageHome : BasePage
    {
        public PageHome(IWebDriver driver) : base(driver)
        {
        }

        //
        // Page data
        //
        public readonly string pageURL = "http://addressenrichment.azurewebsites.net/";

        //
        // Locators
        //
        public readonly By textboxAddress = By.Id("inputText");
        public readonly By buttonSubmit = By.Id("submitText");
        public readonly By labelAddresses = By.XPath("//div[@id='results']/table[1]//th[text()='Addresses:']");
        public readonly By labelContactInfo = By.XPath("//div[@id='results']/table[2]//th[text()='Contact info:']");

        //
        // Page Object methods
        //
        public bool CheckIfAddressTextboxIsVisible(int timeOut=10)
        {
            return CheckIfElementIsVisible(textboxAddress, timeOut);
        }

        public void EnterAddress(string address)
        {
            EnterText(textboxAddress, address);
        }

        public void ClickSubmitButton()
        {
            ClickElement(buttonSubmit);
        }

        public bool CheckIfAddressLabelIsVisible(int timeOut = 10)
        {
            return CheckIfElementIsVisible(labelAddresses);
        }

        public bool CheckIfContactInfoLabelIsVisible(int timeOut = 10)
        {
            return CheckIfElementIsVisible(labelAddresses);
        }
    }
}
