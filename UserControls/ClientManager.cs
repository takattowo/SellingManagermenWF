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
    public partial class ClientManager : Form
    {
        public ClientManager()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
            LoadClient(); 
        }

        private void LoadClient()
        {
            string qr = "Select * from KhachHang";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            dgvkhachhang.DataSource = dt;
        }

        private void dgvthemtk_Click(object sender, EventArgs e)
        {
            int r = dgvkhachhang.CurrentCell.RowIndex;
            this.tbmakh.Text = dgvkhachhang.Rows[r].Cells[0].Value.ToString();
            this.tbtenkh.Text = dgvkhachhang.Rows[r].Cells[1].Value.ToString();
            this.tbdiachi.Text = dgvkhachhang.Rows[r].Cells[2].Value.ToString();
            this.tbdienthoai.Text = dgvkhachhang.Rows[r].Cells[3].Value.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string timkiem = tbSearch.Text;
            string qr = $"Select * From DangNhap where TenDN Like \'{timkiem}%\'";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            if (dt.Rows.Count == 0)
            {
                LoadClient();
                return;
            }
            dgvkhachhang.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbmakh.Text) || string.IsNullOrWhiteSpace(tbtenkh.Text) || string.IsNullOrWhiteSpace(tbdiachi.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer dne = new();
            dne.MaKH = tbmakh.Text;
            dne.TenKH = tbtenkh.Text;
            dne.DiaChiKH = tbdiachi.Text;
            dne.DienThoaiKH = tbdienthoai.Text;

            if (DbSQLiteConnection.AddClient(dne))
                MessageBox.Show("Client added!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add cliebt.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadClient();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbmakh.Text) || string.IsNullOrWhiteSpace(tbtenkh.Text) || string.IsNullOrWhiteSpace(tbdiachi.Text))
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Customer dne = new();
            dne.MaKH = tbmakh.Text;
            dne.TenKH = tbtenkh.Text;
            dne.DiaChiKH = tbdiachi.Text;
            dne.DienThoaiKH = tbdienthoai.Text;


            if (DbSQLiteConnection.UpdateClient(dne))
                MessageBox.Show("Client updated!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to updated client.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadClient();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dgvkhachhang.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select a row to delete!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Customer dne = new();
            dne.MaKH = tbmakh.Text;

            if (DbSQLiteConnection.RemoveClient(dne))
                MessageBox.Show("Client deleted!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to delete client.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadClient();
        }
    }
}