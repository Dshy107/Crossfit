using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Crossfit.ViewModel
{
    public class WodViewModel : INotifyPropertyChanged
    {

        public Model.WodList Wodliste { get; set; }

        private Model.Wod _selectedWod;

        public event PropertyChangedEventHandler PropertyChanged;

        public Model.Wod SelectedWod
        {
            get { return _selectedWod; }
            set { _selectedWod = value;
                OnPropertyChanged(nameof(SelectedWod));
            }
        }

        public Model.Wod NewWod { get; set; }

        

        public WodViewModel()
        {
            Wodliste = new Model.WodList();
            _selectedWod = new Model.Wod();
            AddWodCommand = new RelayCommand(AddNewWod);
        }

        public RelayCommand AddWodCommand { get; set; }

        public void AddNewWod()
        {
            Wodliste.Add(NewWod);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this,
                    new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
