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

namespace DragAndDropSample.UserControls
{
    /// <summary>
    /// Interaction logic for ElementItemUserControl.xaml
    /// </summary>
    public partial class ElementItem : UserControl
    {

        public static readonly DependencyProperty DeleteItemCommandProperty = DependencyProperty.Register(
                   "DeleteItemCommand", typeof(ICommand), typeof(ElementItem));

        public static readonly DependencyProperty LevelProperty = DependencyProperty.Register(
            "Level",
            typeof(string),
            typeof(ElementItem));

        public static readonly DependencyProperty ElementTypeProperty = DependencyProperty.Register(
            "ElementType",
            typeof(string),
            typeof(ElementItem));

        public static readonly DependencyProperty DefaultColorProperty = DependencyProperty.Register(
            "DefaultColor",
            typeof(string),
            typeof(ElementItem));

        public string Level
        {
            get { return (string)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }
        public string ElementType
        {
            get { return (string)GetValue(ElementTypeProperty); }
            set { SetValue(ElementTypeProperty, value); }
        }

        public string DefaultColor
        {
            get { return (string)GetValue(DefaultColorProperty); }
            set { SetValue(DefaultColorProperty, value); }
        }

        public ICommand DeleteItemCommand
        {
            get { return (ICommand)GetValue(DeleteItemCommandProperty); }
            set { SetValue(DeleteItemCommandProperty, value); }
        }

        public ElementItem()
        {
            //var vm = new ElementItemViewModel();
            InitializeComponent();

            //this.DataContext = vm;
        }
    }
}
