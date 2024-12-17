using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Input;

namespace Lesson6Wpf;

enum ListEnum { One, Two, Three }

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        //listBox.Items.Clear();
        //for (int i = 0; i < 10; ++i)
         //   listBox.Items.Add(new ListBoxItem() { Content = "בום " + i });
        listBox.ItemsSource = Enum.GetValues(typeof(ListEnum));
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

    int _counter = 0;
    private void btn_OK_Click(object sender, RoutedEventArgs e)
    {
        Button btn = (sender as Button)!;
        btn.Content = "בסדר גמור " + ++_counter;
    }

    private void CheckBox_Checked(object sender, RoutedEventArgs e)
    {

    }

    private void btn_OK_LostFocus(object sender, RoutedEventArgs e)
    {
        Button btn = (sender as Button)!;
        btn.Background = Brushes.Beige;
    }

    private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
    {

    }

}