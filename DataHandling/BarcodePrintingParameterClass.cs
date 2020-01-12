using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeDesktopApp.DataHandling
{
    [Serializable]
    public class BarcodePrintingParameterClass {
        public double barcodeLabelWidthMM { get; set; } = 57;
        public double barcodeLabelHeightMM { get; set; } = 30;
        public double barcodeLabelBCodeWidthMM { get; set; } = 40;
        public double barcodeLabelBCodeHeightMM { get; set; } = 15;

        
    }
}
