namespace QLNhaSach
{
    partial class frmDoanhThuBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDoanhThuBanHang));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.label1 = new System.Windows.Forms.Label();
            this.dpkDenNgay = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dpkTuNgay = new System.Windows.Forms.DateTimePicker();
            this.btnTimKiem = new DevComponents.DotNetBar.ButtonX();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DsDoanhThuTheoThang = new QLNhaSach.DsDoanhThuTheoThang();
            this.DoanhThu_BaCaoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DoanhThu_BaCaoTableAdapter = new QLNhaSach.DsDoanhThuTheoThangTableAdapters.DoanhThu_BaCaoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DsDoanhThuTheoThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoanhThu_BaCaoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 182;
            this.label1.Text = "Đến Ngày";
            // 
            // dpkDenNgay
            // 
            this.dpkDenNgay.CustomFormat = "dd/MM/yyyy";
            this.dpkDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpkDenNgay.Location = new System.Drawing.Point(356, 46);
            this.dpkDenNgay.Name = "dpkDenNgay";
            this.dpkDenNgay.Size = new System.Drawing.Size(96, 20);
            this.dpkDenNgay.TabIndex = 183;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(98, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 180;
            this.label9.Text = "Từ Ngày";
            // 
            // dpkTuNgay
            // 
            this.dpkTuNgay.CustomFormat = "dd/MM/yyyy";
            this.dpkTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dpkTuNgay.Location = new System.Drawing.Point(172, 46);
            this.dpkTuNgay.Name = "dpkTuNgay";
            this.dpkTuNgay.Size = new System.Drawing.Size(96, 20);
            this.dpkTuNgay.TabIndex = 181;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTimKiem.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnTimKiem.Image = ((System.Drawing.Image)(resources.GetObject("btnTimKiem.Image")));
            this.btnTimKiem.Location = new System.Drawing.Point(476, 37);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(81, 29);
            this.btnTimKiem.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2010;
            this.btnTimKiem.TabIndex = 179;
            this.btnTimKiem.Text = "Thống Kê";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(240, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 25);
            this.label2.TabIndex = 185;
            this.label2.Text = "Doanh Thu Bán Hàng";
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DoanhThu_BaCaoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNhaSach.ReportDoanhThuBanHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 69);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(716, 430);
            this.reportViewer1.TabIndex = 186;
            // 
            // DsDoanhThuTheoThang
            // 
            this.DsDoanhThuTheoThang.DataSetName = "DsDoanhThuTheoThang";
            this.DsDoanhThuTheoThang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DoanhThu_BaCaoBindingSource
            // 
            this.DoanhThu_BaCaoBindingSource.DataMember = "DoanhThu_BaCao";
            this.DoanhThu_BaCaoBindingSource.DataSource = this.DsDoanhThuTheoThang;
            // 
            // DoanhThu_BaCaoTableAdapter
            // 
            this.DoanhThu_BaCaoTableAdapter.ClearBeforeFill = true;
            // 
            // frmDoanhThuBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(740, 511);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dpkDenNgay);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dpkTuNgay);
            this.Controls.Add(this.btnTimKiem);
            this.Name = "frmDoanhThuBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDoanhThuBanHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DsDoanhThuTheoThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DoanhThu_BaCaoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dpkDenNgay;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dpkTuNgay;
        private DevComponents.DotNetBar.ButtonX btnTimKiem;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DoanhThu_BaCaoBindingSource;
        private DsDoanhThuTheoThang DsDoanhThuTheoThang;
        private DsDoanhThuTheoThangTableAdapters.DoanhThu_BaCaoTableAdapter DoanhThu_BaCaoTableAdapter;
    }
}