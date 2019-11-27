using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Base.BasePage
{
    public class BasePage
    {
        protected IWebDriver driver;
        
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement WaitForElement(By locator, int timeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IWebElement WaitForElementVisible(By locator, int timeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IWebElement WaitForElementClickable(By locator, int timeOut)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
                return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            }
            catch (Exception)
            {
                return null;
            }
        }

        public void ClickElement(By locator, int timeOut = 10)
        {
            DateTime start = DateTime.UtcNow;
            var element = WaitForElementClickable(locator, timeOut);

            while (DateTime.UtcNow - start < TimeSpan.FromSeconds(timeOut))
            {
                try 
                { 
                    element.Click();
                    break;
                }
                catch (StaleElementReferenceException) 
                { 
                    continue; 
                }
                catch (ElementClickInterceptedException) 
                { 
                    continue; 
                }
                catch (ElementNotInteractableException) 
                { 
                    continue; 
                }
                catch (Exception ex)
                { 
                    throw new Exception($"\nCannot click on the element.\nLocator: {locator}\n" +
                    $"Exception: {ex.GetType()}\nStack Trace:\n{ex.StackTrace}\nMessage:\n{ex.Message}"); 
                }
            }
        }

        public void EnterText(By locator, string text, bool clearBefore = true, int timeOut = 10)
        {
            var element = WaitForElementClickable(locator, timeOut);
            try
            {
                if (clearBefore) text = Keys.Control + "a" + Keys.Control + text;
                element.SendKeys(text);
            }
            catch (Exception)
            {
                Console.WriteLine($"Cannot send text to the element. Locator: {locator}");
            }
        }

        public bool CheckIfElementIsVisible(By locator, int timeOut = 10)
        {
            var element = WaitForElementVisible(locator, timeOut);
            if (element == null)
                return false;
            else return element.Displayed;
        }

        public string GetDomain()
        {
            try
            {
                IJavaScriptExecutor je = (IJavaScriptExecutor)driver;
                return (string)je.ExecuteScript("return document.domain");
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot get domain");
            }
            return null;
        }

        public string GetURL()
        {
            try
            {
                return driver.Url;
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot get URL");
            }
            return null;
        }
    }
}
