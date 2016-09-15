using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DragAndDropSample
{
    public class MainWindowViewModel
    {
        public ObservableCollection<ColorElement> TheColors { get; set; }
        public ObservableCollection<string> TheColorNames { get; set; }

        public MainWindowViewModel()
        {
            TheColors = new ObservableCollection<ColorElement>();
            TheColorNames = new ObservableCollection<string>();

            InitializeCollection();
        }

        private void InitializeCollection()
        {
            TheColors.Add(new ColorElement {FillColor = Colors.Blue, Value = "Blue"});
            TheColors.Add(new ColorElement {FillColor = Colors.Green, Value = "Green"});
        }
    }
}
