using BinaryFile.VM;
using BinaryModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace BinaryFile.View
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void GridWorkspace_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            MouseWheelEventArgs eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = MouseWheelEvent,
                Source = e.Source
            };
            DependencyObject parent = VisualTreeHelper.GetParent((DependencyObject)sender);

            while (parent != null && !(parent is Grid))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            if (parent != null)
            {
                Grid grid = (Grid)parent;
                grid.RaiseEvent(eventArg);
            }

            e.Handled = true;
        }

        private void GridWorkspace_Scroll(object sender, ScrollEventArgs e)
        {
            if (GridWorkspace.Items.Count > 0)
            {
                var border = VisualTreeHelper.GetChild(GridWorkspace, 0) as Decorator;
                if (border != null)
                {
                    var scroll = border.Child as ScrollViewer;
                    if (scroll.VerticalOffset>1500)
                    {
                        scroll.ScrollToVerticalOffset(750);
                        (sender as DataGrid).SelectedIndex = 50;
                    }
                }
            }
        }
    }
}
