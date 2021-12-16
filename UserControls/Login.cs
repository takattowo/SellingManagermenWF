using RJCodeAdvance.RJControls;
using SellingManagermenWF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SellingManagermenWF.UserControls
{
    public partial class Login : Form
    {
        internal static Login? form;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            form = this;
            ActiveControl = label1;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(userName.Texts) || string.IsNullOrEmpty(password.Texts))
            {
                MessageBox.Show("Field(s) missing.", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string qr = $"Select * From DangNhap where TenDN='{userName.Texts}' And MatKhau='{password.Texts}'";
            var dt = DbSQLiteConnection.GetDataTable(qr);
            if (dt.Rows.Count != 0)
            {
                pnWibu.Visible = true;
                MessageBox.Show("Login successfully~", "Ah yes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var right = dt.Rows[0][2].ToString().Trim();
                WhatYouSeeIsWhatYouGet.form.btnLogin.Visible = false;
                WhatYouSeeIsWhatYouGet.form.btnLoggout.Visible = true;
                switch (right)
                {
                    case "Admin":
                        WhatYouSeeIsWhatYouGet.form.btnAccount.Visible = true;
                        WhatYouSeeIsWhatYouGet.form.btnClient.Visible = true;
                        WhatYouSeeIsWhatYouGet.form.btnExport.Visible = true;
                        WhatYouSeeIsWhatYouGet.form.btnImport.Visible = true;
                        WhatYouSeeIsWhatYouGet.form.btnManufacture.Visible = true;
                        WhatYouSeeIsWhatYouGet.form.btnProduct.Visible = true;
                        break;
                    case "Slave Importer":
                        WhatYouSeeIsWhatYouGet.form.btnImport.Visible = true;
                        break;
                    case "Slave Exporter":
                        WhatYouSeeIsWhatYouGet.form.btnExport.Visible = true;
                        break;
                }
            }
            else
            {
                MessageBox.Show("Wrong username or password.", "Check your logic", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            password.Texts = "";
            userName.Texts = "";
        }
    }
}
