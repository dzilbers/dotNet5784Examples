using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfBinding;

//Drone drone = new Drone();
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static string MyName { get; set; } = "Next1";
    public MyData MyObject { get; set; } = new MyData() { User = "Adina", Password = "Efrat" };
    public Items MyItems { get; set; } = new();
    public Levels Level { get; set; } = Levels.Beginner;

    public static readonly DependencyProperty ShowProperty =
        DependencyProperty.Register(nameof(ShowLevel), typeof(Levels), typeof(MainWindow));
    public Levels ShowLevel
    {
        get => (Levels)GetValue(ShowProperty);
        set => SetValue(ShowProperty, value);
    }

    public MainWindow() => InitializeComponent();

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var brush = (LinearGradientBrush)this.Resources["myLinGradBrush"];
        brush.GradientStops[0].Color = Colors.Green;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // this.Resources["myLinGradBrush"] = new SolidColorBrush(Colors.GreenYellow);
        Application.Current.Resources["myLinGradBrush"] = new SolidColorBrush(Colors.GreenYellow);
        // Brush brush = this.TryFindResource("myLinGradBrush") as Brush;
    }

    private void btnNext2_Click(object sender, RoutedEventArgs e)
    {
        string str = (String)btnNext2.Content;
        btnNext2.Content = str.Length > 0 ? str.Substring(1) : "I am still here!";
    }

    private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        ShowLevel = Level;
    }
}
