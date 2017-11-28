using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{

    //https://stackoverflow.com/questions/4764011/multiple-models-in-a-view#4765113

    public class BigEditViewModel
    {
        public UserFileEditViewModel FEVM { get; set; }
        public UserFileViewModel FVM { get; set; }
    }
}
