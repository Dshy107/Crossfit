using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;


namespace Crossfit.Model
{
    public class WodList : ObservableCollection<Wod>
    {
        public WodList() :base()
        {
            /*
            this.Add(new Wod() { WodName = "Fran", Description = "AFAP", Movement1 = "Thrusters", Movement2 = "Pullups",});
            this.Add(new Wod() { WodName = "Cindy", Description = "AMRAP 20", Movement1 = "Pullups", Movement2 = "Pushups", });
            this.Add(new Wod() { WodName = "Diane", Description = "21-15-9",  Movement1 = "Deadlift", Movement2 = "Handstand pushups",  });
       */
        }


        /// <summary>
        /// Giver mig JsonFormat for wodList object
        /// </summary>
        /// <returns></returns>
        public string GetJson()
        {
            string json = JsonConvert.SerializeObject(this);
            return json;
        }

        public void IndsetJson(string jsonText)
        {
            List<Wod> nyListe = JsonConvert.DeserializeObject<List<Wod>>(jsonText);

            foreach (var wod in nyListe)
            {
                this.Add(wod);
            }
        }
    }
}
