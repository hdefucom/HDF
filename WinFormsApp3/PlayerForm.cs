using System;
using System.Windows.Forms;

namespace GHIS.RIS
{
    public partial class PlayerForm : Form
    {
        public PlayerForm()
        {
            InitializeComponent();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void PlayVideo(string videoUrl)
        {
            WindowsMediaPlayer.URL = videoUrl;
        }

        private void PlayerForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
