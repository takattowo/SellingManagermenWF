using SellingManagermenWF.UserControls;

namespace SellingManagermenWF
{
    public partial class WhatYouSeeIsWhatYouGet : Form
    {
        public static WhatYouSeeIsWhatYouGet? form;
        public WhatYouSeeIsWhatYouGet()
        {
            InitializeComponent();
        }

        Form? activedForm;

        void AddForm(Form _stuff)
        {
            CloseForm(activedForm);

            _stuff.Height = 0;

            _stuff.FormBorderStyle = FormBorderStyle.None;
            _stuff.TopLevel = false;
            _stuff.Location = new Point(0, 0);
            _stuff.Dock = DockStyle.Fill;

            _stuff.TopMost = true;
            pnForm.Controls.Add(_stuff);
            _stuff.Show();
            _stuff.BringToFront();
            activedForm = _stuff;
        }

        void CloseForm(Form? _f)
        {
            if (activedForm is not null)
            {
                activedForm.Close();
                activedForm = null;
            }
        }

        public static Login? lForm;
        private void Form1_Load(object sender, EventArgs e)
        {
            form = this;
            AddForm(lForm = new());
        }
        
        public static AccountManager? amForm;
        private void rjButton5_Click(object sender, EventArgs e)
        {
            if (activedForm != amForm)
                AddForm(amForm = new());
        }

        private void rjButton8_Click(object sender, EventArgs e)
        {
            if (activedForm != lForm)
                AddForm(lForm = new());

            btnLoggout.Visible = false;
            btnAccount.Visible = false;
            btnClient.Visible = false;
            btnExport.Visible = false;
            btnImport.Visible = false;
            btnManufacture.Visible = false;
            btnProduct.Visible = false;
            btnLogin.Visible = true;

            if(Login.form is not null && activedForm == lForm)
                Login.form.pnWibu.Visible = false;
        }

        public static ProductManager? pForm;
        private void rjButton3_Click(object sender, EventArgs e)
        {
            if (activedForm != pForm)
                AddForm(pForm = new());
        }
    }
}