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
        public double barcodeLabelMarginMM { get; set; } = 3;
        public double barcodeLabelBCodeWidth { get; set; } = 30;
        public double barcodeLabelBCodeHeight { get; set; } = 15;
        // latest picked printer is used during print preview form
        public String latestPickedPrinter = "";
    }
}
