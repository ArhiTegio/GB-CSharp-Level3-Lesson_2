using System;
using System.Windows.Forms;
using MailSender;
using MailSenderLib;
using static System.Console;

namespace MailSenderWF
{
    public partial class Form1 : Form
    {
        Control control = new Control();
        public Form1()
        {
            InitializeComponent();

            object a = 1;
            object b = 1;

			WriteLine(a==b);
			WriteLine(a.Equals(b));
        }

        private void button1_Click(object sender, EventArgs e) => control.Send(textBox1.Text, textBox1.Text);        

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
