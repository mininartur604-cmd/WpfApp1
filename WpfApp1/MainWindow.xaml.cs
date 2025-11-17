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

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private double firstnum;
    private double secondnum;
    private double result;
    private void Plus_Click(object sender, RoutedEventArgs e)
    {
        firstnum = Convert.ToDouble(Frst.Text);
        secondnum = Convert.ToDouble(Scnd.Text);
        result = firstnum + secondnum;
        Rslt.Text = result.ToString();
        znak.Text = "+";
    }

    private void Minus_Click(object sender, RoutedEventArgs e)
    {

        firstnum = Convert.ToDouble(Frst.Text);
        secondnum = Convert.ToDouble(Scnd.Text);
        result = firstnum - secondnum;
        Rslt.Text = result.ToString();
        znak.Text = "-";
    }
    private void umnosh_Click(object sender, RoutedEventArgs e)
    {

        firstnum = Convert.ToDouble(Frst.Text);
        secondnum = Convert.ToDouble(Scnd.Text);
        result = firstnum * secondnum;
        Rslt.Text = result.ToString();
        znak.Text = "*";
    }

    private void del_Click(object sender, RoutedEventArgs e)
    {

        firstnum = Convert.ToDouble(Frst.Text);
        secondnum = Convert.ToDouble(Scnd.Text);
        znak.Text = "/";
        switch (secondnum)
        {
            case 0: 
                Rslt.Text = "На ноль делить нельзя";
            break;

            default: result = firstnum / secondnum; Rslt.Text = result.ToString(); break;
        }
       
    }
    private void step_Click(object sender, RoutedEventArgs e)
    {
        firstnum = Convert.ToDouble(Frst.Text);
        secondnum = Convert.ToDouble(Scnd.Text);
        result = Math.Pow(firstnum, secondnum);
        Rslt.Text = result.ToString();
        znak.Text = "^";
    }
    private void kor_Click(object sender, RoutedEventArgs e)
    {
        firstnum = Convert.ToDouble(Frst.Text);
        secondnum = Convert.ToDouble(Scnd.Text);
        result = Math.Pow(firstnum, 1/secondnum);
        Rslt.Text = result.ToString();
        znak.Text = "корень";
    }

   

   
}