using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBDesk.Selenium.Extension
{
    public static class ExtensionMethods
    {
        #region IWebElement Extension Methods

        public static IWebElement FindElementById(this IWebElement element, string id, bool throwExceptionIfNotFound = false)
        {
            return FindElement(element, FindBy.Id, id, throwExceptionIfNotFound);
            //IWebElement result = null;
            //if (element != null && !string.IsNullOrWhiteSpace(id))
            //{
            //    try
            //    {
            //        result = element.FindElement(By.Id(id));
            //    }
            //    catch (NoSuchElementException ex1)
            //    {
            //        if (throwExceptionIfNotFound == true)
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

        public static IWebElement FindElementByClassName(this IWebElement element, string className, bool throwExceptionIfNotFound = false)
        {
            return FindElement(element, FindBy.ClassName, className, throwExceptionIfNotFound);
            //IWebElement result = null;
            //if (element != null && !string.IsNullOrWhiteSpace(className))
            //{
            //    try
            //    {
            //        result = element.FindElement(By.ClassName(className));
            //    }
            //    catch (NoSuchElementException ex1)
            //    {
            //        if (throwExceptionIfNotFound == true)
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

        public static IWebElement FindElementByCssSelector(this IWebElement element, string className, bool throwExceptionIfNotFound = false)
        {
            return FindElement(element, FindBy.CssSelector, className, throwExceptionIfNotFound);
        }

        public static IWebElement FindElement(this IWebElement element, FindBy by, string item, bool throwExceptionIfNotFound = false)
        {
            IWebElement result = null;
            if (element != null && !string.IsNullOrWhiteSpace(item))
            {
                try
                {
                    switch (by)
                    {
                        case FindBy.ClassName:
                            {
                                result = element.FindElement(By.ClassName(item));
                                break;
                            }
                        case FindBy.CssSelector:
                                {
                                    result = element.FindElement(By.CssSelector(item));
                                    break;
                                }
                        case FindBy.Id:
                                {
                                    result = element.FindElement(By.Id(item));
                                    break;
                                }
                        case FindBy.LinkText:
                                {
                                    result = element.FindElement(By.LinkText(item));
                                    break;
                                }
                        case FindBy.Name:
                                {
                                    result = element.FindElement(By.Name(item));
                                    break;
                                }
                        case FindBy.PartialLinkText:
                                {
                                    result = element.FindElement(By.PartialLinkText(item));
                                    break;
                                }
                        case FindBy.TagName:
                                {
                                    result = element.FindElement(By.TagName(item));
                                    break;
                                }
                        case FindBy.XPath:
                                {
                                    result = element.FindElement(By.XPath(item));
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

        public static ReadOnlyCollection<IWebElement> FindElements(this IWebElement element, FindBy by, string item, bool throwExceptionIfNotFound = false)
        {
            ReadOnlyCollection<IWebElement> result = null;
            if (element != null && !string.IsNullOrWhiteSpace(item))
            {
                try
                {
                    switch (by)
                    {
                        case FindBy.ClassName:
                            {
                                result = element.FindElements(By.ClassName(item));// .FindElement(By.ClassName(item));
                                break;
                            }
                        case FindBy.CssSelector:
                            {
                                result = element.FindElements(By.CssSelector(item));
                                break;
                            }
                        case FindBy.Id:
                            {
                                result = element.FindElements(By.Id(item));
                                break;
                            }
                        case FindBy.LinkText:
                            {
                                result = element.FindElements(By.LinkText(item));
                                break;
                            }
                        case FindBy.Name:
                            {
                                result = element.FindElements(By.Name(item));
                                break;
                            }
                        case FindBy.PartialLinkText:
                            {
                                result = element.FindElements(By.PartialLinkText(item));
                                break;
                            }
                        case FindBy.TagName:
                            {
                                result = element.FindElements(By.TagName(item));
                                break;
                            }
                        case FindBy.XPath:
                            {
                                result = element.FindElements(By.XPath(item));
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
                if (throwExceptionIfNotFound == true)
                {
                    if(result == null)
                    {
                        throw new NoSuchElementException();
                    }
                    else if(result.Count == 0)
                    {
                        throw new NoSuchElementException();
                    }
                }
            }
            return result;
        }

        #endregion
    }
}
