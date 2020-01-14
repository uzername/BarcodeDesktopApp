namespace BarcodeDesktopApp
{
    partial class PrintConfigWnd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.printPreviewControl1 = new System.Windows.Forms.PrintPreviewControl();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.comboInstalledPrinters = new System.Windows.Forms.ComboBox();
            this.printDoc = new System.Drawing.Printing.PrintDocument();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // printPreviewControl1
            // 
            this.printPreviewControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printPreviewControl1.Location = new System.Drawing.Point(3, 28);
            this.printPreviewControl1.Name = "printPreviewControl1";
            this.printPreviewControl1.Size = new System.Drawing.Size(579, 294);
            this.printPreviewControl1.TabIndex = 0;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(3, 328);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonPrint
            // 
            this.buttonPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonPrint.Location = new System.Drawing.Point(84, 328);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(75, 23);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.Text = "Print Now";
            this.buttonPrint.UseVisualStyleBackColor = true;
            this.buttonPrint.Click += new System.EventHandler(this.buttonPrint_Click);
            // 
            // comboInstalledPrinters
            // 
            this.comboInstalledPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboInstalledPrinters.FormattingEnabled = true;
            this.comboInstalledPrinters.Location = new System.Drawing.Point(3, 3);
            this.comboInstalledPrinters.Name = "comboInstalledPrinters";
            this.comboInstalledPrinters.Size = new System.Drawing.Size(560, 21);
            this.comboInstalledPrinters.TabIndex = 3;
            this.comboInstalledPrinters.SelectedIndexChanged += new System.EventHandler(this.comboInstalledPrinters_SelectedIndexChanged);
            this.comboInstalledPrinters.SelectedValueChanged += new System.EventHandler(this.comboInstalledPrinters_SelectedValueChanged);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PrintConfigWnd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 355);
            this.Controls.Add(this.comboInstalledPrinters);
            this.Controls.Add(this.buttonPrint);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.printPreviewControl1);
            this.Name = "PrintConfigWnd";
            this.Text = "PrintConfigWnd";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrintConfigWnd_FormClosing);
            this.Load += new System.EventHandler(this.PrintConfigWnd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PrintPreviewControl printPreviewControl1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.ComboBox comboInstalledPrinters;
        private System.Drawing.Printing.PrintDocument printDoc;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}