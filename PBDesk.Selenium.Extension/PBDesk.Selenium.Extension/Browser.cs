using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBDesk.Selenium.Extension
{
    public class Browser
    {
        private IWebDriver _instance;

        public Browser()
        {
            _instance = new FirefoxDriver();
        }

        public Browser(SupportedBrowsers browser)
        {
            switch (browser)
            {
                case SupportedBrowsers.IE:
                    {
                        _instance = new InternetExplorerDriver(ConfigurationManager.AppSettings["IEDriverLocation"]);
                        break;
                    }
                case SupportedBrowsers.Chrome:
                    {
                        _instance = new ChromeDriver(ConfigurationManager.AppSettings["ChromeDriverLocation"]);
                        break;
                    }
                default:
                    {
                        _instance = new FirefoxDriver();
                        break;
                    }
            }
        }

        public IWebDriver Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }

        public void Close()
        {
            if (_instance != null)
            {
                _instance.Close();
            }
        }

        public void Maximize()
        {
            if (_instance != null)
            {
                _instance.Manage().Window.Maximize();
            }
        }

        public void ImplicitlyWait(int seconds)
        {
            if (_instance != null)
            {
                _instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
            }

        }

        #region Cookie Related Methods
        public bool IsCookiePresent(string cookieName)
        {
            bool result = false;
            if (_instance != null && !string.IsNullOrEmpty(cookieName))
            {
                result = _instance.Manage().Cookies.GetCookieNamed(cookieName) != null;
            }
            return result;
        }

        public string GetCookieValue(string cookieName)
        {
            if (IsCookiePresent(cookieName))
            {
                return _instance.Manage().Cookies.GetCookieNamed(cookieName).Value;
            }
            else
                return null;
        }

        #endregion

        #region Find Element Methods

        public ReadOnlyCollection<IWebElement> FindElements(FindBy by, string identifier, bool throwExceptionIfNotFound = false)
        {
            ReadOnlyCollection<IWebElement> result = null;
            if (_instance != null && !string.IsNullOrWhiteSpace(identifier))
            {
                try
                {
                    switch (by)
                    {
                        case FindBy.ClassName:
                            {
                                result = _instance.FindElements(By.ClassName(identifier));
                                break;
                            }
                        case FindBy.CssSelector:
                            {
                                result = _instance.FindElements(By.CssSelector(identifier));
                                break;
                            }
                        case FindBy.Id:
                            {
                                result = _instance.FindElements(By.Id(identifier));
                                break;
                            }
                        case FindBy.LinkText:
                            {
                                result = _instance.FindElements(By.LinkText(identifier));
                                break;
                            }
                        case FindBy.Name:
                            {
                                result = _instance.FindElements(By.Name(identifier));
                                break;
                            }
                        case FindBy.PartialLinkText:
                            {
                                result = _instance.FindElements(By.PartialLinkText(identifier));
                                break;
                            }
                        case FindBy.TagName:
                            {
                                result = _instance.FindElements(By.TagName(identifier));
                                break;
                            }
                        case FindBy.XPath:
                            {
                                result = _instance.FindElements(By.XPath(identifier));
                                break;
                            }
                    }

                }
                catch (NoSuchElementException ex1)
                {
                    if (throwExceptionIfNotFound == true)
                    {
                        throw ex1;
                    }
                    result = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }

        public IWebElement FindElement(FindBy by, string item, bool throwExceptionIfNotFound = false)
        {
            IWebElement result = null;
            if (_instance != null && !string.IsNullOrWhiteSpace(item))
            {
                try
                {
                    switch (by)
                    {
                        case FindBy.ClassName:
                            {
                                result = _instance.FindElement(By.ClassName(item));
                                break;
                            }
                        case FindBy.CssSelector:
                            {
                                result = _instance.FindElement(By.CssSelector(item));
                                break;
                            }
                        case FindBy.Id:
                            {
                                result = _instance.FindElement(By.Id(item));
                                break;
                            }
                        case FindBy.LinkText:
                            {
                                result = _instance.FindElement(By.LinkText(item));
                                break;
                            }
                        case FindBy.Name:
                            {
                                result = _instance.FindElement(By.Name(item));
                                break;
                            }
                        case FindBy.PartialLinkText:
                            {
                                result = _instance.FindElement(By.PartialLinkText(item));
                                break;
                            }
                        case FindBy.TagName:
                            {
                                result = _instance.FindElement(By.TagName(item));
                                break;
                            }
                        case FindBy.XPath:
                            {
                                result = _instance.FindElement(By.XPath(item));
                                break;
                            }
                    }

                }
                catch (NoSuchElementException ex1)
                {
                    if (throwExceptionIfNotFound == true)
                    {
                        throw ex1;
                    }
                    result = null;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return result;
        }


        public IWebElement FindElementByClassName(string id, bool throwExceptionIfNotFound = false)
        {
            return FindElement(FindBy.ClassName, id, throwExceptionIfNotFound);
        }
        public IWebElement FindElementByCssSelector(string id, bool throwExceptionIfNotFound = false)
        {
            return FindElement(FindBy.CssSelector, id, throwExceptionIfNotFound);
        }
        public IWebElement FindElementById(string id, bool throwExceptionIfNotFound = false)
        {
            return FindElement(FindBy.Id, id, throwExceptionIfNotFound);
            //IWebElement result = null;
            //if (_instance != null && !string.IsNullOrWhiteSpace(id))
            //{
            //    try
            //    {
            //        result = _instance.FindElement(By.Id(id));
            //    }
            //    catch (NoSuchElementException ex1)
            //    {
            //        if(throwExceptionIfNotFound == true)
            //        {
            //            throw ex1;
            //        }
            //        result = null;
            //    }
            //    catch (Exception ex)
            //    {
            //        throw ex;
            //    }
            //}
            //return result;
        }

        #endregion

        #region Element Interaction Methods

        public bool SetText(FindBy by, string item, string textToSet, bool throwExceptionIfNotFound = false )
        {
            bool result = false;
            var element = FindElement(by, item,throwExceptionIfNotFound);
            if (element != null)
            {
                element.Clear();
                element.SendKeys(textToSet);
                result = true;
            }
            return result;
        }

        public bool SetTextForId(string elementId, string text, bool throwExceptionIfNotFound = false)
        {
            return SetText(FindBy.Id, elementId, text, throwExceptionIfNotFound);
            //var element = FindElementById(elementId);
            //if (element != null)
            //{
            //    element.Clear();
            //    element.SendKeys(text);
            //}
        }

        public bool SelectElementByIndex(FindBy by, string item, int valToSet, bool throwExceptionIfNotFound = false)
        {
            bool result = false;
            var element = FindElement(by, item, throwExceptionIfNotFound);
            if (element != null)
            {
                new SelectElement(element).SelectByIndex(valToSet);
                result = true;
            }
            return result;
        }

        public bool SelectElementByText(FindBy by, string item, string valToSet, bool throwExceptionIfNotFound = false)
        {
            bool result = false;
            var element = FindElement(by, item, throwExceptionIfNotFound);
            if (element != null)
            {
                new SelectElement(element).SelectByText(valToSet);
                result = true;
            }
            return result;
        }

        public bool SelectElementByValue(FindBy by, string item, string valToSet, bool throwExceptionIfNotFound = false)
        {
            bool result = false;
            var element = FindElement(by, item, throwExceptionIfNotFound);
            if (element != null)
            {
                new SelectElement(element).SelectByValue(valToSet);
                result = true;
            }
            return result;
        }

        public bool ClickElement(FindBy by, string identifier, bool throwExceptionIfNotFound = false)
        {
            bool result = false;
            var element = FindElement(by, identifier, throwExceptionIfNotFound);
            if (element != null)
            {
                element.Click();
                result = true;
            }
            return result;
        }

        public bool ClickById(string identifier, bool throwExceptionIfNotFound = false)
        {
            return ClickElement(FindBy.Id, identifier, throwExceptionIfNotFound);
        }

        public bool ClickByClassName(string identifier, bool throwExceptionIfNotFound = false)
        {
            return ClickElement(FindBy.ClassName, identifier, throwExceptionIfNotFound);
        }

        public bool ClickByCssSelector(string identifier, bool throwExceptionIfNotFound = false)
        {
            return ClickElement(FindBy.CssSelector, identifier, throwExceptionIfNotFound);
        }

        #endregion
    }
}
