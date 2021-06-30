using System.Windows.Forms;

namespace GourmetGame.View.Components
{
    public partial class DialogueMessage : Form
    {
        public string Result { get; set; }

        public DialogueMessage(string label, string formName)
        {
            FormName = formName;
            Message = label;
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            Result = txtInput.Text;

            if (string.IsNullOrEmpty(Result))
            {
                Result = "null";
            }

            DialogResult = DialogResult.OK;            
        }

        private void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Result = "null";
            DialogResult = DialogResult.OK;            
        }
    }
}
