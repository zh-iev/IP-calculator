using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLua;

namespace IP_калькулятор {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            string prefix = textBox2.Text;
            string firstIP = textBox1.Text;
            string secondIP = textBox7.Text;
            string thirdIP = textBox8.Text;
            string fourthIP = textBox9.Text;
            if ((firstIP == "") | (prefix == "") | (secondIP == "") |
                (thirdIP == "") | (fourthIP == "")) {
                MessageBox.Show("Заполните все значения!");
                return;
            }
            int[] ip = new int[4] { Convert.ToInt32(firstIP), Convert.ToInt32(secondIP),
                Convert.ToInt32(thirdIP), Convert.ToInt32(fourthIP) };
            int ed = Convert.ToInt32(prefix);

            using (Lua luaState = new Lua()) {
                luaState.DoFile(@"C:\Users\zhiev\source\repos\IPcalc\script.lua");

                //  ХОСТЫ:
                luaState["ed"] = ed;
                LuaFunction findHosts = luaState["findHosts"] as LuaFunction;
                textBox3.Text = findHosts.Call()[0].ToString();

                //  МАСКА:
                LuaFunction findMask = luaState["findMask"] as LuaFunction;
                LuaTable mask = findMask.Call().GetValue(0) as LuaTable;
                string maska = "";
                foreach (var value in mask.Values) {
                    maska += value.ToString() + ".";
                }
                textBox4.Text = maska.Substring(0, maska.Length - 1);

                //АДРЕС СЕТИ
                LuaFunction findNetwork = luaState["findNetwork"] as LuaFunction;
                LuaTable network = findNetwork.Call(ip[0], ip[1], ip[2], ip[3]).GetValue(0) as LuaTable;
                string networkstr = "";
                foreach (var value in network.Values) {
                    networkstr += value.ToString() + ".";
                }
                textBox5.Text = networkstr.Substring(0, networkstr.Length - 1);

                //BROADCAST
                LuaFunction findBroadcast = luaState["findBroadcast"] as LuaFunction;
                LuaTable broadcast = findBroadcast.Call().GetValue(0) as LuaTable;
                string broadcaststr = "";
                foreach (var value in broadcast.Values) {
                    broadcaststr += value.ToString() + ".";
                }
                textBox6.Text = broadcaststr.Substring(0, broadcaststr.Length - 1);
            }
        }
        // ПРОВЕРКА ВВОДА:
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
