using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows;
using DragAndDropSample.Commands;

namespace DragAndDropSample.UserControls
{
    public class ElementItemViewModel :INotifyPropertyChanged
    {
        private string _level;
        private string _elementType;

        public string Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged();
            }
        }

        public string ElementType
        {
            get
            {
                return _elementType;
            }
            set
            {
                _elementType = value;
                OnPropertyChanged();
            }
        }

       


        public ElementItemViewModel()
        {
            DeleteItem = new DelegateCommand(DeleteSelectedItem, true);
        }

        private void DeleteSelectedItem()
        {
                
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
