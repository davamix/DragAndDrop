using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using DragAndDropSample.Commands;
using DragAndDropSample.Model;

namespace DragAndDropSample
{
    public class MainWindowViewModel
    {
        public ObservableCollection<ColorElement> TheColors { get; set; }
        public ObservableCollection<string> TheColorNames { get; set; }
        public ObservableCollection<ItemModel> TheElements { get; set; }

        public ICommand AddElementCommand { get; set; } 
        public ICommand DeleteElementCommand { get; set; }

        public MainWindowViewModel()
        {
            TheColors = new ObservableCollection<ColorElement>();
            TheColorNames = new ObservableCollection<string>();
            TheElements = new ObservableCollection<ItemModel>();

            AddElementCommand = new DelegateCommand(AddElement, true);
            DeleteElementCommand = new DelegateCommand(DeleteElement, true);          
            InitializeCollection();
        }

        private void DeleteElement()
        {
            
        }

        private void InitializeCollection()
        {
            TheColors.Add(new ColorElement {FillColor = Colors.Blue, Value = "Blue"});
            TheColors.Add(new ColorElement {FillColor = Colors.Green, Value = "Green"});

            TheElements.Add(new ItemModel {ElementType = "Process", Level = $"L{TheElements.Count + 1}", DefaultColor = "#FF0000FF"});
            TheElements.Add(new ItemModel {ElementType = "Activity", Level = $"L{TheElements.Count + 1}", DefaultColor = "#FF00FF00"});
        }

        private void AddElement()
        {
            TheElements.Add(new ItemModel {Level = $"L{TheElements.Count + 1}", ElementType = "Process"});
        }
    }
}
