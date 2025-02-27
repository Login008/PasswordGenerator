using System;
using System.Text;
using System.Windows.Forms;

namespace generatorOfPasses
{
    public partial class Form1 : Form
    {
        private static readonly string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()";
        private TextBox txtLength;
        private Button btnGenerate;
        private TextBox txtPassword;

        public Form1()
        {
            InitializeComponent();
        }

        private string GeneratePassword(int length)
        {
            StringBuilder password = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                password.Append(chars[random.Next(chars.Length)]);
            }

            return password.ToString();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtLength.Text, out int length) && length > 0)
            {
                txtPassword.Text = GeneratePassword(length);
            }
            else
            {
                MessageBox.Show("Введите корректную длину пароля!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


