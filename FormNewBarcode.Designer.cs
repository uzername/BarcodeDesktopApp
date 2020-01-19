namespace BarcodeDesktopApp
{
    partial class FormNewBarcode
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
            this.BarcodeLabel = new System.Windows.Forms.Label();
            this.textBoxBarcode = new System.Windows.Forms.TextBox();
            this.PartLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.TruckLabel = new System.Windows.Forms.Label();
            this.CustomerLabel = new System.Windows.Forms.Label();
            this.MachineLabel = new System.Windows.Forms.Label();
            this.DateDelivery = new System.Windows.Forms.DateTimePicker();
            this.cmbPart = new System.Windows.Forms.ComboBox();
            this.textCustomer = new System.Windows.Forms.TextBox();
            this.textMachine = new System.Windows.Forms.TextBox();
            this.pictureBoxBarCode = new System.Windows.Forms.PictureBox();
            this.buttonForOK = new System.Windows.Forms.Button();
            this.buttonForCancel = new System.Windows.Forms.Button();
            this.numberTruck = new System.Windows.Forms.NumericUpDown();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.errorProviderPart = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberTruck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPart)).BeginInit();
            this.SuspendLayout();
            // 
            // BarcodeLabel
            // 
            this.BarcodeLabel.AutoSize = true;
            this.BarcodeLabel.Location = new System.Drawing.Point(9, 44);
            this.BarcodeLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.BarcodeLabel.Name = "BarcodeLabel";
            this.BarcodeLabel.Size = new System.Drawing.Size(60, 16);
            this.BarcodeLabel.TabIndex = 0;
            this.BarcodeLabel.Text = "Barcode";
            // 
            // textBoxBarcode
            // 
            this.errorProviderPart.SetIconAlignment(this.textBoxBarcode, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.textBoxBarcode.Location = new System.Drawing.Point(88, 41);
            this.textBoxBarcode.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBoxBarcode.Name = "textBoxBarcode";
            this.textBoxBarcode.ReadOnly = true;
            this.textBoxBarcode.Size = new System.Drawing.Size(128, 22);
            this.textBoxBarcode.TabIndex = 1;
            this.textBoxBarcode.TextChanged += new System.EventHandler(this.textBoxBarcode_TextChanged);
            // 
            // PartLabel
            // 
            this.PartLabel.AutoSize = true;
            this.PartLabel.Location = new System.Drawing.Point(9, 12);
            this.PartLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.PartLabel.Name = "PartLabel";
            this.PartLabel.Size = new System.Drawing.Size(32, 16);
            this.PartLabel.TabIndex = 2;
            this.PartLabel.Text = "Part";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(9, 70);
            this.DateLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(37, 16);
            this.DateLabel.TabIndex = 3;
            this.DateLabel.Text = "Date";
            // 
            // TruckLabel
            // 
            this.TruckLabel.AutoSize = true;
            this.TruckLabel.Location = new System.Drawing.Point(9, 99);
            this.TruckLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.TruckLabel.Name = "TruckLabel";
            this.TruckLabel.Size = new System.Drawing.Size(42, 16);
            this.TruckLabel.TabIndex = 4;
            this.TruckLabel.Text = "Truck";
            // 
            // CustomerLabel
            // 
            this.CustomerLabel.AutoSize = true;
            this.CustomerLabel.Location = new System.Drawing.Point(9, 130);
            this.CustomerLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.CustomerLabel.Name = "CustomerLabel";
            this.CustomerLabel.Size = new System.Drawing.Size(65, 16);
            this.CustomerLabel.TabIndex = 5;
            this.CustomerLabel.Text = "Customer";
            // 
            // MachineLabel
            // 
            this.MachineLabel.AutoSize = true;
            this.MachineLabel.Location = new System.Drawing.Point(9, 159);
            this.MachineLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.MachineLabel.Name = "MachineLabel";
            this.MachineLabel.Size = new System.Drawing.Size(59, 16);
            this.MachineLabel.TabIndex = 6;
            this.MachineLabel.Text = "Machine";
            // 
            // DateDelivery
            // 
            this.DateDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateDelivery.Location = new System.Drawing.Point(88, 69);
            this.DateDelivery.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.DateDelivery.Name = "DateDelivery";
            this.DateDelivery.Size = new System.Drawing.Size(161, 22);
            this.DateDelivery.TabIndex = 3;
            // 
            // cmbPart
            // 
            this.cmbPart.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cmbPart.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.cmbPart.FormattingEnabled = true;
            this.errorProviderPart.SetIconAlignment(this.cmbPart, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.cmbPart.Location = new System.Drawing.Point(88, 9);
            this.cmbPart.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbPart.Name = "cmbPart";
            this.cmbPart.Size = new System.Drawing.Size(161, 24);
            this.cmbPart.TabIndex = 0;
            this.cmbPart.Leave += new System.EventHandler(this.cmbPart_Leave);
            this.cmbPart.Validating += new System.ComponentModel.CancelEventHandler(this.cmbPart_Validating);
            // 
            // textCustomer
            // 
            this.textCustomer.Location = new System.Drawing.Point(88, 127);
            this.textCustomer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textCustomer.Name = "textCustomer";
            this.textCustomer.Size = new System.Drawing.Size(385, 22);
            this.textCustomer.TabIndex = 5;
            // 
            // textMachine
            // 
            this.textMachine.Location = new System.Drawing.Point(88, 156);
            this.textMachine.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textMachine.Name = "textMachine";
            this.textMachine.Size = new System.Drawing.Size(385, 22);
            this.textMachine.TabIndex = 6;
            // 
            // pictureBoxBarCode
            // 
            this.pictureBoxBarCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxBarCode.Location = new System.Drawing.Point(257, 7);
            this.pictureBoxBarCode.Name = "pictureBoxBarCode";
            this.pictureBoxBarCode.Padding = new System.Windows.Forms.Padding(2);
            this.pictureBoxBarCode.Size = new System.Drawing.Size(216, 114);
            this.pictureBoxBarCode.TabIndex = 12;
            this.pictureBoxBarCode.TabStop = false;
            // 
            // buttonForOK
            // 
            this.buttonForOK.Location = new System.Drawing.Point(12, 191);
            this.buttonForOK.Name = "buttonForOK";
            this.buttonForOK.Size = new System.Drawing.Size(69, 23);
            this.buttonForOK.TabIndex = 7;
            this.buttonForOK.Text = "OK";
            this.buttonForOK.UseVisualStyleBackColor = true;
            this.buttonForOK.Click += new System.EventHandler(this.buttonForOK_Click);
            // 
            // buttonForCancel
            // 
            this.buttonForCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonForCancel.Location = new System.Drawing.Point(88, 191);
            this.buttonForCancel.Name = "buttonForCancel";
            this.buttonForCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonForCancel.TabIndex = 8;
            this.buttonForCancel.Text = "Cancel";
            this.buttonForCancel.UseVisualStyleBackColor = true;
            // 
            // numberTruck
            // 
            this.numberTruck.Location = new System.Drawing.Point(88, 99);
            this.numberTruck.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberTruck.Name = "numberTruck";
            this.numberTruck.Size = new System.Drawing.Size(161, 22);
            this.numberTruck.TabIndex = 4;
            this.numberTruck.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Enabled = false;
            this.buttonGenerate.Image = global::BarcodeDesktopApp.Properties.Resources.ARW03RT;
            this.buttonGenerate.Location = new System.Drawing.Point(219, 36);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(30, 30);
            this.buttonGenerate.TabIndex = 2;
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.buttonGenerate_Click);
            // 
            // errorProviderPart
            // 
            this.errorProviderPart.ContainerControl = this;
            // 
            // FormNewBarcode
            // 
            this.AcceptButton = this.buttonForOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonForCancel;
            this.ClientSize = new System.Drawing.Size(489, 226);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.numberTruck);
            this.Controls.Add(this.buttonForCancel);
            this.Controls.Add(this.buttonForOK);
            this.Controls.Add(this.pictureBoxBarCode);
            this.Controls.Add(this.textMachine);
            this.Controls.Add(this.textCustomer);
            this.Controls.Add(this.cmbPart);
            this.Controls.Add(this.DateDelivery);
            this.Controls.Add(this.MachineLabel);
            this.Controls.Add(this.CustomerLabel);
            this.Controls.Add(this.TruckLabel);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.PartLabel);
            this.Controls.Add(this.textBoxBarcode);
            this.Controls.Add(this.BarcodeLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormNewBarcode";
            this.Text = "New Part Entry";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBarCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberTruck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderPart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BarcodeLabel;
        private System.Windows.Forms.TextBox textBoxBarcode;
        private System.Windows.Forms.Label PartLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label TruckLabel;
        private System.Windows.Forms.Label CustomerLabel;
        private System.Windows.Forms.Label MachineLabel;
        private System.Windows.Forms.DateTimePicker DateDelivery;
        private System.Windows.Forms.ComboBox cmbPart;
        private System.Windows.Forms.TextBox textCustomer;
        private System.Windows.Forms.TextBox textMachine;
        private System.Windows.Forms.PictureBox pictureBoxBarCode;
        private System.Windows.Forms.Button buttonForOK;
        private System.Windows.Forms.Button buttonForCancel;
        private System.Windows.Forms.NumericUpDown numberTruck;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.ErrorProvider errorProviderPart;
    }
}