using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Annoying
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnSend.Click += BtnSend_ClickAsync;
        }

        private async void BtnSend_ClickAsync(object sender, RoutedEventArgs e)
        {
            var textMessage = txtMessage.Text;
            var punctuation = textMessage.Where(Char.IsPunctuation).Distinct().ToArray();
            var words = textMessage.Split().Select(x => x.Trim(punctuation));

            await Task.Delay(3000);
            foreach (var item in words)
            {
                SendKeys.SendWait(item);
                SendKeys.SendWait("{Enter}");
                await Task.Delay(1000);
            }
        }
    }
}
