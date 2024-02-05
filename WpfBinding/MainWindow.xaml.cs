using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfBinding
{
    //Drone drone = new Drone();
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string MyName { get; set; } = "Next1";
        public MyData MyObject { get; set; } = new MyData() { User = "Adina", Password = "Efrat" };


        public MainWindow() => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var brush = (LinearGradientBrush)this.Resources["myLinGradBrush"];
            brush.GradientStops[0].Color = Colors.Green;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Resources["myLinGradBrush"] = new SolidColorBrush(Colors.GreenYellow);
        }

        private void btnNext2_Click(object sender, RoutedEventArgs e)
        {
            string str = (String)btnNext2.Content;
            btnNext2.Content = str.Length > 0 ? str.Substring(1) : "I am still here!";
        }
    }
}
