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

namespace penjadwalan_pm
{
    public partial class Form3 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\PC\source\repos\penjadwalan pm\penjadwalan pm\penjadwalan.mdf;Integrated Security=True");
        SqlDataAdapter adp_dosen, adp_hari, adp_jam, adp_kelas, adp_matkul, adp_ruang;

        public SqlDataAdapter Adp_dosen { get => adp_dosen; set => adp_dosen = value; }
        public SqlDataAdapter Adp_hari { get => adp_hari; set => adp_hari = value; }
        public SqlDataAdapter Adp_jam { get => adp_jam; set => adp_jam = value; }
        public SqlDataAdapter Adp_kelas { get => adp_kelas; set => adp_kelas = value; }
        public SqlDataAdapter Adp_matkul { get => adp_matkul; set => adp_matkul = value; }
        public SqlDataAdapter Adp_ruang { get => adp_ruang; set => adp_ruang = value; }
        DataTable table = new DataTable();
        SqlCommand cmd;
        SqlDataReader mdr;

        public Form3()
        {
            InitializeComponent();
            // INDIVIDU
            //LV PROPERTIES
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            //CONSTRUCT COLUMNS
            listView1.Columns.Add("No.", 50);
            listView1.Columns.Add("Individu 1", 100);
            listView1.Columns.Add("Individu 2", 100);
            listView1.Columns.Add("Individu 3", 100);
            listView1.Columns.Add("Individu 4", 100);

            // CROSSOVER
            //LV PROPERTIES
            listView2.View = View.Details;
            listView2.FullRowSelect = true;

            //CONSTRUCT COLUMNS
            listView2.Columns.Add("No.", 50);
            listView2.Columns.Add("Individu 1", 100);
            listView2.Columns.Add("Individu 2", 100);
            listView2.Columns.Add("Individu 3", 100);
            listView2.Columns.Add("Individu 4", 100);

            //LV PROPERTIES
            listView3.View = View.Details;
            listView3.FullRowSelect = true;

            //CONSTRUCT COLUMNS
            listView3.Columns.Add("No.", 50);
            listView3.Columns.Add("Individu 1", 100);
            listView3.Columns.Add("Individu 2", 100);
            listView3.Columns.Add("Individu 3", 100);
            listView3.Columns.Add("Individu 4", 100);
        }
        public void add1(String no, String individu_1, String individu_2, String individu_3, String individu_4)
        {

            //ROW
            String[] row = { no, individu_1, individu_2, individu_3, individu_4 };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);

        }
        public void add2(String no, String individu_1, String individu_2, String individu_3, String individu_4)
        {

            //ROW
            String[] row = { no, individu_1, individu_2, individu_3, individu_4 };
            ListViewItem item = new ListViewItem(row);
            listView2.Items.Add(item);

        }
        public void add3(String no, String individu_1, String individu_2, String individu_3, String individu_4)
        {

            //ROW
            String[] row = { no, individu_1, individu_2, individu_3, individu_4 };
            ListViewItem item = new ListViewItem(row);
            listView3.Items.Add(item);

        }
        //CROSSOVER POP
        int[] hari_cross1 = new int[25];
        int[] hari_cross2 = new int[25];
        int[] hari_cross3 = new int[25];
        int[] hari_cross4 = new int[25];

        int[] jam_cross1 = new int[25];
        int[] jam_cross2 = new int[25];
        int[] jam_cross3 = new int[25];
        int[] jam_cross4 = new int[25];

        int[] ruang_cross1 = new int[25];
        int[] ruang_cross2 = new int[25];
        int[] ruang_cross3 = new int[25];
        int[] ruang_cross4 = new int[25];

        int[] matkul_cross1 = new int[25];
        int[] matkul_cross2 = new int[25];
        int[] matkul_cross3 = new int[25];
        int[] matkul_cross4 = new int[25];

        int[] kelas_cross1 = new int[25];
        int[] kelas_cross2 = new int[25];
        int[] kelas_cross3 = new int[25];
        int[] kelas_cross4 = new int[25];

        int[] dosen_cross1 = new int[25];
        int[] dosen_cross2 = new int[25];
        int[] dosen_cross3 = new int[25];
        int[] dosen_cross4 = new int[25];

        int[] sks_matkul_cross1 = new int[25];
        int[] sks_matkul_cross2 = new int[25];
        int[] sks_matkul_cross3 = new int[25];
        int[] sks_matkul_cross4 = new int[25];
        public void get()
        {

            // Make the array.
            string[] results1 = new string[25];
            string[] results2 = new string[25];
            string[] results3 = new string[25];
            string[] results4 = new string[25];

            // Populate the array.
            // Note that SubItems includes the items, too.

            for (int i = 0; i < 25; i++)
            {
                results1[i] = listView2.Items[i].SubItems[1].Text;
                results2[i] = listView2.Items[i].SubItems[2].Text;
                results3[i] = listView2.Items[i].SubItems[3].Text;
                results4[i] = listView2.Items[i].SubItems[4].Text;
                //individu1
                    for (int c = 0; c < 1; c++)
                    {
                        string[] resultnyoba = results1[i].Split(' ');
                        hari_cross1[i] = Int32.Parse(resultnyoba[c]);
                    }
                    for (int c = 0; c < 2; c++)
                    {
                        string[] resultnyoba = results1[i].Split(' ');
                        jam_cross1[i] = Int32.Parse(resultnyoba[c]);
                    }
                    for (int c = 0; c < 3; c++)
                    {
                        string[] resultnyoba = results1[i].Split(' ');
                        ruang_cross1[i] = Int32.Parse(resultnyoba[c]);
                    }
                    for (int c = 0; c < 4; c++)
                    {
                        string[] resultnyoba = results1[i].Split(' ');
                        matkul_cross1[i] = Int32.Parse(resultnyoba[c]);
                    }
                    for (int c = 0; c < 5; c++)
                    {
                        string[] resultnyoba = results1[i].Split(' ');
                        kelas_cross1[i] = Int32.Parse(resultnyoba[c]);
                    }
                    for (int c = 0; c < 6; c++)
                    {
                        string[] resultnyoba = results1[i].Split(' ');
                        dosen_cross1[i] = Int32.Parse(resultnyoba[c]);
                    }

                //individu2
                for (int c = 0; c < 1; c++)
                {
                    string[] resultnyoba = results2[i].Split(' ');
                    hari_cross2[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 2; c++)
                {
                    string[] resultnyoba = results2[i].Split(' ');
                    jam_cross2[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 3; c++)
                {
                    string[] resultnyoba = results2[i].Split(' ');
                    ruang_cross2[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 4; c++)
                {
                    string[] resultnyoba = results2[i].Split(' ');
                    matkul_cross2[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 5; c++)
                {
                    string[] resultnyoba = results2[i].Split(' ');
                    kelas_cross2[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 6; c++)
                {
                    string[] resultnyoba = results2[i].Split(' ');
                    dosen_cross2[i] = Int32.Parse(resultnyoba[c]);
                }

                //individu3
                for (int c = 0; c < 1; c++)
                {
                    string[] resultnyoba = results3[i].Split(' ');
                    hari_cross3[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 2; c++)
                {
                    string[] resultnyoba = results3[i].Split(' ');
                    jam_cross3[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 3; c++)
                {
                    string[] resultnyoba = results3[i].Split(' ');
                    ruang_cross3[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 4; c++)
                {
                    string[] resultnyoba = results3[i].Split(' ');
                    matkul_cross3[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 5; c++)
                {
                    string[] resultnyoba = results3[i].Split(' ');
                    kelas_cross3[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 6; c++)
                {
                    string[] resultnyoba = results3[i].Split(' ');
                    dosen_cross3[i] = Int32.Parse(resultnyoba[c]);
                }

                //individu4
                for (int c = 0; c < 1; c++)
                {
                    string[] resultnyoba = results4[i].Split(' ');
                    hari_cross4[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 2; c++)
                {
                    string[] resultnyoba = results4[i].Split(' ');
                    jam_cross4[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 3; c++)
                {
                    string[] resultnyoba = results4[i].Split(' ');
                    ruang_cross4[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 4; c++)
                {
                    string[] resultnyoba = results4[i].Split(' ');
                    matkul_cross4[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 5; c++)
                {
                    string[] resultnyoba = results4[i].Split(' ');
                    kelas_cross4[i] = Int32.Parse(resultnyoba[c]);
                }
                for (int c = 0; c < 6; c++)
                {
                    string[] resultnyoba = results4[i].Split(' ');
                    dosen_cross4[i] = Int32.Parse(resultnyoba[c]);
                }
                add3((i + 1).ToString(),
            hari_cross1[i].ToString() + " " + jam_cross1[i].ToString() + " " + ruang_cross1[i].ToString() + " " + matkul_cross1[i].ToString() + " " + kelas_cross1[i].ToString() + " " + dosen_cross1[i].ToString(),
            hari_cross2[i].ToString() + " " + jam_cross2[i].ToString() + " " + ruang_cross2[i].ToString() + " " + matkul_cross2[i].ToString() + " " + kelas_cross2[i].ToString() + " " + dosen_cross2[i].ToString(),
            hari_cross3[i].ToString() + " " + jam_cross3[i].ToString() + " " + ruang_cross3[i].ToString() + " " + matkul_cross3[i].ToString() + " " + kelas_cross3[i].ToString() + " " + dosen_cross3[i].ToString(),
            hari_cross4[i].ToString() + " " + jam_cross4[i].ToString() + " " + ruang_cross4[i].ToString() + " " + matkul_cross4[i].ToString() + " " + kelas_cross4[i].ToString() + " " + dosen_cross4[i].ToString()
                );
            }

            RuleGene_cross1();
            RuleGene_cross2();
            RuleGene_cross3();
            RuleGene_cross4();
            fitness_cross();

        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public void RuleGene_cross1()
        {

            textBox28.Text = textBox20.Text;

            textBox21.Text = textBox9.Text;

        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public void RuleGene_cross2()
        {

            textBox27.Text = textBox19.Text;

            textBox24.Text = textBox10.Text;

        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public void RuleGene_cross3()
        {
            //RULE 1
            double penal_crosskrom31 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari_cross3[i] == hari_cross3[j] && jam_cross3[i] == jam_cross3[j] && ruang_cross3[i] == ruang_cross3[j])
                        penal_crosskrom31 = penal_crosskrom31 + 1;
                }

            }

            //RULE 2
            double penal_crosskrom32 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari_cross3[i] == hari_cross3[j] && jam_cross3[i] == jam_cross3[j] && matkul_cross3[i] == matkul_cross3[j])
                        penal_crosskrom32 = penal_crosskrom32 + 1;
                }

            }

            //RULE 3
            double penal_crosskrom33 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari_cross3[i] == hari_cross3[j] && jam_cross3[i] == jam_cross3[j] && dosen_cross3[i] == dosen_cross3[j])
                        penal_crosskrom33 = penal_crosskrom33 + 1;
                }

            }

            //RULE 4
            double penal_crosskrom34 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul_cross3[i] <= 6 && kelas_cross3[i] <= 3)
                    penal_crosskrom34 = penal_crosskrom34 - 1;
                if (matkul_cross3[i] > 6 && matkul_cross3[i] <= 11 && kelas_cross3[i] > 3 && kelas_cross3[i] <= 6)
                    penal_crosskrom34 = penal_crosskrom34 - 1;
                if (matkul_cross3[i] > 11 && matkul_cross3[i] <= 17 && kelas_cross3[i] > 6 && kelas_cross3[i] <= 9)
                    penal_crosskrom34 = penal_crosskrom34 - 1;
                if (matkul_cross3[i] > 17 && matkul_cross3[i] <= 19 && kelas_cross3[i] > 9 && kelas_cross3[i] <= 11)
                    penal_crosskrom34 = penal_crosskrom34 - 1;
                if (matkul_cross3[i] >= 20 && kelas_cross3[i] >= 12)
                    penal_crosskrom34 = penal_crosskrom34 - 1;
            }

            //RULE 5
            double penal_crosskrom35 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul_cross3[i] == 1 && kelas_cross3[i] == 0)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 2 && kelas_cross3[i] == 15 && kelas_cross3[i] == 13 && kelas_cross3[i] == 42 && kelas_cross3[i] == 7)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 3 && kelas_cross3[i] == 40 && kelas_cross3[i] == 14 && kelas_cross3[i] == 47 && kelas_cross3[i] == 34 && kelas_cross3[i] == 15)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 4 && kelas_cross3[i] == 57)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 5 && kelas_cross3[i] == 63 && kelas_cross3[i] == 42 && kelas_cross3[i] == 7 && kelas_cross3[i] == 2 && kelas_cross3[i] == 15)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 6 && kelas_cross3[i] == 40 && kelas_cross3[i] == 14 && kelas_cross3[i] == 47 && kelas_cross3[i] == 34 && kelas_cross3[i] == 15)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 7 && kelas_cross3[i] == 46)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 8 && kelas_cross3[i] == 2 && kelas_cross3[i] == 48 && kelas_cross3[i] == 11 && kelas_cross3[i] == 69 && kelas_cross3[i] == 61)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 9 && kelas_cross3[i] == 41 && kelas_cross3[i] == 43 && kelas_cross3[i] == 51)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 10 && kelas_cross3[i] == 64 && kelas_cross3[i] == 56 && kelas_cross3[i] == 9 && kelas_cross3[i] == 45 && kelas_cross3[i] == 19)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 11 && kelas_cross3[i] == 63 && kelas_cross3[i] == 12 && kelas_cross3[i] == 35 && kelas_cross3[i] == 62 && kelas_cross3[i] == 22 && kelas_cross3[i] == 65 && kelas_cross3[i] == 32 && kelas_cross3[i] == 33 && kelas_cross3[i] == 68)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 12 && kelas_cross3[i] == 40 && kelas_cross3[i] == 53 && kelas_cross3[i] == 36 && kelas_cross3[i] == 47 && kelas_cross3[i] == 51 && kelas_cross3[i] == 41 && kelas_cross3[i] == 46)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 13 && kelas_cross3[i] == 2 && kelas_cross3[i] == 48 && kelas_cross3[i] == 11 && kelas_cross3[i] == 69 && kelas_cross3[i] == 61)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 14 && kelas_cross3[i] == 46 && kelas_cross3[i] == 42 && kelas_cross3[i] == 8)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 15 && kelas_cross3[i] == 33 && kelas_cross3[i] == 12 && kelas_cross3[i] == 62)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 16 && kelas_cross3[i] == 40 && kelas_cross3[i] == 11 && kelas_cross3[i] == 43 && kelas_cross3[i] == 47 && kelas_cross3[i] == 61 && kelas_cross3[i] == 51 && kelas_cross3[i] == 41 && kelas_cross3[i] == 46)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 17 && kelas_cross3[i] == 62 && kelas_cross3[i] == 24 && kelas_cross3[i] == 35 && kelas_cross3[i] == 69 && kelas_cross3[i] == 42)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 18 && kelas_cross3[i] == 8 && kelas_cross3[i] == 24 && kelas_cross3[i] == 43 && kelas_cross3[i] == 69 && kelas_cross3[i] == 34)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 19 && kelas_cross3[i] == 69)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 20 && kelas_cross3[i] == 40 && kelas_cross3[i] == 30 && kelas_cross3[i] == 14 && kelas_cross3[i] == 47 && kelas_cross3[i] == 39 && kelas_cross3[i] == 46)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 21 && kelas_cross3[i] == 8 && kelas_cross3[i] == 24 && kelas_cross3[i] == 34)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 22 && kelas_cross3[i] == 0)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 23 && kelas_cross3[i] == 33 && kelas_cross3[i] == 29 && kelas_cross3[i] == 57 && kelas_cross3[i] == 11 && kelas_cross3[i] == 12 && kelas_cross3[i] == 19)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 24 && kelas_cross3[i] == 64 && kelas_cross3[i] == 69 && kelas_cross3[i] == 61 && kelas_cross3[i] == 41 && kelas_cross3[i] == 2)
                    penal_crosskrom35 = penal_crosskrom35 - 1;
                if (matkul_cross3[i] == 25 && kelas_cross3[i] == 7 && kelas_cross3[i] == 55 && kelas_cross3[i] == 13 && kelas_cross3[i] == 57 && kelas_cross3[i] == 19 && kelas_cross3[i] == 32)
                    penal_crosskrom35 = penal_crosskrom35 - 1;

            }

            //RULE 6
            int[] jamsks_matkul_cross3 = new int[25];
            double penal_crosskrom36 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    // Adp_matkul = new SqlDataAdapter("select * from matkul2where id_matkul = " + matkul1[i], con);

                    con.Open();
                    string query = "select * from matkul2 where id_matkul = " + matkul_cross3[i];
                    cmd = new SqlCommand(query, con);
                    mdr = cmd.ExecuteReader();
                    if (mdr.Read())
                    {
                        label12.Text = mdr["sks_total"].ToString();
                    }
                    else
                    {
                        label12.Text = "Solusi Tidak Ditemukan";
                    }
                    con.Close();
                    sks_matkul_cross2[i] = Int32.Parse(label12.Text);

                    jamsks_matkul_cross3[i] = jam_cross3[i] + sks_matkul_cross3[i] - 1;
                    label13.Text = jamsks_matkul_cross3[i].ToString();
                    if (jamsks_matkul_cross3[i] > 11)
                        penal_crosskrom36 = penal_crosskrom36 + 1;
                }

            }

            //RULE 7
            double penal_crosskrom37 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (matkul_cross3[i] == matkul_cross3[j])
                        penal_crosskrom37 = penal_crosskrom37 + 1;
                }

            }


            //PENALTY & FITNESS

            double penalty_individu_cross3 = penal_crosskrom31 + penal_crosskrom32 + penal_crosskrom33 + penal_crosskrom34 + penal_crosskrom35 + penal_crosskrom36 + penal_crosskrom37;
            double fitness_individu_cross3;

            fitness_individu_cross3 = 1 / (1 + penalty_individu_cross3);

            textBox26.Text = penalty_individu_cross3.ToString();

            textBox23.Text = fitness_individu_cross3.ToString();

        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public void RuleGene_cross4()
        {
            //RULE 1
            double penal_crosskrom41 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari_cross4[i] == hari_cross4[j] && jam_cross4[i] == jam_cross4[j] && ruang_cross4[i] == ruang_cross4[j])
                        penal_crosskrom41 = penal_crosskrom41 + 1;
                }

            }

            //RULE 2
            double penal_crosskrom42 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari_cross4[i] == hari_cross4[j] && jam_cross4[i] == jam_cross4[j] && matkul_cross4[i] == matkul_cross4[j])
                        penal_crosskrom42 = penal_crosskrom42 + 1;
                }

            }

            //RULE 3
            double penal_crosskrom43 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari_cross4[i] == hari_cross4[j] && jam_cross4[i] == jam_cross4[j] && dosen_cross4[i] == dosen_cross4[j])
                        penal_crosskrom43 = penal_crosskrom43 + 1;
                }

            }

            //RULE 4
            double penal_crosskrom44 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul_cross4[i] <= 6 && kelas_cross4[i] <= 3)
                    penal_crosskrom44 = penal_crosskrom44 - 1;
                if (matkul_cross4[i] > 6 && matkul_cross4[i] <= 11 && kelas_cross4[i] > 3 && kelas_cross4[i] <= 6)
                    penal_crosskrom44 = penal_crosskrom44 - 1;
                if (matkul_cross4[i] > 11 && matkul_cross4[i] <= 17 && kelas_cross4[i] > 6 && kelas_cross4[i] <= 9)
                    penal_crosskrom44 = penal_crosskrom44 - 1;
                if (matkul_cross4[i] > 17 && matkul_cross4[i] <= 19 && kelas_cross4[i] > 9 && kelas_cross4[i] <= 11)
                    penal_crosskrom44 = penal_crosskrom44 - 1;
                if (matkul_cross4[i] >= 20 && kelas_cross4[i] >= 12)
                    penal_crosskrom44 = penal_crosskrom44 - 1;
            }

            //RULE 5
            double penal_crosskrom45 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul_cross4[i] == 1 && kelas_cross4[i] == 0)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 2 && kelas_cross4[i] == 15 && kelas_cross4[i] == 13 && kelas_cross4[i] == 42 && kelas_cross4[i] == 7)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 3 && kelas_cross4[i] == 40 && kelas_cross4[i] == 14 && kelas_cross4[i] == 47 && kelas_cross4[i] == 34 && kelas_cross4[i] == 15)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 4 && kelas_cross4[i] == 57)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 5 && kelas_cross4[i] == 63 && kelas_cross4[i] == 42 && kelas_cross4[i] == 7 && kelas_cross4[i] == 2 && kelas_cross4[i] == 15)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 6 && kelas_cross4[i] == 40 && kelas_cross4[i] == 14 && kelas_cross4[i] == 47 && kelas_cross4[i] == 34 && kelas_cross4[i] == 15)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 7 && kelas_cross4[i] == 46)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 8 && kelas_cross4[i] == 2 && kelas_cross4[i] == 48 && kelas_cross4[i] == 11 && kelas_cross4[i] == 69 && kelas_cross4[i] == 61)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 9 && kelas_cross4[i] == 41 && kelas_cross4[i] == 43 && kelas_cross4[i] == 51)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 10 && kelas_cross4[i] == 64 && kelas_cross4[i] == 56 && kelas_cross4[i] == 9 && kelas_cross4[i] == 45 && kelas_cross4[i] == 19)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 11 && kelas_cross4[i] == 63 && kelas_cross4[i] == 12 && kelas_cross4[i] == 35 && kelas_cross4[i] == 62 && kelas_cross4[i] == 22 && kelas_cross4[i] == 65 && kelas_cross4[i] == 32 && kelas_cross4[i] == 33 && kelas_cross4[i] == 68)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 12 && kelas_cross4[i] == 40 && kelas_cross4[i] == 53 && kelas_cross4[i] == 36 && kelas_cross4[i] == 47 && kelas_cross4[i] == 51 && kelas_cross4[i] == 41 && kelas_cross4[i] == 46)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 13 && kelas_cross4[i] == 2 && kelas_cross4[i] == 48 && kelas_cross4[i] == 11 && kelas_cross4[i] == 69 && kelas_cross4[i] == 61)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 14 && kelas_cross4[i] == 46 && kelas_cross4[i] == 42 && kelas_cross4[i] == 8)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 15 && kelas_cross4[i] == 33 && kelas_cross4[i] == 12 && kelas_cross4[i] == 62)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 16 && kelas_cross4[i] == 40 && kelas_cross4[i] == 11 && kelas_cross4[i] == 43 && kelas_cross4[i] == 47 && kelas_cross4[i] == 61 && kelas_cross4[i] == 51 && kelas_cross4[i] == 41 && kelas_cross4[i] == 46)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 17 && kelas_cross4[i] == 62 && kelas_cross4[i] == 24 && kelas_cross4[i] == 35 && kelas_cross4[i] == 69 && kelas_cross4[i] == 42)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 18 && kelas_cross4[i] == 8 && kelas_cross4[i] == 24 && kelas_cross4[i] == 43 && kelas_cross4[i] == 69 && kelas_cross4[i] == 34)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 19 && kelas_cross4[i] == 69)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 20 && kelas_cross4[i] == 40 && kelas_cross4[i] == 30 && kelas_cross4[i] == 14 && kelas_cross4[i] == 47 && kelas_cross4[i] == 39 && kelas_cross4[i] == 46)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 21 && kelas_cross4[i] == 8 && kelas_cross4[i] == 24 && kelas_cross4[i] == 34)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 22 && kelas_cross4[i] == 0)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 23 && kelas_cross4[i] == 33 && kelas_cross4[i] == 29 && kelas_cross4[i] == 57 && kelas_cross4[i] == 11 && kelas_cross4[i] == 12 && kelas_cross4[i] == 19)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 24 && kelas_cross4[i] == 64 && kelas_cross4[i] == 69 && kelas_cross4[i] == 61 && kelas_cross4[i] == 41 && kelas_cross4[i] == 2)
                    penal_crosskrom45 = penal_crosskrom45 - 1;
                if (matkul_cross4[i] == 25 && kelas_cross4[i] == 7 && kelas_cross4[i] == 55 && kelas_cross4[i] == 13 && kelas_cross4[i] == 57 && kelas_cross4[i] == 19 && kelas_cross4[i] == 32)
                    penal_crosskrom45 = penal_crosskrom45 - 1;

            }

            //RULE 6
            int[] jamsks_matkul_cross4 = new int[25];
            double penal_crosskrom46 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    // Adp_matkul = new SqlDataAdapter("select * from matkul2where id_matkul = " + matkul1[i], con);

                    con.Open();
                    string query = "select * from matkul2 where id_matkul = " + matkul_cross4[i];
                    cmd = new SqlCommand(query, con);
                    mdr = cmd.ExecuteReader();
                    if (mdr.Read())
                    {
                        label12.Text = mdr["sks_total"].ToString();
                    }
                    else
                    {
                        label12.Text = "Solusi Tidak Ditemukan";
                    }
                    con.Close();
                    sks_matkul_cross4[i] = Int32.Parse(label12.Text);

                    jamsks_matkul_cross4[i] = jam_cross4[i] + sks_matkul_cross4[i] - 1;
                    label13.Text = jamsks_matkul_cross4[i].ToString();
                    if (jamsks_matkul_cross4[i] > 11)
                        penal_crosskrom46 = penal_crosskrom46 + 1;
                }

            }

            //RULE 7
            double penal_crosskrom47 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (matkul_cross4[i] == matkul_cross4[j])
                        penal_crosskrom47 = penal_crosskrom47 + 1;
                }

            }


            //PENALTY & FITNESS

            double penalty_individu_cross4 = penal_crosskrom41 + penal_crosskrom42 + penal_crosskrom43 + penal_crosskrom44 + penal_crosskrom45 + penal_crosskrom46 + penal_crosskrom47;
            double fitness_individu_cross4;

            fitness_individu_cross4 = 1 / (1 + penalty_individu_cross4);

            textBox25.Text = penalty_individu_cross4.ToString();

            textBox22.Text = fitness_individu_cross4.ToString();

        }

        public void fitness_cross()
        {

            var krom1 = double.Parse(textBox28.Text);
            var krom2 = double.Parse(textBox27.Text);
            var krom3 = double.Parse(textBox26.Text);
            var krom4 = double.Parse(textBox25.Text);

            double[] krom = { krom1, krom2, krom3, krom4 };
            Array.Sort(krom);
            for (int i = 0; i < krom.Length; i++)
            {
                label24.Text = (krom[i++].ToString());
                label25.Text = (krom[i++].ToString());
                label26.Text = (krom[i++].ToString());
                label27.Text = (krom[i++].ToString());
            }
        }

        //MUTASI-GENERATE
        public void mutasi()
        {
            
                for (int i = 0; i < 25; i++)
                {
                    hari1[i] = hari_cross1[i];
                    hari2[i] = hari_cross2[i];
                    hari3[i] = hari_cross3[i];
                    hari4[i] = hari_cross4[i];

                    jam1[i] = jam_cross1[i];
                    jam2[i] = jam_cross2[i];
                    jam3[i] = jam_cross3[i];
                    jam4[i] = jam_cross4[i];

                    ruang1[i] = ruang_cross1[i];
                    ruang2[i] = ruang_cross2[i];
                    ruang3[i] = ruang_cross3[i];
                    ruang4[i] = ruang_cross4[i];

                    matkul1[i] = matkul_cross1[i];
                    matkul2[i] = matkul_cross2[i];
                    matkul3[i] = matkul_cross3[i];
                    matkul4[i] = matkul_cross4[i];

                    kelas1[i] = kelas_cross1[i];
                    kelas2[i] = kelas_cross2[i];
                    kelas3[i] = kelas_cross3[i];
                    kelas4[i] = kelas_cross4[i];

                    dosen1[i] = dosen_cross1[i];
                    dosen2[i] = dosen_cross2[i];
                    dosen3[i] = dosen_cross3[i];
                    dosen4[i] = dosen_cross4[i];
                    listView1.Items.Clear();
                }
                for (int i = 0; i < 25; i++)
                {
                    add1((i + 1).ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang3[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString()
                    );
                }

            gen1 += gen;
            label28.Text = gen1.ToString();

            listView2.Items.Clear();
            runrule();
            fitness();
            get();

        }

        int min = 1;
        int int_hari = 6;
        int int_jam = 11;
        int int_ruang = 11;
        int int_matkul = 26;
        int int_kelas = 14;
        int int_dosen = 72;

        int[] hari1 = new int[25];
        int[] hari2 = new int[25];
        int[] hari3 = new int[25];
        int[] hari4 = new int[25];

        int[] jam1 = new int[25];
        int[] jam2 = new int[25];
        int[] jam3 = new int[25];
        int[] jam4 = new int[25];

        int[] ruang1 = new int[25];
        int[] ruang2 = new int[25];
        int[] ruang3 = new int[25];
        int[] ruang4 = new int[25];

        int[] matkul1 = new int[25];
        int[] matkul2 = new int[25];
        int[] matkul3 = new int[25];
        int[] matkul4 = new int[25];

        int[] kelas1 = new int[25];
        int[] kelas2 = new int[25];
        int[] kelas3 = new int[25];
        int[] kelas4 = new int[25];

        int[] dosen1 = new int[25];
        int[] dosen2 = new int[25];
        int[] dosen3 = new int[25];
        int[] dosen4 = new int[25];

        int[] sks_matkul1 = new int[25];
        int[] sks_matkul2 = new int[25];
        int[] sks_matkul3 = new int[25];
        int[] sks_matkul4 = new int[25];

        private void Form3_Load(object sender, EventArgs e)
        {

            //GENERATE RANDOM GENE

            Random randNum = new Random();
            for (int i = 0; i < 25; i++)
            {
                hari1[i] = randNum.Next(min, int_hari);
                hari2[i] = randNum.Next(min, int_hari);
                hari3[i] = randNum.Next(min, int_hari);
                hari4[i] = randNum.Next(min, int_hari);

                jam1[i] = randNum.Next(min, int_jam);
                jam2[i] = randNum.Next(min, int_jam);
                jam3[i] = randNum.Next(min, int_jam);
                jam4[i] = randNum.Next(min, int_jam);

                ruang1[i] = randNum.Next(min, int_ruang);
                ruang2[i] = randNum.Next(min, int_ruang);
                ruang3[i] = randNum.Next(min, int_ruang);
                ruang4[i] = randNum.Next(min, int_ruang);

                matkul1[i] = randNum.Next(min, int_matkul);
                matkul2[i] = randNum.Next(min, int_matkul);
                matkul3[i] = randNum.Next(min, int_matkul);
                matkul4[i] = randNum.Next(min, int_matkul);

                kelas1[i] = randNum.Next(min, int_kelas);
                kelas2[i] = randNum.Next(min, int_kelas);
                kelas3[i] = randNum.Next(min, int_kelas);
                kelas4[i] = randNum.Next(min, int_kelas);

                dosen1[i] = randNum.Next(min, int_dosen);
                dosen2[i] = randNum.Next(min, int_dosen);
                dosen3[i] = randNum.Next(min, int_dosen);
                dosen4[i] = randNum.Next(min, int_dosen);

                add1((i + 1).ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString()
                    );
            }

            runrule();
            fitness();
            get();

        }

        public void runrule()
        {
            RuleGene1();
            RuleGene2();
            RuleGene3();
            RuleGene4();
        }

        int gen = 1;
        int gen1 = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            int cekFitnes = Int32.Parse(label24.Text);
            if(cekFitnes != 0)
            {
                mutasi();
            }
            /*   do
               {
                   mutasi();
               }
               while (cekFitnes != 0); */
        }

        public void fitness()
            { 

            var krom1 = double.Parse(textBox8.Text);
            var krom2 = double.Parse(textBox7.Text);
            var krom3 = double.Parse(textBox6.Text);
            var krom4 = double.Parse(textBox5.Text);


            var pen1 = int.Parse(textBox1.Text);
            var pen2 = int.Parse(textBox2.Text);
            var pen3 = int.Parse(textBox3.Text);
            var pen4 = int.Parse(textBox4.Text);

            double[] krom = { krom1, krom2, krom3, krom4 };
            int[] pen = { pen1, pen2, pen3, pen4 };
            double[] no = { 1,2,3,4};
            Array.Sort(pen);
            Array.Sort(krom,no);

            for (int i = 0; i < krom.Length; i++)
            {
                textBox12.Text = (krom[i++].ToString());
                textBox11.Text = (krom[i++].ToString());
                textBox10.Text = (krom[i++].ToString());
                textBox9.Text = (krom[i++].ToString());
            }
            for (int i = 0; i < no.Length; i++)
            {
                textBox16.Text = (no[i++].ToString());
                textBox15.Text = (no[i++].ToString());
                textBox14.Text = (no[i++].ToString());
                textBox13.Text = (no[i++].ToString());
            }
            for (int i = 0; i < pen.Length; i++)
            {
                textBox20.Text = (pen[i++].ToString());
                textBox19.Text = (pen[i++].ToString());
                textBox18.Text = (pen[i++].ToString());
                textBox17.Text = (pen[i++].ToString());
            }
            //input cross

            for (int i = 0; i < 25; i++)
            {
                if(textBox16.Text == "1" && textBox15.Text == "2" || textBox16.Text == "2" && textBox15.Text == "1")
                {
                    add2((i + 1).ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString()
                    );
                }

                if (textBox16.Text == "1" && textBox15.Text == "3" || textBox16.Text == "3" && textBox15.Text == "1")
                {
                    add2((i + 1).ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString()
                    );
                }

                if (textBox16.Text == "1" && textBox15.Text == "4" || textBox16.Text == "4" && textBox15.Text == "1")
                {
                    add2((i + 1).ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString()
                    );
                }

                if (textBox16.Text == "2" && textBox15.Text == "3" || textBox16.Text == "3" && textBox15.Text == "2")
                {
                    add2((i + 1).ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString()
                    );
                }

                if (textBox16.Text == "2" && textBox15.Text == "4" || textBox16.Text == "4" && textBox15.Text == "3")
                {
                    add2((i + 1).ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString(),
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString()
                    );
                }

                if (textBox16.Text == "3" && textBox15.Text == "4" || textBox16.Text == "4" && textBox15.Text == "3")
                {
                    add2((i + 1).ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString(),
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString(),
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString()
                    );
                }

            }




            }



        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>




        public void RuleGene1()
        {
            //RULE 1
            double penal_1 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari1[i] == hari1[j] && jam1[i] == jam1[j] && ruang1[i] == ruang1[j])
                        penal_1 = penal_1 + 1;
                }

            }

            //RULE 2
            double penal_2 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari1[i] == hari1[j] && jam1[i] == jam1[j] && matkul1[i] == matkul1[j])
                        penal_2 = penal_2 + 1;
                }

            }

            //RULE 3
            double penal_3 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari1[i] == hari1[j] && jam1[i] == jam1[j] && dosen1[i] == dosen1[j])
                        penal_3 = penal_3 + 1;
                }

            }

            //RULE 4
            double penal_4 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul1[i] <= 6 && kelas1[i] <= 3)
                    penal_4 = penal_4 - 1;
                if (matkul1[i] > 6 && matkul1[i] <= 11 && kelas1[i] > 3 && kelas1[i] <= 6)
                    penal_4 = penal_4 - 1;
                if (matkul1[i] > 11 && matkul1[i] <= 17 && kelas1[i] > 6 && kelas1[i] <= 9)
                    penal_4 = penal_4 - 1;
                if (matkul1[i] > 17 && matkul1[i] <= 19 && kelas1[i] > 9 && kelas1[i] <= 11)
                    penal_4 = penal_4 - 1;
                if (matkul1[i] >= 20 && kelas1[i] >= 12)
                    penal_4 = penal_4 - 1;
            }

            //RULE 5
            double penal_5 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul1[i] == 1 && kelas1[i] == 0)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 2 && kelas1[i] == 15 && kelas1[i] == 13 && kelas1[i] == 42 && kelas1[i] == 7)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 3 && kelas1[i] == 40 && kelas1[i] == 14 && kelas1[i] == 47 && kelas1[i] == 34 && kelas1[i] == 15)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 4 && kelas1[i] == 57)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 5 && kelas1[i] == 63 && kelas1[i] == 42 && kelas1[i] == 7 && kelas1[i] == 2 && kelas1[i] == 15)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 6 && kelas1[i] == 40 && kelas1[i] == 14 && kelas1[i] == 47 && kelas1[i] == 34 && kelas1[i] == 15)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 7 && kelas1[i] == 46)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 8 && kelas1[i] == 2 && kelas1[i] == 48 && kelas1[i] == 11 && kelas1[i] == 69 && kelas1[i] == 61)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 9 && kelas1[i] == 41 && kelas1[i] == 43 && kelas1[i] == 51)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 10 && kelas1[i] == 64 && kelas1[i] == 56 && kelas1[i] == 9 && kelas1[i] == 45 && kelas1[i] == 19)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 11 && kelas1[i] == 63 && kelas1[i] == 12 && kelas1[i] == 35 && kelas1[i] == 62 && kelas1[i] == 22 && kelas1[i] == 65 && kelas1[i] == 32 && kelas1[i] == 33 && kelas1[i] == 68)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 12 && kelas1[i] == 40 && kelas1[i] == 53 && kelas1[i] == 36 && kelas1[i] == 47 && kelas1[i] == 51 && kelas1[i] == 41 && kelas1[i] == 46)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 13 && kelas1[i] == 2 && kelas1[i] == 48 && kelas1[i] == 11 && kelas1[i] == 69 && kelas1[i] == 61)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 14 && kelas1[i] == 46 && kelas1[i] == 42 && kelas1[i] == 8)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 15 && kelas1[i] == 33 && kelas1[i] == 12 && kelas1[i] == 62)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 16 && kelas1[i] == 40 && kelas1[i] == 11 && kelas1[i] == 43 && kelas1[i] == 47 && kelas1[i] == 61 && kelas1[i] == 51 && kelas1[i] == 41 && kelas1[i] == 46)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 17 && kelas1[i] == 62 && kelas1[i] == 24 && kelas1[i] == 35 && kelas1[i] == 69 && kelas1[i] == 42)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 18 && kelas1[i] == 8 && kelas1[i] == 24 && kelas1[i] == 43 && kelas1[i] == 69 && kelas1[i] == 34)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 19 && kelas1[i] == 69)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 20 && kelas1[i] == 40 && kelas1[i] == 30 && kelas1[i] == 14 && kelas1[i] == 47 && kelas1[i] == 39 && kelas1[i] == 46)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 21 && kelas1[i] == 8 && kelas1[i] == 24 && kelas1[i] == 34)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 22 && kelas1[i] == 0)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 23 && kelas1[i] == 33 && kelas1[i] == 29 && kelas1[i] == 57 && kelas1[i] == 11 && kelas1[i] == 12 && kelas1[i] == 19)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 24 && kelas1[i] == 64 && kelas1[i] == 69 && kelas1[i] == 61 && kelas1[i] == 41 && kelas1[i] == 2)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 25 && kelas1[i] == 7 && kelas1[i] == 55 && kelas1[i] == 13 && kelas1[i] == 57 && kelas1[i] == 19 && kelas1[i] == 32)
                    penal_5 = penal_5 - 1;

            }

            //RULE 6
            int[] jamsks_matkul = new int[25];
            double penal_6 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    // Adp_matkul = new SqlDataAdapter("select * from matkul2where id_matkul = " + matkul1[i], con);

                    con.Open();
                    string query = "select * from matkul2 where id_matkul = " + matkul1[i];
                    cmd = new SqlCommand(query, con);
                    mdr = cmd.ExecuteReader();
                    if (mdr.Read())
                    {
                        label12.Text = mdr["sks_total"].ToString();
                    }
                    else
                    {
                        label12.Text = "Solusi Tidak Ditemukan";
                    }
                    con.Close();
                    sks_matkul1[i] = Int32.Parse(label12.Text);

                    jamsks_matkul[i] = jam1[i] + sks_matkul1[i] - 1;
                    label13.Text = jamsks_matkul[i].ToString();
                    if (jamsks_matkul[i] > 11)
                        penal_6 = penal_6 + 1;
                }

            }

            //RULE 7
            double penal_7 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (matkul1[i] == matkul1[j])
                        penal_7 = penal_7 + 1;
                }

            }


            //PENALTY & FITNESS

            double penalty_individu1 = penal_1 + penal_2 + penal_3 + penal_4 + penal_5 + penal_6 + penal_7;
            double fitness_individu1;

            fitness_individu1 = 1 / (1 + penalty_individu1);

            textBox1.Text = penalty_individu1.ToString();

            textBox8.Text = fitness_individu1.ToString();
        }



        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public void RuleGene2()
        {
            //RULE 1
            double penalkrom2_1 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari2[i] == hari2[j] && jam2[i] == jam2[j] && ruang2[i] == ruang2[j])
                        penalkrom2_1 = penalkrom2_1 + 1;
                }

            }

            //RULE 2
            double penalkrom2_2 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari2[i] == hari2[j] && jam2[i] == jam2[j] && matkul2[i] == matkul2[j])
                        penalkrom2_2 = penalkrom2_2 + 1;
                }

            }

            //RULE 3
            double penalkrom2_3 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari2[i] == hari2[j] && jam2[i] == jam2[j] && dosen2[i] == dosen2[j])
                        penalkrom2_3 = penalkrom2_3 + 1;
                }

            }

            //RULE 4
            double penalkrom2_4 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul2[i] <= 6 && kelas2[i] <= 3)
                    penalkrom2_4 = penalkrom2_4 - 1;
                if (matkul2[i] > 6 && matkul2[i] <= 11 && kelas2[i] > 3 && kelas2[i] <= 6)
                    penalkrom2_4 = penalkrom2_4 - 1;
                if (matkul2[i] > 11 && matkul2[i] <= 17 && kelas2[i] > 6 && kelas2[i] <= 9)
                    penalkrom2_4 = penalkrom2_4 - 1;
                if (matkul2[i] > 17 && matkul2[i] <= 19 && kelas2[i] > 9 && kelas2[i] <= 11)
                    penalkrom2_4 = penalkrom2_4 - 1;
                if (matkul2[i] >= 20 && kelas2[i] >= 12)
                    penalkrom2_4 = penalkrom2_4 - 1;
            }

            //RULE 5
            double penalkrom2_5 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul2[i] == 1 && kelas2[i] == 0)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 2 && kelas2[i] == 15 && kelas2[i] == 13 && kelas2[i] == 42 && kelas2[i] == 7)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 3 && kelas2[i] == 40 && kelas2[i] == 14 && kelas2[i] == 47 && kelas2[i] == 34 && kelas2[i] == 15)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 4 && kelas2[i] == 57)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 5 && kelas2[i] == 63 && kelas2[i] == 42 && kelas2[i] == 7 && kelas2[i] == 2 && kelas2[i] == 15)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 6 && kelas2[i] == 40 && kelas2[i] == 14 && kelas2[i] == 47 && kelas2[i] == 34 && kelas2[i] == 15)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 7 && kelas2[i] == 46)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 8 && kelas2[i] == 2 && kelas2[i] == 48 && kelas2[i] == 11 && kelas2[i] == 69 && kelas2[i] == 61)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 9 && kelas2[i] == 41 && kelas2[i] == 43 && kelas2[i] == 51)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 10 && kelas2[i] == 64 && kelas2[i] == 56 && kelas2[i] == 9 && kelas2[i] == 45 && kelas2[i] == 19)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 11 && kelas2[i] == 63 && kelas2[i] == 12 && kelas2[i] == 35 && kelas2[i] == 62 && kelas2[i] == 22 && kelas2[i] == 65 && kelas2[i] == 32 && kelas2[i] == 33 && kelas2[i] == 68)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 12 && kelas2[i] == 40 && kelas2[i] == 53 && kelas2[i] == 36 && kelas2[i] == 47 && kelas2[i] == 51 && kelas2[i] == 41 && kelas2[i] == 46)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 13 && kelas2[i] == 2 && kelas2[i] == 48 && kelas2[i] == 11 && kelas2[i] == 69 && kelas2[i] == 61)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 14 && kelas2[i] == 46 && kelas2[i] == 42 && kelas2[i] == 8)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 15 && kelas2[i] == 33 && kelas2[i] == 12 && kelas2[i] == 62)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 16 && kelas2[i] == 40 && kelas2[i] == 11 && kelas2[i] == 43 && kelas2[i] == 47 && kelas2[i] == 61 && kelas2[i] == 51 && kelas2[i] == 41 && kelas2[i] == 46)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 17 && kelas2[i] == 62 && kelas2[i] == 24 && kelas2[i] == 35 && kelas2[i] == 69 && kelas2[i] == 42)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 18 && kelas2[i] == 8 && kelas2[i] == 24 && kelas2[i] == 43 && kelas2[i] == 69 && kelas2[i] == 34)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 19 && kelas2[i] == 69)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 20 && kelas2[i] == 40 && kelas2[i] == 30 && kelas2[i] == 14 && kelas2[i] == 47 && kelas2[i] == 39 && kelas2[i] == 46)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 21 && kelas2[i] == 8 && kelas2[i] == 24 && kelas2[i] == 34)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 22 && kelas2[i] == 0)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 23 && kelas2[i] == 33 && kelas2[i] == 29 && kelas2[i] == 57 && kelas2[i] == 11 && kelas2[i] == 12 && kelas2[i] == 19)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 24 && kelas2[i] == 64 && kelas2[i] == 69 && kelas2[i] == 61 && kelas2[i] == 41 && kelas2[i] == 2)
                    penalkrom2_5 = penalkrom2_5 - 1;
                if (matkul2[i] == 25 && kelas2[i] == 7 && kelas2[i] == 55 && kelas2[i] == 13 && kelas2[i] == 57 && kelas2[i] == 19 && kelas2[i] == 32)
                    penalkrom2_5 = penalkrom2_5 - 1;

            }

            //RULE 6
            int[] jamsks_matkul2 = new int[25];
            double penalkrom2_6 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    // Adp_matkul = new SqlDataAdapter("select * from matkul2where id_matkul = " + matkul1[i], con);

                    con.Open();
                    string query = "select * from matkul2 where id_matkul = " + matkul2[i];
                    cmd = new SqlCommand(query, con);
                    mdr = cmd.ExecuteReader();
                    if (mdr.Read())
                    {
                        label15.Text = mdr["sks_total"].ToString();
                    }
                    else
                    {
                        label15.Text = "Solusi Tidak Ditemukan";
                    }
                    con.Close();
                    sks_matkul2[i] = Int32.Parse(label15.Text);

                    jamsks_matkul2[i] = jam2[i] + sks_matkul2[i] - 1;
                    label14.Text = jamsks_matkul2[i].ToString();
                    if (jamsks_matkul2[i] > 11)
                        penalkrom2_6 = penalkrom2_6 + 1;
                }

            }

            //RULE 7
            double penalkrom2_7 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (matkul2[i] == matkul2[j])
                        penalkrom2_7 = penalkrom2_7 + 1;
                }

            }


            //PENALTY & FITNESS

            double penalty_individu2 = penalkrom2_1 + penalkrom2_2 + penalkrom2_3 + penalkrom2_4 + penalkrom2_5 + penalkrom2_6 + penalkrom2_7;
            double fitness_individu2;
            
            fitness_individu2 = 1 / (1 + penalty_individu2);

            textBox2.Text = penalty_individu2.ToString();
            
            textBox7.Text = fitness_individu2.ToString();
        }



        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public void RuleGene3()
        {
            //RULE 1
            double penalkrom3_1 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari3[i] == hari3[j] && jam3[i] == jam3[j] && ruang3[i] == ruang3[j])
                        penalkrom3_1 = penalkrom3_1 + 1;
                }

            }

            //RULE 2
            double penalkrom3_2 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari3[i] == hari3[j] && jam3[i] == jam3[j] && matkul3[i] == matkul3[j])
                        penalkrom3_2 = penalkrom3_2 + 1;
                }

            }

            //RULE 3
            double penalkrom3_3 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari3[i] == hari3[j] && jam3[i] == jam3[j] && dosen3[i] == dosen3[j])
                        penalkrom3_3 = penalkrom3_3 + 1;
                }

            }

            //RULE 4
            double penalkrom3_4 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul3[i] <= 6 && kelas3[i] <= 3)
                    penalkrom3_4 = penalkrom3_4 - 1;
                if (matkul3[i] > 6 && matkul3[i] <= 11 && kelas3[i] > 3 && kelas3[i] <= 6)
                    penalkrom3_4 = penalkrom3_4 - 1;
                if (matkul3[i] > 11 && matkul3[i] <= 17 && kelas3[i] > 6 && kelas3[i] <= 9)
                    penalkrom3_4 = penalkrom3_4 - 1;
                if (matkul3[i] > 17 && matkul3[i] <= 19 && kelas3[i] > 9 && kelas3[i] <= 11)
                    penalkrom3_4 = penalkrom3_4 - 1;
                if (matkul3[i] >= 20 && kelas3[i] >= 12)
                    penalkrom3_4 = penalkrom3_4 - 1;
            }

            //RULE 5
            double penalkrom3_5 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul3[i] == 1 && kelas3[i] == 0)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 2 && kelas3[i] == 15 && kelas3[i] == 13 && kelas3[i] == 42 && kelas3[i] == 7)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 3 && kelas3[i] == 40 && kelas3[i] == 14 && kelas3[i] == 47 && kelas3[i] == 34 && kelas3[i] == 15)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 4 && kelas3[i] == 57)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 5 && kelas3[i] == 63 && kelas3[i] == 42 && kelas3[i] == 7 && kelas3[i] == 2 && kelas3[i] == 15)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 6 && kelas3[i] == 40 && kelas3[i] == 14 && kelas3[i] == 47 && kelas3[i] == 34 && kelas3[i] == 15)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 7 && kelas3[i] == 46)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 8 && kelas3[i] == 2 && kelas3[i] == 48 && kelas3[i] == 11 && kelas3[i] == 69 && kelas3[i] == 61)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 9 && kelas3[i] == 41 && kelas3[i] == 43 && kelas3[i] == 51)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 10 && kelas3[i] == 64 && kelas3[i] == 56 && kelas3[i] == 9 && kelas3[i] == 45 && kelas3[i] == 19)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 11 && kelas3[i] == 63 && kelas3[i] == 12 && kelas3[i] == 35 && kelas3[i] == 62 && kelas3[i] == 22 && kelas3[i] == 65 && kelas3[i] == 32 && kelas3[i] == 33 && kelas3[i] == 68)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 12 && kelas3[i] == 40 && kelas3[i] == 53 && kelas3[i] == 36 && kelas3[i] == 47 && kelas3[i] == 51 && kelas3[i] == 41 && kelas3[i] == 46)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 13 && kelas3[i] == 2 && kelas3[i] == 48 && kelas3[i] == 11 && kelas3[i] == 69 && kelas3[i] == 61)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 14 && kelas3[i] == 46 && kelas3[i] == 42 && kelas3[i] == 8)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 15 && kelas3[i] == 33 && kelas3[i] == 12 && kelas3[i] == 62)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 16 && kelas3[i] == 40 && kelas3[i] == 11 && kelas3[i] == 43 && kelas3[i] == 47 && kelas3[i] == 61 && kelas3[i] == 51 && kelas3[i] == 41 && kelas3[i] == 46)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 17 && kelas3[i] == 62 && kelas3[i] == 24 && kelas3[i] == 35 && kelas3[i] == 69 && kelas3[i] == 42)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 18 && kelas3[i] == 8 && kelas3[i] == 24 && kelas3[i] == 43 && kelas3[i] == 69 && kelas3[i] == 34)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 19 && kelas3[i] == 69)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 20 && kelas3[i] == 40 && kelas3[i] == 30 && kelas3[i] == 14 && kelas3[i] == 47 && kelas3[i] == 39 && kelas3[i] == 46)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 21 && kelas3[i] == 8 && kelas3[i] == 24 && kelas3[i] == 34)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 22 && kelas3[i] == 0)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 23 && kelas3[i] == 33 && kelas3[i] == 29 && kelas3[i] == 57 && kelas3[i] == 11 && kelas3[i] == 12 && kelas3[i] == 19)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 24 && kelas3[i] == 64 && kelas3[i] == 69 && kelas3[i] == 61 && kelas3[i] == 41 && kelas3[i] == 2)
                    penalkrom3_5 = penalkrom3_5 - 1;
                if (matkul3[i] == 25 && kelas3[i] == 7 && kelas3[i] == 55 && kelas3[i] == 13 && kelas3[i] == 57 && kelas3[i] == 19 && kelas3[i] == 32)
                    penalkrom3_5 = penalkrom3_5 - 1;

            }

            //RULE 6
            int[] jamsks_matkul3 = new int[25];
            double penalkrom3_6 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    // Adp_matkul = new SqlDataAdapter("select * from matkul2where id_matkul = " + matkul1[i], con);

                    con.Open();
                    string query = "select * from matkul2 where id_matkul = " + matkul3[i];
                    cmd = new SqlCommand(query, con);
                    mdr = cmd.ExecuteReader();
                    if (mdr.Read())
                    {
                        label17.Text = mdr["sks_total"].ToString();
                    }
                    else
                    {
                        label17.Text = "Solusi Tidak Ditemukan";
                    }
                    con.Close();
                    sks_matkul3[i] = Int32.Parse(label17.Text);

                    jamsks_matkul3[i] = jam3[i] + sks_matkul3[i] - 1;
                    label16.Text = jamsks_matkul3[i].ToString();
                    if (jamsks_matkul3[i] > 11)
                        penalkrom3_6 = penalkrom3_6 + 1;
                }

            }

            //RULE 7
            double penalkrom3_7 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (matkul3[i] == matkul3[j])
                        penalkrom3_7 = penalkrom3_7 + 1;
                }

            }


            //PENALTY & FITNESS

            double penalty_individu3 = penalkrom3_1 + penalkrom3_2 + penalkrom3_3 + penalkrom3_4 + penalkrom3_5 + penalkrom3_6 + penalkrom3_7;
            double fitness_individu3;

            fitness_individu3 = 1 / (1 + penalty_individu3);

            textBox3.Text = penalty_individu3.ToString();

            textBox6.Text = fitness_individu3.ToString();
        }


        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>

        public void RuleGene4()
        {
            //RULE 1
            double penalkrom4_1 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari4[i] == hari4[j] && jam4[i] == jam4[j] && ruang4[i] == ruang4[j])
                        penalkrom4_1 = penalkrom4_1 + 1;
                }

            }

            //RULE 2
            double penalkrom4_2 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari4[i] == hari4[j] && jam4[i] == jam4[j] && matkul4[i] == matkul4[j])
                        penalkrom4_2 = penalkrom4_2 + 1;
                }

            }

            //RULE 3
            double penalkrom4_3 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (hari4[i] == hari4[j] && jam4[i] == jam4[j] && dosen4[i] == dosen4[j])
                        penalkrom4_3 = penalkrom4_3 + 1;
                }

            }

            //RULE 4
            double penalkrom4_4 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul4[i] <= 6 && kelas4[i] <= 3)
                    penalkrom4_4 = penalkrom4_4 - 1;
                if (matkul4[i] > 6 && matkul4[i] <= 11 && kelas4[i] > 3 && kelas4[i] <= 6)
                    penalkrom4_4 = penalkrom4_4 - 1;
                if (matkul4[i] > 11 && matkul4[i] <= 17 && kelas4[i] > 6 && kelas4[i] <= 9)
                    penalkrom4_4 = penalkrom4_4 - 1;
                if (matkul4[i] > 17 && matkul4[i] <= 19 && kelas4[i] > 9 && kelas4[i] <= 11)
                    penalkrom4_4 = penalkrom4_4 - 1;
                if (matkul4[i] >= 20 && kelas4[i] >= 12)
                    penalkrom4_4 = penalkrom4_4 - 1;
            }

            //RULE 5
            double penalkrom4_5 = 25;
            for (int i = 0; i < 25; i++)
            {
                if (matkul4[i] == 1 && kelas4[i] == 0)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 2 && kelas4[i] == 15 && kelas4[i] == 13 && kelas4[i] == 42 && kelas4[i] == 7)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 3 && kelas4[i] == 40 && kelas4[i] == 14 && kelas4[i] == 47 && kelas4[i] == 34 && kelas4[i] == 15)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 4 && kelas4[i] == 57)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 5 && kelas4[i] == 63 && kelas4[i] == 42 && kelas4[i] == 7 && kelas4[i] == 2 && kelas4[i] == 15)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 6 && kelas4[i] == 40 && kelas4[i] == 14 && kelas4[i] == 47 && kelas4[i] == 34 && kelas4[i] == 15)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 7 && kelas4[i] == 46)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 8 && kelas4[i] == 2 && kelas4[i] == 48 && kelas4[i] == 11 && kelas4[i] == 69 && kelas4[i] == 61)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 9 && kelas4[i] == 41 && kelas4[i] == 43 && kelas4[i] == 51)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 10 && kelas4[i] == 64 && kelas4[i] == 56 && kelas4[i] == 9 && kelas4[i] == 45 && kelas4[i] == 19)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 11 && kelas4[i] == 63 && kelas4[i] == 12 && kelas4[i] == 35 && kelas4[i] == 62 && kelas4[i] == 22 && kelas4[i] == 65 && kelas4[i] == 32 && kelas4[i] == 33 && kelas4[i] == 68)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 12 && kelas4[i] == 40 && kelas4[i] == 53 && kelas4[i] == 36 && kelas4[i] == 47 && kelas4[i] == 51 && kelas4[i] == 41 && kelas4[i] == 46)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 13 && kelas4[i] == 2 && kelas4[i] == 48 && kelas4[i] == 11 && kelas4[i] == 69 && kelas4[i] == 61)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 14 && kelas4[i] == 46 && kelas4[i] == 42 && kelas4[i] == 8)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 15 && kelas4[i] == 33 && kelas4[i] == 12 && kelas4[i] == 62)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 16 && kelas4[i] == 40 && kelas4[i] == 11 && kelas4[i] == 43 && kelas4[i] == 47 && kelas4[i] == 61 && kelas4[i] == 51 && kelas4[i] == 41 && kelas4[i] == 46)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 17 && kelas4[i] == 62 && kelas4[i] == 24 && kelas4[i] == 35 && kelas4[i] == 69 && kelas4[i] == 42)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 18 && kelas4[i] == 8 && kelas4[i] == 24 && kelas4[i] == 43 && kelas4[i] == 69 && kelas4[i] == 34)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 19 && kelas4[i] == 69)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 20 && kelas4[i] == 40 && kelas4[i] == 30 && kelas4[i] == 14 && kelas4[i] == 47 && kelas4[i] == 39 && kelas4[i] == 46)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 21 && kelas4[i] == 8 && kelas4[i] == 24 && kelas4[i] == 34)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 22 && kelas4[i] == 0)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 23 && kelas4[i] == 33 && kelas4[i] == 29 && kelas4[i] == 57 && kelas4[i] == 11 && kelas4[i] == 12 && kelas4[i] == 19)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 24 && kelas4[i] == 64 && kelas4[i] == 69 && kelas4[i] == 61 && kelas4[i] == 41 && kelas4[i] == 2)
                    penalkrom4_5 = penalkrom4_5 - 1;
                if (matkul4[i] == 25 && kelas4[i] == 7 && kelas4[i] == 55 && kelas4[i] == 13 && kelas4[i] == 57 && kelas4[i] == 19 && kelas4[i] == 32)
                    penalkrom4_5 = penalkrom4_5 - 1;

            }

            //RULE 6
            int[] jamsks_matkul4 = new int[25];
            double penalkrom4_6 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    // Adp_matkul = new SqlDataAdapter("select * from matkul2where id_matkul = " + matkul1[i], con);

                    con.Open();
                    string query = "select * from matkul2 where id_matkul = " + matkul4[i];
                    cmd = new SqlCommand(query, con);
                    mdr = cmd.ExecuteReader();
                    if (mdr.Read())
                    {
                        label19.Text = mdr["sks_total"].ToString();
                    }
                    else
                    {
                        label19.Text = "Solusi Tidak Ditemukan";
                    }
                    con.Close();
                    sks_matkul4[i] = Int32.Parse(label19.Text);

                    jamsks_matkul4[i] = jam4[i] + sks_matkul4[i] - 1;
                    label18.Text = jamsks_matkul4[i].ToString();
                    if (jamsks_matkul4[i] > 11)
                        penalkrom4_6 = penalkrom4_6 + 1;
                }

            }

            //RULE 7
            double penalkrom4_7 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    if (matkul4[i] == matkul4[j])
                        penalkrom4_7 = penalkrom4_7 + 1;
                }

            }


            //PENALTY & FITNESS
            label5.Text = penalkrom4_1.ToString();
            label6.Text = penalkrom4_2.ToString();
            label7.Text = penalkrom4_3.ToString();
            label8.Text = penalkrom4_4.ToString();
            label9.Text = penalkrom4_5.ToString();
            label10.Text = penalkrom4_6.ToString();
            label11.Text = penalkrom4_7.ToString();

            double penalty_individu4 = penalkrom4_1 + penalkrom4_2 + penalkrom4_3 + penalkrom4_4 + penalkrom4_5 + penalkrom4_6 + penalkrom4_7;
            double fitness_individu4;

            fitness_individu4 = 1 / (1 + penalty_individu4);

            textBox4.Text = penalty_individu4.ToString();

            textBox5.Text = fitness_individu4.ToString();
        }
    }
}