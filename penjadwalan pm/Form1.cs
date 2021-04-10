using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace penjadwalan_pm
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\penjadwalan pm\penjadwalan pm\penjadwalan.mdf;Integrated Security=True");
        SqlDataAdapter adp_dosen, adp_hari, adp_jam, adp_kelas, adp_matkul, adp_ruang;
        DataTable table1 = new DataTable();
        DataTable table2 = new DataTable();
        DataTable table3 = new DataTable();
        DataTable table4 = new DataTable();
        DataTable table5 = new DataTable();
        DataTable table6 = new DataTable();
        int pos;

        public SqlDataAdapter Adp_dosen { get => adp_dosen; set => adp_dosen = value; }
        public SqlDataAdapter Adp_hari { get => adp_hari; set => adp_hari = value; }
        public SqlDataAdapter Adp_jam { get => adp_jam; set => adp_jam = value; }
        public SqlDataAdapter Adp_kelas { get => adp_kelas; set => adp_kelas = value; }
        public SqlDataAdapter Adp_matkul { get => adp_matkul; set => adp_matkul = value; }
        public SqlDataAdapter Adp_ruang { get => adp_ruang; set => adp_ruang = value; }

        private static Random rnd = new Random();
        int rnd_hari = rnd.Next(1, 5);
        int rnd_jam = rnd.Next(1, 10);
        int rnd_ruang = rnd.Next(1, 10);
        int rnd_matkul = rnd.Next(1, 25);
        int rnd_kelas = rnd.Next(1, 13);
        int rnd_dosen = rnd.Next(1, 71);

    

    public Form1()
        {
            InitializeComponent();

            //LV PROPERTIES
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            //CONSTRUCT COLUMNS
            listView1.Columns.Add("Kode_matkul", 100);
            listView1.Columns.Add("matkul", 100);
            listView1.Columns.Add("hari", 100);
            listView1.Columns.Add("jam", 100);
            listView1.Columns.Add("ruang", 100);
            listView1.Columns.Add("kelas", 100);
            listView1.Columns.Add("dosen", 100);

            int Min = 0;
            int Max = 20;

            // this declares an integer array with 5 elements
            // and initializes all of them to their default value
            // which is zero
            int[] test2 = new int[5];

            Random randNum = new Random();
            for (int i = 0; i < test2.Length; i++)
            {
                test2[i] = randNum.Next(Min, Max);
                listView2.Items.Add(test2[i].ToString());
            }
        }
        private void add(String kode_matkul, String matkul, String hari, String jam, String ruang, String kelas, String dosen)
        {

            //ROW
            String[] row = { kode_matkul, matkul, hari, jam, ruang, kelas, dosen };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //random 
            label8.Text = rnd_matkul.ToString();
            label9.Text = rnd_matkul.ToString();
            label10.Text = rnd_hari.ToString();
            label11.Text = rnd_jam.ToString();
            label12.Text = rnd_ruang.ToString();
            label13.Text = rnd_kelas.ToString();
            label14.Text = rnd_dosen.ToString();

            Adp_dosen = new SqlDataAdapter("select * from dosen where id_dosen = "+long.Parse(label8.Text), con);
            Adp_hari = new SqlDataAdapter("select * from hari", con);
            Adp_jam = new SqlDataAdapter("select * from jam", con);
            Adp_kelas = new SqlDataAdapter("select * from kelas", con);
            Adp_matkul = new SqlDataAdapter("select * from matkul2", con);
            Adp_ruang = new SqlDataAdapter("select * from ruang", con);
            Adp_dosen.Fill(table1);
            Adp_hari.Fill(table2);
            Adp_jam.Fill(table3);
            Adp_kelas.Fill(table4);
            Adp_matkul.Fill(table5);
            Adp_ruang.Fill(table6);
            showData(pos);

            add(label8.Text, label9.Text, label10.Text, label11.Text, label12.Text,label13.Text,label14.Text);

        }


        public void showData(int index)
        {
            label15.Text = table5.Rows[index][1].ToString();
            label16.Text = table5.Rows[index][2].ToString();
            label17.Text = table2.Rows[index][1].ToString();
            label18.Text = table3.Rows[index][1].ToString();
            label19.Text = table6.Rows[index][1].ToString();
            label20.Text = table4.Rows[index][1].ToString();
            label21.Text = table1.Rows[index][1].ToString();

        }

            

    }
}
