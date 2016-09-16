using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DragAndDropSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point _startPoint;
        private MainWindowViewModel _vm;
        public MainWindow()
        {
            _vm = new MainWindowViewModel();
            InitializeComponent();
            this.DataContext = _vm;
        }

        private void UIElement_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _startPoint = e.GetPosition(null);
        }

        private void UIElement_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = _startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAnchestor<ListViewItem>((DependencyObject) e.OriginalSource);

                if (listViewItem == null) return;

                // Find the data behind the ListViewItem
                ColorElement color = (ColorElement) listView.ItemContainerGenerator.
                                                            ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myElement", color);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }

        }

        private static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);

            return null;
        }

        private void DropList_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myElement"))
            {
                ColorElement color = e.Data.GetData("myElement") as ColorElement;
                //ListView listView = sender as ListView;
                //listView.Items.Add(color?.Value);
                _vm.TheColorNames.Add(color?.Value);
            }

        }

        private void DragList_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myElement") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }

        }
    }
}
