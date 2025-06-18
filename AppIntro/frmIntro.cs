using System.Diagnostics.Eventing.Reader;

namespace AppIntro
{
    public partial class frmIntro : Form
    {
        public frmIntro()
        {
            InitializeComponent();
        }

        private void frmIntro_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtPalavra;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnAcao_Click(object sender, EventArgs e)
        {
            lblPalavra.Text = txtPalavra.Text.Trim();
            txtPalavra.Text = string.Empty;
            this.ActiveControl = txtPalavra;
        }
    }
}
