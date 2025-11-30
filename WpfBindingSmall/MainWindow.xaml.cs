using System;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf5785;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        btnText = "Israel";
        InitializeComponent();
        //this.btnOK.IsEnabled = false;
    }

    public MyData MyObject { get; set; } = new() { User = "David", Password = "654321" };

    static readonly DependencyProperty btnTextProperty =
        DependencyProperty.Register(nameof(btnText), typeof(string), typeof(MainWindow));
    public string btnText
    {
        get => (string)GetValue(btnTextProperty);
        set => SetValue(btnTextProperty, value);
    }

    private static readonly Random _random = new();
    private void btn_OK_MouseMove(object sender, MouseEventArgs e)
    {
        Button btn = (sender as Button)!;
        Size size = (btn.Parent as Grid)!.RenderSize;
        Thickness margin = btn.Margin;
        margin.Left = _random.NextDouble() * (size.Width - btn.ActualWidth);
        margin.Top = _random.NextDouble() * (size.Height - btn.ActualHeight);
        btn.Margin = margin;
    }

    bool check = true;

    private void btnOK_Click(object sender, RoutedEventArgs e)
    {
        MyObject.User = check ? "Meir" : "David";
        btnText = check ? "Yaakov" : "Israel";
        check = !check;
    }

    private void btnOK_Double(object sender, MouseButtonEventArgs e)
    {

    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {

    }
}