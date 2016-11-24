using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.Storage;

namespace Crossfit.ViewModel
{
    public class WodViewModel : INotifyPropertyChanged
    {
        StorageFolder localfolder = null;
        private readonly string filnavn = "JsonText.json";

        public AddWodCommand AddWodCommand { get; set; }
        public RremoveWodCommand RemoveWodCommand { get; set; }
        public SaveWodCommand SaveWodCommand { get; set; }
        public LoadWodCommand LoadWodCommand{ get; set; }
        public Model.WodList Wodliste { get; set; }
        private Model.Wod _selectedWod;
        public event PropertyChangedEventHandler PropertyChanged;
       
        public WodViewModel()
        {

            Wodliste = new Model.WodList();
            _selectedWod = new Model.Wod();
            AddWodCommand = new AddWodCommand(AddNewWod);
            NewWod = new Model.Wod();
            RemoveWodCommand = new RremoveWodCommand(RemoveThisWod);
            SaveWodCommand = new SaveWodCommand(GemDataTilDiskAsync);
            LoadWodCommand = new LoadWodCommand(HentDataFraDiskAsync);

            localfolder = ApplicationData.Current.LocalFolder;
        }

        public Model.Wod SelectedWod
        {
            get { return _selectedWod; }
            set { _selectedWod = value;
                OnPropertyChanged(nameof(SelectedWod));
            }

        }

        public Model.Wod NewWod { get; set; }

        public async void HentDataFraDiskAsync()
        {
            this.Wodliste.Clear();

            StorageFile file = await localfolder.GetFileAsync(filnavn);
            string jsonText = await FileIO.ReadTextAsync(file);

            Wodliste.IndsetJson(jsonText);
        }
       
       /// <summary>
       /// Gemmer json data fra liste i localfolder
       /// </summary>
       public async void GemDataTilDiskAsync()
        {
            string jsonText = this.Wodliste.GetJson();
            StorageFile file = await localfolder.CreateFileAsync(filnavn, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, jsonText);
        }

        public void AddNewWod()
        {
            Wodliste.Add(NewWod);
        }

        public void RemoveThisWod()
        {
            Wodliste.Remove(SelectedWod);
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
