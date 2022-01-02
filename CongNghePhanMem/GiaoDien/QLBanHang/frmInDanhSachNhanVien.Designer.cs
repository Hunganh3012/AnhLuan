namespace QLNhaSach
{
    partial class frmInDanhSachNhanVien
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DSNhanVien = new QLNhaSach.DSNhanVien();
            this.DanhSachNhanVienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DanhSachNhanVienTableAdapter = new QLNhaSach.DSNhanVienTableAdapters.DanhSachNhanVienTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DSNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachNhanVienBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DanhSachNhanVienBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QLNhaSach.ReportDsNhanVien.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1206, 533);
            this.reportViewer1.TabIndex = 0;
            // 
            // DSNhanVien
            // 
            this.DSNhanVien.DataSetName = "DSNhanVien";
            this.DSNhanVien.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // DanhSachNhanVienBindingSource
            // 
            this.DanhSachNhanVienBindingSource.DataMember = "DanhSachNhanVien";
            this.DanhSachNhanVienBindingSource.DataSource = this.DSNhanVien;
            // 
            // DanhSachNhanVienTableAdapter
            // 
            this.DanhSachNhanVienTableAdapter.ClearBeforeFill = true;
            // 
            // frmInDanhSachNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 533);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frmInDanhSachNhanVien";
            this.Text = "Danh Sách Nhân Viên";
            this.Load += new System.EventHandler(this.XuatDanhSachNhanVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DSNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DanhSachNhanVienBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DanhSachNhanVienBindingSource;
        private DSNhanVien DSNhanVien;
        private DSNhanVienTableAdapters.DanhSachNhanVienTableAdapter DanhSachNhanVienTableAdapter;


    }
}