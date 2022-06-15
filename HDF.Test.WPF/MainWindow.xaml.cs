using System;
using System.Windows;

using System.Windows.Input;
using System.Windows.Interop;

namespace HDF.Test.WPF;

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



        System.Windows.Forms.Application.EnableVisualStyles();
        winformcontrolhost.Child = new System.Windows.Forms.Button() { Text = "Hello" };


    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {

        MessageBox.Show(DateTime.Now.ToString());
    }
}

public class TestCommand : ICommand
{
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        throw new NotImplementedException();
    }

    public void Execute(object parameter)
    {
        throw new NotImplementedException();
    }
}


