using System.ComponentModel;

namespace WpfBinding;

// public class MyData : DependencyObject
public class MyData : INotifyPropertyChanged
{
    //public static readonly DependencyProperty UserProperty = DependencyProperty.Register(nameof(User),
    //    typeof(string), typeof(MyData));

    public event PropertyChangedEventHandler PropertyChanged;

    string user = "";
    public string User 
    {
        //get => (string)GetValue(UserProperty);
        //set => SetValue(UserProperty, value);
        get => user;
        set 
        {
            string old = user;
            user = value;
            if (!old.Equals(value))
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(User)));
        }
    }
    public string Password { get; set; }

}
