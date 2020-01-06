using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeDesktopApp.DataHandling
{
    public class BarcodeDataClass  {
         public int barcodePartID;
         public String BarcodePart { get; set; }
         public DateTime BarcodeDate { get; set; }
         public int BarcodeTruck { get; set; }
         public String BarcodeMachine { get; set; }
         public String BarcodeCustomer { get; set; }
    }
    public class BarcodePartDataClass
    {
        public int ID;
        public String BarcodeRaw { get; set; }
        public String BarcodePart { get; set; }
        public String BarcodeType { get; set; }
    }
}
