using System;
using System.Windows;

namespace HDF.Test.WPF;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        SplashScreen splashScreen = new SplashScreen("%e6%96%b0%e6%96%87%e4%bb%b6%e5%a4%b9/splashscreen1.png");
        splashScreen.Show(true);


        App app = new App();
        app.InitializeComponent();
        app.Run();

    }
}
