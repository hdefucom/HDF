using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

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



public class ZoomOnMouseWheel : Behavior<FrameworkElement>
{
    public Key? ModifierKey { get; set; } = null;
    public TransformMode TranformMode { get; set; } = TransformMode.Render;

    private Transform _transform;

    protected override void OnAttached()
    {
        if (TranformMode == TransformMode.Render)
        {
            _transform = AssociatedObject.RenderTransform = new MatrixTransform();
        }
        else
        {
            _transform = AssociatedObject.LayoutTransform = new MatrixTransform();
        }

        AssociatedObject.MouseWheel += AssociatedObject_MouseWheel;
    }

    protected override void OnDetaching()
    {
        AssociatedObject.MouseWheel -= AssociatedObject_MouseWheel;
    }

    private void AssociatedObject_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        if ((!ModifierKey.HasValue || !Keyboard.IsKeyDown(ModifierKey.Value)) && ModifierKey.HasValue)
        {
            return;
        }

        if (!(_transform is MatrixTransform transform))
        {
            return;
        }

        var pos1 = e.GetPosition(AssociatedObject);
        var scale = e.Delta > 0 ? 1.1 : 1 / 1.1;
        var mat = transform.Matrix;
        mat.ScaleAt(scale, scale, pos1.X, pos1.Y);
        transform.Matrix = mat;
        e.Handled = true;
    }
}

public enum TransformMode
{
    Layout,
    Render,
}



