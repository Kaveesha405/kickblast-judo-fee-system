using Programming_Assignment_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programming_Assignment__
{
    public partial class ChatForm : Form
    {
        
        
        public ChatForm()
        {
            InitializeComponent();
        }

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            HomePage homePage = new HomePage();
            homePage.Show();
            this.Hide();
        }


        private void guna2TileButton1_Click(object sender, EventArgs e)
        {

        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string userMessage = txtMessage.Text.Trim();
            if (!string.IsNullOrEmpty(userMessage))
            {
                txtChatLog.AppendText("You: " + userMessage + Environment.NewLine);

                txtMessage.Clear();

                SimulateAdminReply();
            }


        }

        private void SimulateAdminReply()
        {
            string adminReply = "Admin: Thanks for your message! We'll get back to you soon." + Environment.NewLine;
            txtChatLog.AppendText(adminReply);
        }

    }
}
