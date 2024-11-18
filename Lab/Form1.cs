using Microsoft.Data.SqlClient;
using System.Data;

namespace Lab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Connect();
            ShowData("select * from Products");

        }

        private void ShowData(string sql)
        {
            //string sql = "select * from Products";

            da = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        SqlConnection conn; // Fixed typo from `sqlConnection` to `SqlConnection`.
        SqlCommand cmd;     // Fixed typo from `sqlcommcand` to `SqlCommand`.
        SqlDataAdapter da;  // Fixed typo from `sqlDataAdapter` to `SqlDataAdapter`.

        private void Connect()
        {
            string server = @".\sqlexpress";
            string db = "Minimart";
            string strCon = string.Format(@"Data Source={0};Initial Catalog={1};Integrated Security=True ;Encrypt = false", server, db); // Fixed syntax errors.
            conn = new SqlConnection(strCon);
            conn.Open();
        }
        private void Disconnect()
        {
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowData("select EmployeeID,Title+FirstName + ' ' + LastName EmName,Position from Employees");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowData("select * from Categories");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ShowData("select * from Products");
        }


    }
}
