using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace penjadwalan_pm
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            //LV PROPERTIES
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            //CONSTRUCT COLUMNS
            listView1.Columns.Add("No.", 50);
            listView1.Columns.Add("Individu 1", 100);

            //LV PROPERTIES
            listView2.View = View.Details;
            listView2.FullRowSelect = true;

            //CONSTRUCT COLUMNS
            listView2.Columns.Add("No.", 50);
            listView2.Columns.Add("Individu 1", 100);
        }

        public void add1(String no, String individu_1)
        {

            //ROW
            String[] row = { no, individu_1 };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);

        }

        public void add2(String no, String individu_1)
        {

            //ROW
            String[] row = { no, individu_1};
            ListViewItem item = new ListViewItem(row);
            listView2.Items.Add(item);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            label1.Text = "yes";

            Random randNum = new Random();
            for (int i = 0; i < 25; i++)
            {
                hari1[i] = randNum.Next(min, int_hari);
                hari2[i] = randNum.Next(min, int_hari);
                add1((i + 1).ToString(),  hari1[i].ToString());
                add2((i + 1).ToString(), hari2[i].ToString());

            }

            label3.Text = "6";
            label4.Text = "5";
            label5.Text = "5";

            label6.Text = "1";
            label7.Text = "2";
            label8.Text = "3";
        }


        int min = 1;
        int int_hari = 6;
        int[] hari1 = new int[25];
        int[] hari2 = new int[25];

        public void mutasi()
        {
            if (label1.Text == "yes")
            {
                for (int i = 0; i < 25; i++)
                {
                    hari1[i] = hari2[i];
                    listView1.Items.Clear();
                }
                for (int i = 0; i < 25; i++)
                {
                    add1((i + 1).ToString(), hari1[i].ToString());
                }

                int gen = 1;
                int gen1 =0;
                gen1 += gen;
                label2.Text = gen1.ToString();

            }
        }

        public void nyoba()
        {
            var krom1 = double.Parse(label3.Text);
            var krom2 = double.Parse(label4.Text);
            var krom3 = double.Parse(label5.Text);

            var kram1 = double.Parse(label6.Text);
            var kram2 = double.Parse(label7.Text);
            var kram3 = double.Parse(label8.Text);
            double[] krom = { krom1, krom2, krom3};
            double[] kram = { kram1, kram2, kram3 };
            Array.Sort(krom,kram);
            for (int i = 0; i < krom.Length; i++)
            {
                label12.Text = (krom[i++].ToString());
                label13.Text = (krom[i++].ToString());
                label14.Text = (krom[i++].ToString());
            }

            for (int i = 0; i < kram.Length; i++)
            {
                label9.Text = (kram[i++].ToString());
                label10.Text = (kram[i++].ToString());
                label11.Text = (kram[i++].ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            mutasi();
            nyoba();
        }
    }
}
