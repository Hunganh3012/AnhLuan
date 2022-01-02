namespace QLNhaSach
{
    partial class frmInDanhSachKhachHang
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.InDanhSachKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DsKhachHang = new QLNhaSach.DsKhachHang();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.InDanhSachKhachHangTableAdapter = new QLNhaSach.DsKhachHangTableAdapters.InDanhSachKhachHangTableAdapter();
            this.DsMatHang = new QLNhaSach.DsMatHang();
            this.InDsMatHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.InDsMatHangTableAdapter = new QLNhaSach.DsMatHangTableAdapters.InDsMatHangTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.InDanhSachKhachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsMatHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InDsMatHangBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InDanhSachKhachHangBindingSource
            // 
            this.InDanhSachKhachHangBindingSource.DataMember = "InDanhSachKhachHang";
            this.InDanhSachKhachHangBindingSource.DataSource = this.DsKhachHang;
            // 
            // DsKhachHang
            // 
            this.DsKhachHang.DataSetName = "DsKhachHang";
            this.DsKhachHang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.InDanhSachKhachHangBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNhaSach.ReportDsKhachHang.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(990, 605);
            this.reportViewer1.TabIndex = 0;
            // 
            // InDanhSachKhachHangTableAdapter
            // 
            this.InDanhSachKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // DsMatHang
            // 
            this.DsMatHang.DataSetName = "DsMatHang";
            this.DsMatHang.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // InDsMatHangBindingSource
            // 
            this.InDsMatHangBindingSource.DataMember = "InDsMatHang";
            this.InDsMatHangBindingSource.DataSource = this.DsMatHang;
            // 
            // InDsMatHangTableAdapter
            // 
            this.InDsMatHangTableAdapter.ClearBeforeFill = true;
            // 
            // InDanhSachKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 605);
            this.Controls.Add(this.reportViewer1);
            this.Name = "InDanhSachKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Khách Hàng";
            this.Load += new System.EventHandler(this.InDanhSachKhachHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.InDanhSachKhachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DsMatHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InDsMatHangBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource InDanhSachKhachHangBindingSource;
        private DsKhachHang DsKhachHang;
        private DsKhachHangTableAdapters.InDanhSachKhachHangTableAdapter InDanhSachKhachHangTableAdapter;
        private System.Windows.Forms.BindingSource InDsMatHangBindingSource;
        private DsMatHang DsMatHang;
        private DsMatHangTableAdapters.InDsMatHangTableAdapter InDsMatHangTableAdapter;
    }
}