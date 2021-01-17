using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fasad_Standart
{
    public partial class SelClients : Form
    {
        public static string connectionstring = Properties.Settings.Default.fasad_standartConnectionString;
        public SelClients()
        {
            InitializeComponent();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Clientere clientere = new Clientere();
            clientere.Show();
            this.Hide();
        }

        private void SelClients_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            string sqlstr = "SELECT" + "[Клиенты].[ФИО],[Заказы].[Id заказа],[Заказы].[Дата],[Заказы].[Время], [Заказы].[Статус заказа]" +
                 " FROM [Клиенты],[Заказы]" +
                 " WHERE [Клиенты].[Id клиента] = [Заказы].[Id клиента];";
            OleDbDataAdapter Adapter = new OleDbDataAdapter(sqlstr, connection);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }
    }
}
