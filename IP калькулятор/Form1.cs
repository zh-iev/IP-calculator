using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IP_калькулятор {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string A = textBox1.Text;
            string B = textBox2.Text;
            string C = textBox7.Text;
            string D = textBox8.Text;
            string E = textBox9.Text;
            if ((A == "") | (B == "") | (C == "") |
                (D == "") | (E == "")) {
                MessageBox.Show("Заполните все окошки!");
                return;
            }
            int[] mask = new int[4];
            int[] ip = new int[4];
            int ed = Convert.ToInt32(B);
            double hosts;
            //  ХОСТЫ:
            if ((ed >= 0) && (ed <= 30)) {
                hosts = Math.Pow(2, 32 - ed) - 2;
                textBox3.Text = hosts.ToString();
            }
            else {
                hosts = 0;
                textBox3.Text = hosts.ToString();
            }
            //  МАСКА:
            if ((ed <= 32) && (ed >= 24)) {
                for (int i = 0; i < 3; i++) {
                    mask[i] = 255;
                }
                mask[3] = 256 - Convert.ToInt32(Math.Pow(2, 32 - ed));
            }
            if ((ed < 24) && (ed >= 16)) {
                mask[0] = 255; mask[1] = 255;
                mask[2] = 256 - Convert.ToInt32(Math.Pow(2, 24 - ed));
                mask[3] = 0;
            }
            if ((ed < 16) && (ed >= 9)) {
                mask[0] = 255;
                mask[1] = 256 - Convert.ToInt32(Math.Pow(2, 16 - ed));
            }
            if ((ed > 0) && (ed < 9)) {
                mask[0] = 256 - Convert.ToInt32(Math.Pow(2, 8 - ed));
            }
            string maska = "";
            for (int i = 0; i < 4; i++) {
                maska += mask[i].ToString() + ".";
            }
            textBox4.Text = maska.Substring(0, maska.Length - 1);
            //ВВОД IP АДРЕСA
            ip[0] = Convert.ToInt32(A);
            ip[1] = Convert.ToInt32(C);
            ip[2] = Convert.ToInt32(D);
            ip[3] = Convert.ToInt32(E);
            //АДРЕС СЕТИ
            int l = 0; //шаг в отличной триаде
            for (int i = 0; i < 4; i++) {
                if (mask[i] != 255) {
                    l = Convert.ToInt32(Math.Pow(2, ((32 - ed) % 8)));
                    ip[i] = l * (ip[i] / l);
                }
                if (mask[i] == 0) {
                    ip[i] = 0;
                }
            }
            string network = "";
            for (int i = 0; i < 4; i++) {
                network += ip[i].ToString() + ".";
            }
            textBox5.Text = network.Substring(0, network.Length - 1);
            //BROADCAST
            for (int i = 0; i < 4; i++) {
                if (mask[i] == 0) {
                    ip[i] = 255;
                }
                if ((mask[i] != 255) && (mask[i] != 0)) {
                    ip[i] = ip[i] + l - 1;
                }
            }
            network = "";
            for (int i = 0; i < 4; i++) {
                network += ip[i].ToString() + ".";
            }
            textBox6.Text = network.Substring(0, network.Length - 1);
        }
        //ОГРАНИЧЕНИЯ:
        private void textBox1_TextChanged(object sender, EventArgs e) {
            string A = textBox1.Text;
            if (A == "") {
                return;
            }
            if (!int.TryParse(A, out int A1)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox1.Text = "";
                return;
            }
            if ((Convert.ToInt32(A) > 255) | (Convert.ToInt32(A) < 0)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox1.Text = "";
            }
        }

        private void textBox7_TextChanged_1(object sender, EventArgs e) {
            string B = textBox7.Text;
            if (B == "") {
                return;
            }
            if (!int.TryParse(B, out int B1)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox7.Text = "";
                return;
            }
            if ((Convert.ToInt32(B) > 255) | (Convert.ToInt32(B) < 0)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox7.Text = "";
            }
        }
        private void textBox8_TextChanged_1(object sender, EventArgs e) {
            string C = textBox8.Text;
            if (C == "") {
                return;
            }
            if (!int.TryParse(C, out int C1)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox8.Text = "";
                return;
            }
            if ((Convert.ToInt32(C) > 255) | (Convert.ToInt32(C) < 0)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox8.Text = "";
            }
        }
        private void textBox9_TextChanged_1(object sender, EventArgs e) {
            string D = textBox9.Text;
            if (D == "") {
                return;
            }
            if (!int.TryParse(D, out int D1)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox9.Text = "";
                return;
            }
            if ((Convert.ToInt32(D) > 255) | (Convert.ToInt32(D) < 0)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox9.Text = "";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e) {
            string E = textBox2.Text;
            if (E == "") {
                return;
            }
            if (!int.TryParse(E, out int E1)) {
                MessageBox.Show("Введите число от 0 до 255!");
                textBox2.Text = "";
                return;
            }
            if ((Convert.ToInt32(E) > 32) | (Convert.ToInt32(E) < 0)) {
                MessageBox.Show("Введите число от 0 до 32!");
                textBox2.Text = "";
            }
        }
    }
}
