using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
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

        #region Find Element Methods

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
    }
}
