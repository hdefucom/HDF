using System.Windows;
using System.Windows.Interop;

namespace HDF.Test.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(this);


            var source = PresentationSource.FromVisual(this.label1) as HwndSource;




        }
    }
}
