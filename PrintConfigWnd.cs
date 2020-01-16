using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections;
using BarcodeDesktopApp.DataHandling;
using BarcodeLib;

namespace BarcodeDesktopApp
{
    public partial class PrintConfigWnd : Form
    {
        // assign these values before showing up form (maube worth to move them to constructor)
        public List<BarcodeDataClass> itemsToShow = new List<BarcodeDataClass>();
        public DataHandlingClass handlingClassRef = null;
        bool ignoreInputEvents = true;
        bool doomedToReturn = true;

        public PrintConfigWnd()
        {
            InitializeComponent();
            printDoc.QueryPageSettings += PrintDoc_QueryPageSettings;
            printDoc.PrintPage += PrintDoc_PrintPage;
            printDoc.BeginPrint += PrintDoc_BeginPrint;
        }

        private void PrintDoc_BeginPrint(object sender, PrintEventArgs e)
        {
            currentPagePrinting = 1;
        }

        // called when form is opened, every time
        private void PrintConfigWnd_Load(object sender, EventArgs e)  {
            ignoreInputEvents = true;
            // fill printer list
            fillPrinterList();
            fillPrintDocument();
            ignoreInputEvents = false;
        }

        private void fillPrintDocument()  {
            doomedToReturn = false;
            if (handlingClassRef == null)  {
                MessageBox.Show("handlingClassRef == null", "No way to print");
                doomedToReturn = true;
            } else if (handlingClassRef.newconfig == null)  {
                MessageBox.Show("handlingClassRef not null ; config == null", "No way to print");
            }
            if (itemsToShow == null)    {
                MessageBox.Show("itemsToShow == null", "No way to print");
                doomedToReturn = true;
            }
            if (doomedToReturn) return;
            maxPagePrinting = itemsToShow.Count;
            this.printPreviewControl1.AutoZoom = false;
            this.printPreviewControl1.Zoom = 1.0;
            this.printPreviewControl1.Rows = maxPagePrinting;
            currentPagePrinting = 1;

            int properWidthInHundretsOfInches = (int)(handlingClassRef.newconfig.labelParameters.barcodeLabelWidthMM * (1.0 / 25.4) * 100.0);
            int properHeightInHundretsOfInches = (int)(handlingClassRef.newconfig.labelParameters.barcodeLabelHeightMM * (1.0 / 25.4) * 100.0);
            printDoc.DefaultPageSettings.PaperSize = new PaperSize("label", properWidthInHundretsOfInches, properHeightInHundretsOfInches);
            int properMargin = (int)(handlingClassRef.newconfig.labelParameters.barcodeLabelMarginMM * (1.0 / 25.4) * 100.0);
            printDoc.DefaultPageSettings.Margins = new Margins(properMargin, properMargin, properMargin, properMargin);



            this.printPreviewControl1.Document = printDoc;
        }
        //pointer to what page is now printing. starts from 1
        private int currentPagePrinting = 0;
        private int maxPagePrinting = 0;
        private void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            if (currentPagePrinting <= maxPagePrinting)  {
                
                Font printFont = new Font("Arial", 6);
                e.Graphics.DrawString(itemsToShow[currentPagePrinting - 1].BarcodeMachine, printFont, Brushes.Black, 1, 1);
                e.Graphics.DrawString(itemsToShow[currentPagePrinting - 1].BarcodeCustomer, printFont, Brushes.Black, 1, 1+printFont.Height);
                List<BarcodePartDataClass> bpart = handlingClassRef.getAllParts(itemsToShow[currentPagePrinting - 1].barcodePartID);
                //draw barcode
                Barcode b = new Barcode();
                b.IncludeLabel = true;
                float dpix = e.Graphics.DpiX;
                float dpiy = e.Graphics.DpiY;
                int dpiXPrinter = e.PageSettings.PrinterResolution.X;
                int dpiYPrinter = e.PageSettings.PrinterResolution.Y;
                // https://www.pixelcalculator.com/
                int W = (int)Math.Round(dpiXPrinter * handlingClassRef.newconfig.labelParameters.barcodeLabelWidthMM / 25.4);
                // b.Encode(TYPE.EAN13, bpart[0].BarcodeRaw, Color.Black, Color.White, W, H);
                currentPagePrinting++;
                e.HasMorePages = (currentPagePrinting <= maxPagePrinting);
            } else
            {
                e.HasMorePages = false;
                // risk of infinite cycle
                currentPagePrinting = 1;
            }
        }

        private void PrintDoc_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
        {
            /*
            PageSettings nSettings = new PageSettings();
            int properWidthInHundretsOfInches = (int)(handlingClassRef.newconfig.labelParameters.barcodeLabelWidthMM * (1.0 / 25.4) * 100.0);
            int properHeightInHundretsOfInches = (int)(handlingClassRef.newconfig.labelParameters.barcodeLabelHeightMM * (1.0 / 25.4) * 100.0);
            nSettings.PaperSize = new PaperSize("label", (int)properWidthInHundretsOfInches, (int)properHeightInHundretsOfInches);            
            e.PageSettings = nSettings;
            */
        }

        private void fillPrinterList ()
        {
            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            String pkInstalledPrinters;
            string lineToPick = handlingClassRef.newconfig.labelParameters.latestPickedPrinter;
            comboInstalledPrinters.Items.Clear();
            bool entryFound = false;
            for (int i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboInstalledPrinters.Items.Add(pkInstalledPrinters);
                if (pkInstalledPrinters == lineToPick)  {
                    entryFound = true;
                }
            }
            // show up the last selected printer
            
            if ((lineToPick != "") && entryFound)
                comboInstalledPrinters.Text = lineToPick;
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty( comboInstalledPrinters.Text ))   {
                errorProvider1.SetError(comboInstalledPrinters, LocalizableStrings.ErrorEmptyPrinter);
            } else {
                errorProvider1.SetError(comboInstalledPrinters, null);
            }
            printDoc.PrinterSettings.PrinterName = comboInstalledPrinters.Text;
            
            printDoc.Print();
        }

        private void comboInstalledPrinters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ignoreInputEvents) return;
            printDoc.PrinterSettings.PrinterName = comboInstalledPrinters.Text;
            printPreviewControl1.InvalidatePreview();
        }

        private void comboInstalledPrinters_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }

        private void PrintConfigWnd_FormClosing(object sender, FormClosingEventArgs e)  {
            //save here last selected printer
            handlingClassRef.newconfig.labelParameters.latestPickedPrinter = comboInstalledPrinters.Text;
            handlingClassRef.saveDataToConfigFile();
        }
    }
}
