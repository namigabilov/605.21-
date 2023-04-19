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


namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Goster(string S)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(S,con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        public SqlConnection con = new SqlConnection("Data source=NAMIQ\\SQLEXPRESS01;Initial catalog=qr605;Integrated security=SSPI");
        SqlCommand com;


        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qr605DataSet.t2' table. You can move, or remove it, as needed.
            this.t2TableAdapter.Fill(this.qr605DataSet.t2);
            Goster("Select* from t1");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Insert into t1(telebe,qr,bal)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')");
            con.Open();
            com = new SqlCommand("Insert into t1(telebe,qr,bal)values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')",con);
            com.ExecuteNonQuery();
            con.Close();
            Goster("Select* from t1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Search")
            {
                Goster("Select* from t1 where telebe like '" + textBox1.Text + "'");
                button2.Text = "All View";
            }
            else {
                Goster("Select* from t1 ");
                button2.Text = "Search";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("update t1 set bal='"+textBox3.Text+"' where telebe like '"+textBox1.Text+"'", con);
            com.ExecuteNonQuery();
            con.Close();
            Goster("Select* from t1");
        }
    }
}
