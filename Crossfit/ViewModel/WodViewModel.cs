using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Windows.Storage;
using Windows.UI.Popups;

namespace Crossfit.ViewModel
{
    public class WodViewModel : INotifyPropertyChanged
    {
        StorageFolder localfolder = null;
        private readonly string filnavn = "JsonText.json";

        public Model.Wod NewWod { get; set; }
        public AddWodCommand AddWodCommand { get; set; }
        public RremoveWodCommand RemoveWodCommand { get; set; }
        public SaveWodCommand SaveWodCommand { get; set; }
        public LoadWodCommand LoadWodCommand{ get; set; }
        public Model.WodList Wodliste { get; set; }

   

        private Model.Wod _selectedWod;
        public event PropertyChangedEventHandler PropertyChanged;
       
        public WodViewModel()
        {
            NewWod = new Model.Wod();
            AddWodCommand = new AddWodCommand(AddNewWod);
            Wodliste = new Model.WodList();
            _selectedWod = new Model.Wod();
            RemoveWodCommand = new RremoveWodCommand(RemoveThisWod);
            SaveWodCommand = new SaveWodCommand(GemDataTilDiskAsync);
            LoadWodCommand = new LoadWodCommand(HentDataFraDiskAsync);
            localfolder = ApplicationData.Current.LocalFolder;
            HentDataFraDiskAsync();
        }

        public Model.Wod SelectedWod
        {
            get { return _selectedWod; }
            set { _selectedWod = value;
                OnPropertyChanged(nameof(SelectedWod));
            }
        }

        public async void HentDataFraDiskAsync()
        {
            // this.Wodliste.Clear();
            try
            {
                StorageFile file = await localfolder.GetFileAsync(filnavn);
                string jsonText = await FileIO.ReadTextAsync(file);
                this.Wodliste.Clear();
                Wodliste.IndsetJson(jsonText);
            }
            catch (Exception)
            {
              /*  MessageDialog messageDialog = new MessageDialog("Ændret filnavn eller har du ikke gemt ?", "Filnavn");
                await messageDialog.ShowAsync(); */
            }
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
            var tempWod = new Model.Wod();
            tempWod.WodName = NewWod.WodName;
            tempWod.Description = NewWod.Description;
            tempWod.Movement1 = NewWod.Movement1;
            tempWod.Movement2 = NewWod.Movement2;
            Wodliste.Add(tempWod);
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
