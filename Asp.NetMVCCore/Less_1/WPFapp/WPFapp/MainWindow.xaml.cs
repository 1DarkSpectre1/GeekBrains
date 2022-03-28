using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
namespace WPFapp
{
    public partial class MainWindow : Window
    {
        private static int _nextNum = 0;
        private static int _currentNum = 0;
        private static int _result = 1;
        private static int _numSec;
        private static Thread fibonachi_thread;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_start(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(Num_box.Text, out _numSec) || string.IsNullOrEmpty(Num_box.Text))
            {
                MessageBox.Show("Введено некоректное число");
                return;
            }
            fibonachi_thread = new Thread(() => UpdateDataFibonachi());
            fibonachi_thread.Start();
        }
        private void Button_Click_stop(object sender, RoutedEventArgs e)
        {
            fibonachi_thread.Interrupt();
        }
        private void UpdateDataFibonachi()
        {
            while (true)
            {
                _result = _nextNum;
                if (_nextNum == 0)
                {
                    _nextNum = 1;
                }
                else
                {
                    _nextNum = _currentNum + _nextNum;
                    _currentNum = _result;
                }
                
                Application.Current.Dispatcher.InvokeAsync(() =>
                {
                    Result_box.Text = _result.ToString();
                },System.Windows.Threading.DispatcherPriority.Background);
                try
                {
                    Thread.Sleep(_numSec * 1000);
                }
                catch (System.Threading.ThreadInterruptedException)
                {
                    MessageBox.Show("Поток Остановлен");
                    return;
                }
                
            }
        }

       
    }
}
