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
    public partial class SelProducts : Form
    {
        public static string connectionstring = Properties.Settings.Default.fasad_standartConnectionString;
        public SelProducts()
        {
            InitializeComponent();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Clientere clientere = new Clientere();
            clientere.Show();
            this.Hide();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SelProducts_Load(object sender, EventArgs e)
        {
            OleDbConnection connection = new OleDbConnection(connectionstring);
            connection.Open();
            string sqlstr = "SELECT" + "[Заказы].[Id заказа],[Товары].[Наименование],[Товары].[Тип покрытия],[Товары].[Количество], [Количество] * [Цена за единицу] as [Сумма]" +
                 " FROM [Товары],[Заказы]" +
                 " WHERE [Услуги/Материалы].[Id материала] = [Материалы].[Id материала];";
            OleDbDataAdapter Adapter = new OleDbDataAdapter(sqlstr, connection);
            DataTable Table = new DataTable();
            Adapter.Fill(Table);
            dataGridView1.DataSource = Table;
        }
    }
}
