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
using System.Configuration;
using Image_Gallery.Models;
namespace Image_Gallery
{
    public partial class AddTag : MetroFramework.Forms.MetroForm
    {
        string connectionString;
        SqlConnection connection;
        public int S_Tags { set; get; }
        private List<Tags> L_tags;
        private bool checkTags = false;
        public Settings settings { set; get; }
        public AddTag()
        {
            InitializeComponent();
            L_tags = new List<Tags>();
            connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            connection = new SqlConnection(connectionString);
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(A_T_ComboBox.Items.Count>0)
            S_Tags = (A_T_ComboBox.SelectedItem as Tags).Id;
            this.DialogResult = DialogResult.OK;
             
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
        private void LoadTags()
        {
            string query = "select * from Tags";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            L_tags.Clear();
            while (reader.Read())
            {
                Tags c = new Tags()
                {
                    Id = (int)reader["Id"],
                    Name = (string)reader["Name"]
                };
                L_tags.Add(c);
            }
            connection.Close();
            A_T_ComboBox.Items.Clear();
            foreach (var i in L_tags)
            {
                A_T_ComboBox.Items.Add(i);
            }
            A_T_ComboBox.DisplayMember = "Name";
            if (A_T_ComboBox.Items.Count > 0)
                A_T_ComboBox.SelectedIndex = 0;

        }
        private void A_T_AddTag_Click(object sender, EventArgs e)
        {
            if (checkTags == false)
            {
                A_T_TextBox.Visible = true;
                checkTags = true; 
                A_T_SelectTag.Visible = false;
                A_T_ComboBox.Visible = false;
                A_T_Cancel.Visible = false;
                A_T_AddTag.Text = "Сохранить";
                A_T_DelTag.Text = "Отмена";
            }
            else if (A_T_TextBox.Text != "")
            {
                checkTags = false;
                A_T_TextBox.Visible = false;
                A_T_DelTag.Text = "Удалить Тег";
                A_T_SelectTag.Visible = true;
                A_T_ComboBox.Visible = true;
                A_T_Cancel.Visible = true;
                A_T_AddTag.Text = "Добавить Тег";
                string query = "insert into Tags (Name) values(@name)";
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                string name = A_T_TextBox.Text;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 50).Value = name;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Тег успешно добавлен");
                connection.Close();
                LoadTags();
            }
            else
                MessageBox.Show("Введите тег!!!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void A_T_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void A_T_DelTag_Click(object sender, EventArgs e)
        {
            if (checkTags == false)
            {
                string query = "delete from Tags where Name =(@Name)"; 
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                var Name = (A_T_ComboBox.SelectedItem as Tags).Name.ToString(); 
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar,50).Value = Name;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Тег успешно Удален!!!");
                connection.Close();
                LoadTags();
            }
            else
            {
                checkTags = false;
                A_T_TextBox.Visible = false;
                A_T_DelTag.Text = "Удалить Тег";
                A_T_SelectTag.Visible = true;
                A_T_ComboBox.Visible = true;
                A_T_Cancel.Visible = true;
                A_T_AddTag.Text = "Добавить Тег";
            }
        }

        private void AddTag_Load(object sender, EventArgs e)
        {
            LoadTags();
            switch (settings.WindowColor)
            {
                case 1:
                    this.Style = settings.SelectWindowColor(1);
                    this.Refresh();
                    break;
                case 2:
                    this.Style = settings.SelectWindowColor(2);
                    this.Refresh();
                    break;
                case 3:
                    this.Style = settings.SelectWindowColor(3);
                    this.Refresh();
                    break;
                case 4:
                    this.Style = settings.SelectWindowColor(4);
                    this.Refresh();
                    break;
                case 5:
                    this.Style = settings.SelectWindowColor(5);
                    this.Refresh();
                    break;
                case 6:
                    this.Style = settings.SelectWindowColor(6);
                    this.Refresh();
                    break;
            }
        }
    }
}
