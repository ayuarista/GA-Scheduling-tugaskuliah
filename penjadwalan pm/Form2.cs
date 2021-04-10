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
    public partial class Form2 : Form
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

        public Form2()
        {
            InitializeComponent();

            //LV PROPERTIES
            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            //CONSTRUCT COLUMNS
            listView1.Columns.Add("No.", 100);
            listView1.Columns.Add("Individu 1", 100);
            listView1.Columns.Add("Individu 2", 100);
            listView1.Columns.Add("Individu 3", 100);
            listView1.Columns.Add("Individu 4", 100);
            listView1.Columns.Add("Penalty", 100);
            listView1.Columns.Add("Fitness", 100);

        }

        private void add(String no, String individu_1, String individu_2, String individu_3, String individu_4, String penalty, String fitness)
        {

            //ROW
            String[] row = { no, individu_1,individu_2,individu_3,individu_4, penalty, fitness };
            ListViewItem item = new ListViewItem(row);
            listView1.Items.Add(item);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Adp_dosen = new SqlDataAdapter("select * from dosen", con);
            Adp_hari = new SqlDataAdapter("select * from hari", con);
            Adp_jam = new SqlDataAdapter("select * from jam", con);
            Adp_kelas = new SqlDataAdapter("select * from kelas", con);
            
            Adp_ruang = new SqlDataAdapter("select * from ruang", con);
            Adp_dosen.Fill(table1);
            Adp_hari.Fill(table2);
            Adp_jam.Fill(table3);
            Adp_kelas.Fill(table4);
            
            Adp_ruang.Fill(table6);
            //showData(pos);
            
            //GENERATE GENE
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

            int[] sks_matkul = new int[25];

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

                add( (i+1).ToString(),
                    hari1[i].ToString() + " " + jam1[i].ToString() + " " + ruang1[i].ToString() + " " + matkul1[i].ToString() + " " + kelas1[i].ToString() + " " + dosen1[i].ToString(), 
                    hari2[i].ToString() + " " + jam2[i].ToString() + " " + ruang2[i].ToString() + " " + matkul2[i].ToString() + " " + kelas2[i].ToString() + " " + dosen2[i].ToString(), 
                    hari3[i].ToString() + " " + jam3[i].ToString() + " " + ruang3[i].ToString() + " " + matkul3[i].ToString() + " " + kelas3[i].ToString() + " " + dosen3[i].ToString(), 
                    hari4[i].ToString() + " " + jam4[i].ToString() + " " + ruang4[i].ToString() + " " + matkul4[i].ToString() + " " + kelas4[i].ToString() + " " + dosen4[i].ToString(),
                    sks_matkul[i].ToString(),
                    0.ToString());
            }

            //RULE 1
            double penal_1 = 0;
            for (int i = 0; i < 25; i++)
            {
                for(int j = i+1; j<25;j++)
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
            for(int i = 0; i < 25; i++)
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
            for(int i = 0; i < 25; i++)
            {
                if (matkul1[i] == 1 && kelas1[i] == 0)
                    penal_5 = penal_5 - 1;
                if (matkul1[i] == 2 && kelas1[i] == 15 && kelas1[i]==13 && kelas1[i] == 42 && kelas1[i]==7)
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

          /*  //RULE 6
            int[] jamsks_matkul = new int[25];
            double penal_6 = 0;
            for (int i = 0; i < 25; i++)
            {
                for (int j = i + 1; j < 25; j++)
                {
                    Adp_matkul = new SqlDataAdapter("select * from matkul2 where id_matkul" + matkul1[i], con);
                    jamsks_matkul[i] = jam1[i] + sks_matkul[i] - 1;
                    if ( jamsks_matkul[i] == 0)
                    penal_6 = penal_6 + 1;
                }

            } */

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

            label3.Text = penal_1.ToString();
            label4.Text = penal_2.ToString();
            label5.Text = penal_3.ToString();
            label6.Text = penal_4.ToString();
            label7.Text = penal_5.ToString();
            label9.Text = penal_7.ToString();

            double penalty_individu1 = penal_1 + penal_2 + penal_3 + penal_4 + penal_5 + penal_7;
            double penalty_individu2 = 2;
            double penalty_individu3 = 3;
            double penalty_individu4 = 4;
            double fitness_individu1, fitness_individu2, fitness_individu3, fitness_individu4;

            fitness_individu1 = 1 / (1 + penalty_individu1);
            fitness_individu2 = 1 / (1 + penalty_individu2);
            fitness_individu3 = 1 / (1 + penalty_individu3);
            fitness_individu4 = 1 / (1 + penalty_individu4);

            textBox1.Text = penalty_individu1.ToString();

            textBox8.Text = fitness_individu1.ToString();
            textBox7.Text = fitness_individu2.ToString();
            textBox6.Text = fitness_individu3.ToString();
            textBox5.Text = fitness_individu4.ToString();

            // Adp_matkul.Fill(table5);
            //showData(pos); 
            disp_data();
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from matkul2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }

       /* public void showData(int index)
        {
            int[] sks_matkul = new int[25];
            for (int i = 1; i < 26; i++)
            {
                if (table5.Rows.Count > 0)
                {
                    sks_matkul[i] = (int)table5.Rows[index][4];
                }
            } 

        } */
    
}
