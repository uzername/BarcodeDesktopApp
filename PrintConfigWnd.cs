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
using System.Drawing.Drawing2D;

namespace BarcodeDesktopApp
{
    public partial class PrintConfigWnd : Form
    {
        // assign these values before showing up form (maube worth to move them to constructor)
        public List<BarcodeDataClass> itemsToShow = new List<BarcodeDataClass>();
        public DataHandlingClass handlingClassRef = null;
        bool ignoreInputEvents = true;
        bool doomedToReturn = true;
        double currentControlZoom;

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
            currentControlZoom = 1.0;
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
                // blur go away!
                e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
                e.Graphics.PixelOffsetMode = PixelOffsetMode.None; // or PixelOffsetMode.Half
                Font printFont = new Font("Courier New", 7);
                e.Graphics.DrawString(itemsToShow[currentPagePrinting - 1].BarcodeMachine, printFont, Brushes.Black, 1, 1);
                e.Graphics.DrawString(itemsToShow[currentPagePrinting - 1].BarcodeCustomer, printFont, Brushes.Black, 1, 1+printFont.Height);                
                // clojure and lambda
                BarcodePartDataClass bpdc = handlingClassRef.allPartsList.Find((BarcodePartDataClass in_bcode) => { return in_bcode.ID == itemsToShow[currentPagePrinting - 1].barcodePartID; });
                //draw barcode
                Barcode b = new Barcode();
                b.IncludeLabel = false; // well, the label text is blurry. To overcome this we need to modify barcodelib
                b.Alignment = AlignmentPositions.LEFT;
                float dpix = e.Graphics.DpiX;
                float dpiy = e.Graphics.DpiY;
                int dpiXPrinter = e.PageSettings.PrinterResolution.X;
                int dpiYPrinter = e.PageSettings.PrinterResolution.Y;
                // https://www.pixelcalculator.com/
                int W = (int)Math.Round(96 * handlingClassRef.newconfig.labelParameters.barcodeLabelBCodeWidth / 25.4);
                int H = (int)Math.Round(96 * handlingClassRef.newconfig.labelParameters.barcodeLabelBCodeHeight / 25.4);
                Image bcodeImg = b.Encode(TYPE.EAN13, bpdc.BarcodeRaw, Color.Black, Color.White, W, H);
                
                e.Graphics.DrawImageUnscaled(bcodeImg, 40, 1 + 2 * printFont.Height);
                RectangleF fff = e.Graphics.ClipBounds;
                
                e.Graphics.FillRectangle(Brushes.White, 40, 1 + printFont.Height + H, fff.Width-1, printFont.Height+2);
                e.Graphics.DrawString("T"+ itemsToShow[currentPagePrinting - 1].BarcodeTruck.ToString("D3")+"     "+ bpdc.BarcodeRaw, printFont,Brushes.Black, 1, 1 + printFont.Height + H+1);

                e.Graphics.DrawString(itemsToShow[currentPagePrinting - 1].BarcodePart, printFont,Brushes.Black, 1, 1+2*printFont.Height+H);

                currentPagePrinting++;
                e.HasMorePages = (currentPagePrinting <= maxPagePrinting);
            } else {
                e.HasMorePages = false;
                // risk of infinite cycle
                currentPagePrinting = 1;
            }
        }

        // http://csharphelper.com/blog/2014/07/draw-rotated-text-in-c/
        // Draw a rotated string at a particular position.
        private void DrawRotatedTextAt(Graphics gr, float angle,
            string txt, int x, int y, Font the_font, Brush the_brush)
        {
            // Save the graphics state.
            GraphicsState state = gr.Save();
            gr.ResetTransform();

            // Rotate.
            gr.RotateTransform(angle);

            // Translate to desired position. Be sure to append
            // the rotation so it occurs after the rotation.
            gr.TranslateTransform(x, y, MatrixOrder.Append);

            // Draw the text at the origin.
            gr.DrawString(txt, the_font, the_brush, 0, 0);

            // Restore the graphics state.
            gr.Restore(state);
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
            //if (ignoreInputEvents) return;

        }

        private void PrintConfigWnd_FormClosing(object sender, FormClosingEventArgs e)  {
            //save here last selected printer
            handlingClassRef.newconfig.labelParameters.latestPickedPrinter = comboInstalledPrinters.Text;
            handlingClassRef.saveDataToConfigFile();
        }

        private void ComboBoxScale_TextChanged(object sender, EventArgs e)
        {
            if (ignoreInputEvents) return;
            if (String.IsNullOrEmpty(comboBoxScale.Text) )
            {
                currentControlZoom = 1.0;
                printPreviewControl1.Zoom = currentControlZoom;
                return;
            }
            double rsltparse = 0.0;
            bool value = double.TryParse(comboBoxScale.Text, out rsltparse);
            if (value)  {
                currentControlZoom = rsltparse;
                printPreviewControl1.Zoom = currentControlZoom;
            } else
            {
                ignoreInputEvents = true;
                comboBoxScale.Text = currentControlZoom.ToString();
                ignoreInputEvents = false;
            }
        }
    }
}
