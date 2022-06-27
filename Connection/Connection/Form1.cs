using System.Data;
using System.Data.SqlClient;

namespace Connection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            var connectoinString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=test;Integrated Security=true;";
            using (SqlConnection cn = new SqlConnection(connectoinString))
            {
                cn.Open();

                var queryString = @"SELECT * FROM Product";
                var command = new SqlCommand(queryString, cn);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var productId = reader["ID"];
                    var productName = reader["ProductName"];

                    listBox1.Items.Add($"ID : {productId} Product Name : {productName}");
                }
                
                reader.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}