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
    public partial class Rooms : MetroSetForm
    {
        public Rooms()
        {
            InitializeComponent();
            comboBox1.Items.Add("yes");
            comboBox1.Items.Add("no");
        }
        HotelEntities db = new HotelEntities();
        private void Rooms_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testing_DataSet6.Houses' table. You can move, or remove it, as needed.
            this.housesTableAdapter.Fill(this.testing_DataSet6.Houses);
            // TODO: This line of code loads data into the 'testing_DataSet2.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.testing_DataSet2.Users);
            // TODO: This line of code loads data into the 'testing_DataSet1.Roles' table. You can move, or remove it, as needed.
            this.rolesTableAdapter.Fill(this.testing_DataSet1.Roles);

            dataGridView1.DataSource = db.Houses.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int price = int.Parse(textPrice.Text);
                int suerid = int.Parse(comboBox2.SelectedValue.ToString());


                db.Houses.Add(new House {  Location = Loactions.Text, Price = price, Is_avalibale = comboBox1.SelectedItem.ToString(), User_id = suerid });
                db.SaveChanges();
                Empty();
                MessageBox.Show("Room Added");
                Reset();

            }
            catch (Exception)
            {

                MessageBox.Show("Room not  Added");

            }


        }



        private void button4_Click(object sender, EventArgs e)
        {
            Reset();

        }

        private void Reset()
        {
            dataGridView1.DataSource = db.Houses.ToList();

        }

        private void Empty()
        {
            
            textPrice.Text = "";
            Loactions.Text = "";
            comboBox1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int prices = int.Parse(textPrice.Text);
                int suerid = int.Parse(comboBox2.SelectedValue.ToString());

                int ids = int.Parse(comboBox3.SelectedValue.ToString());

                House h = db.Houses.Find(ids);
                h.Location = Loactions.Text;
                h.Is_avalibale = comboBox1.Text;
                h.Price = prices;
                h.User_id = suerid;

                db.SaveChanges();

                MessageBox.Show("updated");
                Empty();
                Reset();

            }
            catch (Exception)
            {

                MessageBox.Show("Error");

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int ids = int.Parse(comboBox3.SelectedValue.ToString());

                var romved = db.Houses.Where(s => s.id == ids).FirstOrDefault();
                db.Houses.Remove(romved);
                db.SaveChanges();
                MessageBox.Show("Deleted");
                Empty();
                Reset();

            }
            catch (Exception)
            {
                MessageBox.Show("Not Deleted");
            }


        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            int suerisd = int.Parse(comboBox2.SelectedValue.ToString());

            int suerid = int.Parse(comboBox3.SelectedValue.ToString());

            House h = db.Houses.Find(suerid);
             Loactions.Text= h.Location;
             comboBox1.Text = h.Is_avalibale;
            textPrice.Text = h.Price.ToString();
            h.User_id = suerisd;

            
        }

        private void comboBox3_Click(object sender, EventArgs e)
        {
           
        }
    }
}
