using BarcodeDesktopApp.DataHandling;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;

namespace BarcodeDesktopApp
{
    public partial class FormNewBarcode : Form
    {
        Barcode b = new Barcode();
        private DataHandlingClass thingForDatat = null;
        public FormNewBarcode(List<BarcodePartDataClass> in_ListAllParts, DataHandlingClass in_dataThings)
        {
            InitializeComponent();
            cmbPart.DataSource = in_ListAllParts;
            cmbPart.DisplayMember = "BarcodePart";
            thingForDatat = in_dataThings;

            
        }

        private void buttonForOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbPart_Leave(object sender, EventArgs e)
        {
            bool someViablePartWasSelected = (cmbPart.SelectedItem != null);
            this.buttonGenerate.Enabled = !(someViablePartWasSelected) && cmbPart.Text!="";
            if (someViablePartWasSelected)
            { // show barcode for part
                BarcodePartDataClass partToResolve = cmbPart.SelectedItem as BarcodePartDataClass;
                this.textBoxBarcode.Text = partToResolve.BarcodeRaw;
                // generate here barcode and show it

            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            this.textBoxBarcode.Text =  thingForDatat.generateNewBarcodeNumeric();
            // generate here barcode and show it
            BarcodeLib.TYPE type = TYPE.EAN13; // maybe, add input field with additional symbologies to select?
            int W = pictureBoxBarCode.Width;
            int H = pictureBoxBarCode.Height;
            pictureBoxBarCode.BackgroundImage = b.Encode(type, this.textBoxBarcode.Text.Trim(), Color.Black, Color.White, W, H);
        }
    }
}
