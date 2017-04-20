using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using mshtml;
using SHDocVw;


namespace WpfApplication
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void ContentClick(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("On Content Click.");

            SHDocVw.ShellWindows shellWindows = new SHDocVw.ShellWindows();
            //遍历所有选项卡
            foreach (SHDocVw.InternetExplorer Browser in shellWindows)
            {
                if (Browser.LocationURL.Contains("www.baidu.com"))
                {
                    mshtml.IHTMLDocument2 doc2 = (mshtml.IHTMLDocument2)Browser.Document;
                    mshtml.IHTMLElementCollection inputs = (mshtml.IHTMLElementCollection)doc2.all.tags("INPUT");
                    mshtml.HTMLInputElement input1 = (mshtml.HTMLInputElement)inputs.item("kw", 0);
                    input1.value = "刘德华";
                    mshtml.IHTMLElement element2 = (mshtml.IHTMLElement)inputs.item("su", 0);
                    element2.click();
                }
            }
        }
    }
}
