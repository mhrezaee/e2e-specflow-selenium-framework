using System.Collections.Generic;
using System.Linq;

namespace CalculatorSelenium.Specs
{
    public class Config
    {
        //public static int ShortWait => int.Parse(AppSettings.Get("wait:short"));
        public static int ShortWait => 3;
        //public static int NormalWait => int.Parse(AppSettings.Get("wait:normal"));
        public static int NormalWait => 30;
        //public static int LongWait => int.Parse(AppSettings.Get("wait:long"));
        public static int LongWait => 90;
        //public static string BasePath => AppSettings.Get("path:base");
        public static string BasePath => "https://specflowoss.github.io/";
        //public static List<string> ChromeArguments => AppSettings.Get("chrome:arguments").Split(' ').ToList();
        public static List<string> ChromeArguments => "window-size=1920,1080 start-maximized headless no-sandbox disable-gpu".Split(' ').ToList();

        //public static Environments Environment => (Environments)int.Parse(AppSettings.Get("environment"));
        public static Environments Environment => Environments.Development;

        //public static string WebDriver => AppSettings.Get("e2e:webdriver");
        public static string WebDriver => "chrome";
        public enum Environments
        {
            Development = 0,
            CI = 1
        }
    }
}