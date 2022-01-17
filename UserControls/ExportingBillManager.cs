using Microsoft.Data.Sqlite;
using RJCodeAdvance.RJControls;
using SellingManagermenWF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellingManagermenWF.UserControls
{
    public partial class ExportingBillManager : Form
    {
        public ExportingBillManager()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
            LoadData(); 
            LoadProduct();
            LoadClient();
        }

        private void LoadData()
        {
            string qr = "Select MaPX,MaKH,HangHoa.MaHang,HangHoa.TenHang,NgayBan,SoLuongBan,GiaBan,SoLuongBan*GiaBan as ThanhTien from PhieuXuat inner join HangHoa on PhieuXuat.MaHang=HangHoa.MaHang ";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            dgvphieuxuat.DataSource = dt;
        }

        private void LoadProduct()
        {
            string qr = "Select * From HangHoa"; 
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            cbtenhang.DataSource = dt;
            cbtenhang.DisplayMember = "TenHang";
            cbtenhang.ValueMember = "MaHang";
        }
        private void LoadClient()
        {
            string qr = "Select * from KhachHang";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            cbtenkh.DataSource = dt;
            cbtenkh.DisplayMember = "TenKH";
            cbtenkh.ValueMember = "MaKH";
        }

        private void dgvthemtk_Click(object sender, EventArgs e)
        {
            int r = dgvphieuxuat.CurrentCell.RowIndex;
            this.tbmapx.Text = dgvphieuxuat.Rows[r].Cells[0].Value.ToString();
            this.cbtenkh.SelectedValue = dgvphieuxuat.Rows[r].Cells[1].Value.ToString();
            //this.tbtenkh.Text = dgvphieuxuat.Rows[r].Cells[1].Value.ToString();
            //this.tbdiachi.Text = dgvphieuxuat.Rows[r].Cells[2].Value.ToString();
            //this.tbsdt.Text = dgvphieuxuat.Rows[r].Cells[3].Value.ToString();
            this.cbtenhang.SelectedValue = dgvphieuxuat.Rows[r].Cells[2].Value.ToString();
            this.dtngayban.Text = dgvphieuxuat.Rows[r].Cells[4].Value.ToString();
            this.tbsoluong.Text = dgvphieuxuat.Rows[r].Cells[5].Value.ToString();
            this.tbgiaban.Text = dgvphieuxuat.Rows[r].Cells[6].Value.ToString();
            //dgvphieuxuat.CurrentRow.Cells[8].Value = (int.Parse(dgvphieuxuat.CurrentRow.Cells[6].Value.ToString()) * int.Parse(dgvphieuxuat.CurrentRow.Cells[7].Value.ToString()));
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string timkiem = tbSearch.Text;
            string qr = $"Select * From DangNhap where TenDN Like \'{timkiem}%\'";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            if (dt.Rows.Count == 0)
            {
                LoadData();
                return;
            }
            dgvphieuxuat.DataSource = dt;
        }

        private void Matutang()
        {
            string qr = "Select MaPX,MaKH,HangHoa.MaHang,HangHoa.TenHang,NgayBan,SoLuongBan,GiaBan,SoLuongBan*GiaBan as ThanhTien from PhieuXuat inner join HangHoa on PhieuXuat.MaHang=HangHoa.MaHang ";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);

            dgvphieuxuat.DataSource = dt;
            string s = "";
            if (dt.Rows.Count <= 0)
                s = "MAPX0001";
            else
            {
                int k;
                s = "MAPX";
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString().Substring(4, 4));
                k = k + 1;
                if (k < 10) s = s + "000";
                else if (k < 100)
                    s = s + "00";
                else if (k < 1000)
                    s = s + "0";
                //else if (k < 10000)
                //    s = s + "0";
                s = s + k.ToString();
            }
            tbmapx.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.tbmapx.Enabled = false;
            if (string.IsNullOrWhiteSpace(tbsoluong.Text) || string.IsNullOrWhiteSpace(tbgiaban.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Matutang();

            ExportingBill pxe = new ExportingBill();
            pxe.MaKH = cbtenkh.SelectedValue.ToString();
            pxe.MaHang = cbtenhang.SelectedValue.ToString();
            pxe.NgayBan = DateTime.Parse(dtngayban.Text);
            pxe.MaPX = tbmapx.Text;
            pxe.SoLuongBan = int.Parse(tbsoluong.Text);
            pxe.GiaBan = int.Parse(tbgiaban.Text);


            if (DbSQLiteConnection.AddExportingBill(pxe))
                MessageBox.Show("Bill added!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add bill.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.tbmapx.Enabled = false;
            if (string.IsNullOrWhiteSpace(tbmapx.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ExportingBill pxe = new ExportingBill();
            pxe.MaKH = cbtenkh.SelectedValue.ToString();
            pxe.MaHang = cbtenhang.SelectedValue.ToString();
            pxe.NgayBan = DateTime.Parse(dtngayban.Text);
            pxe.MaPX = tbmapx.Text;
            pxe.SoLuongBan = int.Parse(tbsoluong.Text);
            pxe.GiaBan = int.Parse(tbgiaban.Text);

            if (DbSQLiteConnection.UpdateExportingBill(pxe))
            {
                MessageBox.Show("Bill updated!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tinhtongsp();
            }
                
            else
                MessageBox.Show("Failed to updated bill.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadData();
        }
        public void tinhtongsp()
        {   //Tinh tổng có bn cột
            //int sp = dgvphieuxuat.Rows.Count;
            //sp = sp - 1;
            //textBox1.Text = sp.ToString();

            //Tính tổng all tiền
            int tien = dgvphieuxuat.Rows.Count;
            int thanhtien = 0;
            for (int i = 0; i < tien - 1; i++)
            {
                thanhtien += int.Parse(dgvphieuxuat.Rows[i].Cells["Thanhtien"].Value.ToString());
            }
            textBox1.Text = thanhtien.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.tbmapx.Enabled = false;
            if (dgvphieuxuat.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select a row to delete!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ExportingBill pxe = new ExportingBill();
            pxe.MaPX = tbmapx.Text;
            if (DbSQLiteConnection.RemoveExportingBill(pxe))
            {
                MessageBox.Show("Bill deleted!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tinhtongsp();
            }             
            else
                MessageBox.Show("Failed to delete bill.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadData();
        }
    }
}