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

    public enum BarcodeTypeEnum
    {
        EAN8 = 0,
        EAN13 =1,
        QRCODE = 2
    }

    public class BarcodePartDataClass
    {
        public int ID;
        public String BarcodeRaw { get; set; }
        public String BarcodePart { get; set; }
        public BarcodeTypeEnum BarcodeType { get; set; }
    }
}
