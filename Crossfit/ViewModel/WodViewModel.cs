using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crossfit.ViewModel
{
    public class WodViewModel
    {

        public Model.WodList Wodliste { get; set; }

        private Model.Wod _selectedWod;

        public Model.Wod SelectedWod
        {
            get { return _selectedWod; }
            set { _selectedWod = value; }
        }


        public WodViewModel()
        {
            Wodliste = new Model.WodList();
            _selectedWod = new Model.Wod();
        }
    }
}
