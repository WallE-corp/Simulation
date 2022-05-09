namespace MobileMock
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            tbxServerAddress.Text = "127.0.0.1:3000";
            gbxControls.Enabled = false;
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }
    }
}