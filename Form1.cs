
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace testdrive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(GetButton1());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=sampleconnecrtion; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);

            try
            {
                mySqlConnection.Open();
                //MessageBox.Show("Connection success");

                string qry = "select * from user";

                MySqlCommand mySqlCommand = new MySqlCommand(qry);
                mySqlCommand.Connection = mySqlConnection;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                da.Fill(dt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();

            }
        }

        private ComboBox GetComboBox1()
        {
            return comboBox1;
        }

        private void button1_Click(object sender, EventArgs e, ComboBox comboBox1)
        {
            string mysqlCon = "server=127.0.0.1; user=root; database=sampleconnecrtion; password=";
            MySqlConnection mySqlConnection = new MySqlConnection(mysqlCon);

            try
            {
                mySqlConnection.Open();

                string qry = "select * from user where username= '" + textBox1.Text + "' and password='" + textBox2.Text + "';";

                MySqlCommand mySqlCommand = new MySqlCommand(qry);
                mySqlCommand.Connection = mySqlConnection;

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = mySqlCommand;
                DataTable dt = new DataTable();
                da.Fill(dt);
                var cmbItemValue = comboBox1.SelectedItem.ToString();

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["type"].ToString() == cmbItemValue)
                        {
                            MessageBox.Show("Logged in as" + dt.Rows[i][2]);
                            if (comboBox1.SelectedIndex == 0)
                            {
                                Form2 f = new Form2();
                                f.Show();
                                this.Hide();
                            }
                            else
                            {
                                Form3 ff = new Form3();
                                ff.Show();
                                this.Hide();
                            }
                        }
                    }
                }



                else
                {
                    MessageBox.Show("Error");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                mySqlConnection.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

