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
    public partial class ImportingBillManager : Form
    {
        public ImportingBillManager()
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
            string qr = "Select MaPN,MaNCC,MaHang,NgayNhap,SoLuongNhap,GiaNhap,SoLuongNhap*GiaNhap as ThanhTien from PhieuNhap";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            dgvphieunhap.DataSource = dt;
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
            string qr = "Select * from NhaCungCap";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            cbtenncc.DataSource = dt;
            cbtenncc.DisplayMember = "TenNCC";
            cbtenncc.ValueMember = "MaNCC";
        }

        private void dgvthemtk_Click(object sender, EventArgs e)
        {
            int r = dgvphieunhap.CurrentCell.RowIndex;
            this.tbsopn.Text = dgvphieunhap.Rows[r].Cells[0].Value.ToString();
            //this.cb1.SelectedValue = dgvphieunhap.Rows[r].Cells[1].Value.ToString();
            this.cbtenncc.SelectedValue = dgvphieunhap.Rows[r].Cells[1].Value.ToString();
            //this.tbdiachi.Text = dgvphieunhap.Rows[r].Cells[3].Value.ToString();
            // this.tbsdt.Text = dgvphieunhap.Rows[r].Cells[4].Value.ToString();
            this.cbtenhang.SelectedValue = dgvphieunhap.Rows[r].Cells[2].Value.ToString();

            this.tbsoluongnhap.Text = dgvphieunhap.Rows[r].Cells[4].Value.ToString();
            this.tbgianhap.Text = dgvphieunhap.Rows[r].Cells[5].Value.ToString();
            this.dtngaynhap.Text = dgvphieunhap.Rows[r].Cells[3].Value.ToString();
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
            dgvphieunhap.DataSource = dt;
        }
        private void Matutang()
        {
            string qr = "Select MaPN,MaNCC,MaHang,NgayNhap,SoLuongNhap,GiaNhap,SoLuongNhap*GiaNhap as ThanhTien from PhieuNhap";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);

            dgvphieunhap.DataSource = dt;
            string s = "";
            if (dt.Rows.Count <= 0)
                s = "MAPN0001";
            else
            {
                int k;
                s = "MAPN";
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
            tbsopn.Text = s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = false;
            this.tbsopn.Enabled = false;
            if (string.IsNullOrWhiteSpace(tbsoluongnhap.Text) || string.IsNullOrWhiteSpace(tbgianhap.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Matutang();

            ImportingBill pne = new ImportingBill();
            pne.MaNCC = cbtenncc.SelectedValue.ToString();
            pne.MaHang = cbtenhang.SelectedValue.ToString();
            pne.NgayNhap = DateTime.Parse(dtngaynhap.Text);
            pne.MaPN = tbsopn.Text;
            pne.SoLuongNhap = int.Parse(tbsoluongnhap.Text);
            pne.GiaNhap = int.Parse(tbgianhap.Text);


            if (DbSQLiteConnection.AddImportingBill(pne))
                MessageBox.Show("Bill added!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add bill.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbsopn.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ImportingBill pne = new ImportingBill();
            pne.MaNCC = cbtenncc.SelectedValue.ToString();
            pne.MaHang = cbtenhang.SelectedValue.ToString();
            pne.NgayNhap = DateTime.Parse(dtngaynhap.Text);
            pne.MaPN = tbsopn.Text;
            pne.SoLuongNhap = int.Parse(tbsoluongnhap.Text);
            pne.GiaNhap = int.Parse(tbgianhap.Text);

            if (DbSQLiteConnection.UpdateImportingBill(pne))
                MessageBox.Show("Bill updated!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to updated bill.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dgvphieunhap.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select a row to delete!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ImportingBill pne = new ImportingBill();
            pne.MaPN = tbsopn.Text;
            if (DbSQLiteConnection.RemoveImportingBill(pne))
                MessageBox.Show("Bill deleted!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to delete bill.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadData();
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            StatisticForm frm = new();
            frm.Show();
        }
    }
}