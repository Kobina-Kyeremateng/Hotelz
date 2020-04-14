namespace Hotelz.Winforms
{
    partial class frmBank
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
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pInput = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lueBankSearch = new DevExpress.XtraEditors.LookUpEdit();
            this.bankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pInput.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lueBankSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(70, 14);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(223, 21);
            this.txtBankName.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 46;
            this.label1.Text = "Bank Name";
            // 
            // pInput
            // 
            this.pInput.Controls.Add(this.txtBankName);
            this.pInput.Controls.Add(this.label1);
            this.pInput.Location = new System.Drawing.Point(4, 64);
            this.pInput.Name = "pInput";
            this.pInput.Size = new System.Drawing.Size(318, 48);
            this.pInput.TabIndex = 51;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lueBankSearch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(322, 42);
            this.panel1.TabIndex = 52;
            // 
            // lueBankSearch
            // 
            this.lueBankSearch.Location = new System.Drawing.Point(100, 12);
            this.lueBankSearch.Name = "lueBankSearch";
            this.lueBankSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lueBankSearch.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("BankName", "BankName")});
            this.lueBankSearch.Properties.DataSource = this.bankBindingSource;
            this.lueBankSearch.Properties.DisplayMember = "BankName";
            this.lueBankSearch.Properties.ValueMember = "BankID";
            this.lueBankSearch.Size = new System.Drawing.Size(197, 20);
            this.lueBankSearch.TabIndex = 0;
            // 
            // bankBindingSource
            // 
            //this.bankBindingSource.DataSource = typeof(Hotelz.Core.Bank);
            // 
            // frmBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 138);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pInput);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBank";
            this.Text = "Banks";
            this.pInput.ResumeLayout(false);
            this.pInput.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lueBankSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pInput;
        //private System.Windows.Forms.DataGridViewTextBoxColumn bankIDDataGridViewTextBoxColumn;
        //private System.Windows.Forms.DataGridViewTextBoxColumn bankNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.LookUpEdit lueBankSearch;
        private System.Windows.Forms.BindingSource bankBindingSource;
    }
}