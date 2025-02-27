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
            SetupUI();
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

        private void SetupUI()
        {
            this.Text = "Генератор паролей";
            this.Size = new System.Drawing.Size(400, 200);

            Label lblLength = new Label() { Text = "Длина пароля:", Left = 10, Top = 20, Width = 100 };
            this.Controls.Add(lblLength);

            txtLength = new TextBox() { Left = 120, Top = 20, Width = 50 };
            this.Controls.Add(txtLength);

            btnGenerate = new Button() { Text = "Сгенерировать", Left = 180, Top = 20, Width = 100 };
            btnGenerate.Click += btnGenerate_Click;
            this.Controls.Add(btnGenerate);

            txtPassword = new TextBox() { Left = 10, Top = 60, Width = 350, ReadOnly = true };
            this.Controls.Add(txtPassword);
        }
    }
}


