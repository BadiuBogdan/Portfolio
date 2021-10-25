using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chat
{
    public partial class Form1 : Form
    {
        private bool connect;
        private MyClient client;
        private string TextCitit;
        private string userText;
        private Dictionary<string, string> textPart;
        private bool finish;

        public Form1()
        {
            InitializeComponent();
            connect = false;
            userText = String.Empty;
            textPart = new Dictionary<string, string>();
            finish = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            client = new MyClient();
            client.SendMessage(tbConnect.Text + "!::user::!");
            lName.Text = lName.Text + tbConnect.Text;

            tbConnect.Text = "";
            tbConnect.Enabled = false;
            btnConnect.Enabled = false;
            connect = true;
            Thread afisThred = new Thread(() => this.ReceiveMessage(tbAfisareMesaj, client));
            afisThred.Start();
        }

        private void btnTrimite_Click(object sender, EventArgs e)
        {

            if (userText.Equals(""))
            {

                MessageBox.Show("Trebuie sa alegeti un participant!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                tbAfisareMesaj.AppendText("You: " + tbScrieMesaj.Text + Environment.NewLine);
                client.SendMessage(userText + "!::text::!" + tbScrieMesaj.Text);
                textPart[userText] = textPart[userText]+"You: " + tbScrieMesaj.Text + Environment.NewLine;
            }

            tbScrieMesaj.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connect == true)
            {
                client.SendMessage("Stop!");

            }
            finish = true;
        }

        private void tbScrieMesaj_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnTrimite_Click((object)sender, (EventArgs)e);
                e.SuppressKeyPress = true;
            }
        }


        private void tbConnect_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                btnConnect_Click((object)sender, (EventArgs)e);
                e.SuppressKeyPress = true;
            }
        }

        public void ReceiveMessage(TextBox textBox, MyClient client)
        {

            while (true)
            {

                string message = String.Empty;

                try
                {
                    message = client.StreamReader.ReadLine();
                    if (message != null && message.Contains("!::cList::!"))
                    {
                        string[] temp = message.Split('!');
                        bool entryFound = false;
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            object val1 = row.Cells[0].Value;

                            if (val1 != null && val1.Equals(temp[0]))
                            {
                                entryFound = true;
                                break;
                            }
                        }

                        if (!entryFound)
                        {
                            dataGridView1.Invoke(new Action(() => dataGridView1.Rows.Add(temp[0])));
                            textPart.Add(temp[0], "");
                        }

                    }
                    else
                    {
                        if (message != null)
                        {
                            string[] temp = message.Split(':');
                            textPart[temp[0]] = textPart[temp[0]] + message + Environment.NewLine;

                        }
                    }
                    if (finish)
                    {
                        break;
                    }
                }
                catch
                {
                    break;
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectR = dataGridView1.Rows[index];

            if (connect && (textPart.Count > 0) && selectR.Cells[0].Value!=null)
            {
                userText = selectR.Cells[0].Value.ToString();
                Thread chatAfis = new Thread(() => this.ChatAfis(tbAfisareMesaj, userText));
                chatAfis.Start();
            }
            else
            {
                MessageBox.Show("Asteptati sa se conecteze participantii sau alegeti un participant", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void ChatAfis(TextBox textBox, string user)
        {
            textBox.Invoke(new Action(() => textBox.Text = String.Empty));
            textBox.Invoke(new Action(() => textBox.Text = textPart[user]));
        }
    }
}
