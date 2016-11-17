using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Crossfit.Model
{
    public class WodList : ObservableCollection<Wod>
    {
        public WodList() :base()
        {
            this.Add(new Wod() { WodName = "Fran", Description = "AFAP", gender = true, Movement1 = "Thrusters", Movement2 = "Pullups", Number = 1 });
            this.Add(new Wod() { WodName = "Cindy", Description = "AMRAP 20", gender = true, Movement1 = "Pullups", Movement2 = "Pushups", Number = 2 });
            this.Add(new Wod() { WodName = "Diane", Description = "21-15-9", gender = true, Movement1 = "Deadlift", Movement2 = "Handstand pushups", Number = 3 });
       
        }
    }
}
