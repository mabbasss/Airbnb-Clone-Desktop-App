using MetroSet_UI.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp15
{
    public partial class AdminClient : MetroSetForm
    {
        public AdminClient()
        {
            InitializeComponent();
            
        }
        HotelEntities db = new HotelEntities();
        private void AdminClient_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testing_DataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.testing_DataSet.Users);
            // TODO: This line of code loads data into the 'testing_DataSet3.Roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.testing_DataSet3.Roles);

            dataGridView1.DataSource = db.Users.ToList();
            textBox5.Text = "Search with user name ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Reset();

        }

        private void Reset()
        {
            dataGridView1.DataSource = db.Users.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                User u = new User();
                u.Email = textBox1.Text;
                u.Password = textBox2.Text;
                u.UserName = textBox3.Text;
                u.Phone = int.Parse(textBox4.Text);
                u.Roles_id = int.Parse(comboBox1.SelectedValue.ToString());
                db.Users.Add(u);
                db.SaveChanges();


                MessageBox.Show("Add user ");
                Reset();

            }
            catch (Exception)
            {

                MessageBox.Show("fill all text");
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(textBox6.Text);
                User up = db.Users.Find(i);
                up.Email = textBox1.Text;
                up.Password = textBox2.Text;
                up.UserName = textBox3.Text;
                up.Phone = int.Parse(textBox4.Text);
                up.Roles_id = int.Parse(comboBox1.SelectedValue.ToString());

                db.SaveChanges();
                MessageBox.Show("updated");
                Reset();

            }
            catch (Exception)
            {
                MessageBox.Show(" not updated");
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int i = int.Parse(textBox6.Text);
                var romved = db.Users.Where(s => s.id == i).FirstOrDefault();
                db.Users.Remove(romved);
                db.SaveChanges();
                MessageBox.Show("Deleted");
                Reset();

            }
            catch (Exception)
            {

                MessageBox.Show("Not Deleted");

            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource= db.Users.Where(s => s.UserName == textBox5.Text).ToList();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
