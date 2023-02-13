using BinaryFile.VM;
using System.Windows.Controls;

namespace BinaryFile.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            BinaryVM vm = new();
            this.DataContext= vm;
            InitializeComponent();
        }
    }
}
