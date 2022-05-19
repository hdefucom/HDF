using System;

namespace HDF.Test.WPF;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {

        App app = new App();
        app.InitializeComponent();
        app.Run();

    }
}
