using System;
using System.Collections;
using System.IO;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Framework.Helper
{
    public class General
    {
        public static int Random(int from, int to)
        {
            return new Random().Next(from, to);
        }

        public static string GetCurrentDate(string format, string addDays = "0")
        {
            return DateTime.Today.AddDays(Convert.ToDouble(addDays)).ToString(format);
        }

        public static void ScrollTo(IWebDriver driver, IWebElement element)
        {
            ((IJavaScriptExecutor) driver).ExecuteScript("arguments[0].scrollIntoView(true); ", element);
            Thread.Sleep(500);
        }

        public static string TakeScreenshot(IWebDriver driver)
        {
            var dateTime = GetCurrentDate("yyyy-MM-dd");
            var testName = TestContext.CurrentContext.Test.Name;
            var screenshotPath = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "Screenshots");

            if (!Directory.Exists(screenshotPath + "\\" + dateTime))
            { Directory.CreateDirectory(screenshotPath + "\\" + dateTime); }

            var tempo = string.Format("{0:yyyy-MM-dd-hh-mm-ss}", DateTime.Now);
            var fileName = screenshotPath + "\\" + dateTime + "\\" + tempo + "-" + testName + ".png";

            ((ITakesScreenshot) driver).GetScreenshot().SaveAsFile(fileName, ScreenshotImageFormat.Png);

            return fileName;
        }

        public static IEnumerable ReadCSVFile(string csvPath)
        {
            using (StreamReader sr = new StreamReader(csvPath, System.Text.Encoding.GetEncoding(1252)))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    ArrayList result = new ArrayList();
                    result.AddRange(line.Split(';'));
                    yield return result;
                }
            }
        }

        public static int Parallelism(string key)
        {
         return    1;
        }
    }
}
