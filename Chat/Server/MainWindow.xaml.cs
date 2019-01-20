using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Server
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const string __START = "START", __STOP = "STOP";

        private void ConsolePrint(string message)
        {
            tbConsole.AppendText($"{DateTime.Now.ToString("h:mm:ss tt")} : {message} \n");
        }

        public MainWindow()
        {
            InitializeComponent();
            tbPort.AllowDrop = false;
            btnStartStop.Content = __START;
        }

        private void TbPort_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                e.Command == ApplicationCommands.Cut ||
                e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void BtnStartStop_Click(object sender, RoutedEventArgs e)
        {
            if((string)btnStartStop.Content == __START)
            {
                tbPort.IsEnabled = false;
                btnStartStop.Content = __STOP;
            }
            else if ((string)btnStartStop.Content == __STOP)
            {
                tbPort.IsEnabled = true;
                btnStartStop.Content = __START;
            }
        }
    }
}
