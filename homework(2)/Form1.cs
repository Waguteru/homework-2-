using Npgsql;
using System.Data;

namespace homework_2_
{
    public partial class Form1 : Form
    {
        string connectionString = ("Server=localhost;Port=5432;Database=CreatingTask;User Id=postgres;Password=123;");

        public Form1()
        {
            InitializeComponent();
            SqlConnectionReader();


        }

        public void SqlConnectionReader()
        {
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlConnection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = npgsqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from task_table";

            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
            }
            cmd.Dispose();
            npgsqlConnection.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }


        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlConnection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = npgsqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format("UPDATE task_table SET nameuser = '{0}', task = '{1}'  WHERE id = '{2}'", textBox3.Text, textBox5.Text, Convert.ToInt32(textBox1.Text));
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
            }
            SqlConnectionReader();
            cmd.Dispose();
            npgsqlConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection npgsqlConnection = new NpgsqlConnection(connectionString);
            npgsqlConnection.Open();

            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = npgsqlConnection;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = String.Format( "DELETE FROM task_table WHERE id = '{0}'",   Convert.ToInt32(textBox2.Text));
            NpgsqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable table = new DataTable();
                table.Load(reader);
                dataGridView1.DataSource = table;
            }
            SqlConnectionReader();
            cmd.Dispose();
            npgsqlConnection.Close();
        }
    }
}
