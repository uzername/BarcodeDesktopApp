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
        // set during OK button is pressed
        public string partName { get; private set; }
        public string barcodeString { get; private set; }

        public DateTime BarcodeDate { get; private set; }
        public int BarcodeTruck { get; private set; }
        public string BarcodeCustomer { get; private set; }
        public string BarcodeMachine { get; private set; }

        public FormNewBarcode(List<BarcodePartDataClass> in_ListAllParts, DataHandlingClass in_dataThings)
        {
            InitializeComponent();
            cmbPart.DataSource = in_ListAllParts;
            cmbPart.DisplayMember = "BarcodePart";
            thingForDatat = in_dataThings;
            pictureBoxBarCode.BackgroundImageLayout = ImageLayout.Center;
            pictureBoxBarCode.BackColor = Color.White;
            b.IncludeLabel = true;
            cmbPart.SelectedItem = null;
            // http://net-informations.com/q/faq/autocombo.html
            AutoCompleteStringCollection combData = new AutoCompleteStringCollection();
            getDataForPartsAutocomplete(combData, in_ListAllParts);
            cmbPart.AutoCompleteCustomSource = combData;
        }

        private void getDataForPartsAutocomplete(AutoCompleteStringCollection in_combData, List<BarcodePartDataClass> in_allparts)
        {
            foreach (BarcodePartDataClass itempart in in_allparts)
            {
                in_combData.Add(itempart.BarcodePart);
            }
        }

        private void buttonForOK_Click(object sender, EventArgs e)
        {
            // your princess is in another castle. Saving is called in FormMain, after this dialog closes with confirmation
            if (String.IsNullOrEmpty(textBoxBarcode.Text))
            {
                errorProviderPart.SetError(textBoxBarcode, LocalizableStrings.ErrorEmptyBarcode);
            } else
            {
                errorProviderPart.SetError(textBoxBarcode, null);
            }
            if (!((String.IsNullOrEmpty(cmbPart.Text)) || (String.IsNullOrEmpty(textBoxBarcode.Text))))
            {
                partName = this.cmbPart.Text;
                barcodeString = this.textBoxBarcode.Text;
                BarcodeDate = this.DateDelivery.Value;
                BarcodeTruck = (int) this.numberTruck.Value;
                BarcodeCustomer = this.textCustomer.Text;
                BarcodeMachine = this.textMachine.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
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
                BarcodeLib.TYPE type = TYPE.EAN13; // maybe, add input field with additional symbologies to select?
                int W = pictureBoxBarCode.Width - 10;
                int H = pictureBoxBarCode.Height - 10;
                pictureBoxBarCode.BackgroundImage = b.Encode(type, this.textBoxBarcode.Text.Trim(), Color.Black, Color.White, W, H);
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            this.textBoxBarcode.Text =  thingForDatat.generateNewBarcodeNumeric();
            // generate here barcode and show it
            BarcodeLib.TYPE type = TYPE.EAN13; // maybe, add input field with additional symbologies to select?
            int W = pictureBoxBarCode.Width-10;
            int H = pictureBoxBarCode.Height-10;
            pictureBoxBarCode.BackgroundImage = b.Encode(type, this.textBoxBarcode.Text.Trim(), Color.Black, Color.White, W, H);
        }

        private void cmbPart_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(cmbPart.Text))
            {
                errorProviderPart.SetError(cmbPart,LocalizableStrings.ErrorEmptyPart);
            } else {
                errorProviderPart.SetError(cmbPart, null);
            }
        }

        private void textBoxBarcode_TextChanged(object sender, EventArgs e)
        {
            if (textBoxBarcode.Text.Length >=0)
            {
                errorProviderPart.SetError(textBoxBarcode, null);
            }
        }
    }
}
