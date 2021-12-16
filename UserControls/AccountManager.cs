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
    public partial class AccountManager : Form
    {
        public AccountManager()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ActiveControl = label1;
            LoadNV(); 
        }

        private void LoadNV()
        {
            string qr = "Select * from DangNhap";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            dgvthemtk.DataSource = dt;
            dgvthemtk.Columns["MatKhau"].Visible = false;
        }

        private void dgvthemtk_Click(object sender, EventArgs e)
        {
            int r = dgvthemtk.CurrentCell.RowIndex;
            this.tbtk.Text = dgvthemtk.Rows[r].Cells[0].Value.ToString();
            this.tbmk.Text = dgvthemtk.Rows[r].Cells[1].Value.ToString();
            this.cbquyen.SelectedIndex = cbquyen.FindStringExact(dgvthemtk.Rows[r].Cells[2].Value.ToString().Trim());
            this.tbht.Text = dgvthemtk.Rows[r].Cells[4].Value.ToString();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            string timkiem = tbSearch.Text;
            string qr = $"Select * From DangNhap where TenDN Like \'{timkiem}%\'";
            DataTable dt = DbSQLiteConnection.GetDataTable(qr);
            if (dt.Rows.Count == 0)
            {
                LoadNV();
                return;
            }
            dgvthemtk.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbtk.Text) || string.IsNullOrWhiteSpace(tbmk.Text) || string.IsNullOrWhiteSpace(tbht.Text) || cbquyen.SelectedIndex < 0)
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserLogin dne = new();
            dne.TenDN = tbtk.Text;
            dne.MatKhau = tbmk.Text;
            dne.HoTen = tbht.Text;
            dne.Quyen = cbquyen.Text;
            dne.TrangThai = "Verified";

            if (DbSQLiteConnection.AddUser(dne))
                MessageBox.Show("User added!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to add user.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadNV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbtk.Text) || string.IsNullOrWhiteSpace(tbmk.Text) || string.IsNullOrWhiteSpace(tbht.Text) || cbquyen.SelectedIndex < 0)
            {
                MessageBox.Show("Field(s) missing!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            UserLogin dne = new();
            dne.TenDN = tbtk.Text;
            dne.MatKhau = tbmk.Text;
            dne.HoTen = tbht.Text;
            dne.Quyen = cbquyen.Text;
            dne.TrangThai = "Verified";
            dne.Loi = 0;

            if (DbSQLiteConnection.UpdateUser(dne))
                MessageBox.Show("User updated!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to updated user.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadNV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(dgvthemtk.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Select a row to delete!", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            UserLogin dne = new();

            dne.TenDN = tbtk.Text;
            if (DbSQLiteConnection.RemoveUser(dne))
                MessageBox.Show("User deleted!", "Task failedn't failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Failed to delete user.", "Task failedn failefullyn't", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadNV();
        }
    }
}