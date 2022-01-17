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
    public partial class ManufactureManager : Form
    {
        public ManufactureManager()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
            LoadManufacture(); 
        }

        private void LoadManufacture()
        {
            string qr = "Select * from NhaCungCap";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            dgvnhacungcap.DataSource = dt;
        }

        private void dgvthemtk_Click(object sender, EventArgs e)
        {
            int r = dgvnhacungcap.CurrentCell.RowIndex;
            this.tbmancc.Text = dgvnhacungcap.Rows[r].Cells[0].Value.ToString();
            this.tbtenncc.Text = dgvnhacungcap.Rows[r].Cells[1].Value.ToString();
            this.tbdiachi.Text = dgvnhacungcap.Rows[r].Cells[2].Value.ToString();
            this.tbdienthoai.Text = dgvnhacungcap.Rows[r].Cells[3].Value.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string timkiem = tbSearch.Text;
            string qr = $"Select * From DangNhap where TenDN Like \'{timkiem}%\'";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            if (dt.Rows.Count == 0)
            {
                LoadManufacture();
                return;
            }
            dgvnhacungcap.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbtenncc.Text) || string.IsNullOrWhiteSpace(tbdiachi.Text) || string.IsNullOrWhiteSpace(tbdiachi.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Provider ncce = new Provider();
            ncce.MaNCC = tbmancc.Text;
            ncce.TenNCC = tbtenncc.Text;
            ncce.DiaChiNCC = tbdiachi.Text;
            ncce.DienThoaiNCC = tbdienthoai.Text;

            if (DbSQLiteConnection.AddProvider(ncce))
                MessageBox.Show("Provider added!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add provider.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadManufacture();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbtenncc.Text) || string.IsNullOrWhiteSpace(tbdiachi.Text) || string.IsNullOrWhiteSpace(tbdiachi.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Provider ncce = new Provider();
            ncce.MaNCC = tbmancc.Text;
            ncce.TenNCC = tbtenncc.Text;
            ncce.DiaChiNCC = tbdiachi.Text;
            ncce.DienThoaiNCC = tbdienthoai.Text;

            if (DbSQLiteConnection.UpdateProvider(ncce))
                MessageBox.Show("Provider updated!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to updated provider.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadManufacture();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dgvnhacungcap.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select a row to delete!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Provider ncce = new Provider();
            ncce.MaNCC = tbmancc.Text;

            if (DbSQLiteConnection.RemoveProvider(ncce))
                MessageBox.Show("User deleted!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to delete user.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadManufacture();
        }
    }
}