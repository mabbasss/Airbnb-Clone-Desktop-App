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
    public partial class ViewOwner : MetroSetForm
    {
        public ViewOwner()
        {
            InitializeComponent();
        }
        HotelEntities db = new HotelEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var add = new House();
                
                add.Is_avalibale = comboBox1.SelectedItem.ToString();
                add.Location = textBox1.Text;
                add.Price = int.Parse(textBox2.Text);
                add.User_id = Login.SetValueForText1;
                db.Houses.Add(add);
                db.SaveChanges();
                MessageBox.Show("Added");
                Update();

            }
            catch (Exception)
            {

                MessageBox.Show("Not Added");

            }


        }

        private void ViewOwner_Load(object sender, EventArgs e)
        {
            var aa = Login.SetValueForText1;
            dataGridView1.DataSource = db.Houses.Where(s => s.User_id == aa ).ToList();
            comboBox1.Items.Add("yes");
            comboBox1.Items.Add("no");

            var check = db.Houses.Where(s => s.User_id == Login.SetValueForText1).Select(s=>s.id).ToList();
            foreach (var item in check)
            {
                comboBox2.Items.Add(item);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var i = int.Parse(comboBox2.SelectedItem.ToString());
                House house = db.Houses.FirstOrDefault(s=>s.id == i);
                house.Is_avalibale = comboBox1.SelectedItem.ToString();
                house.Price = int.Parse(textBox2.Text);
                house.Location = textBox1.Text;
                house.User_id = Login.SetValueForText1;

                db.SaveChanges();
                MessageBox.Show("updated");
                Update();
            }
            catch (Exception)
            {

                MessageBox.Show("Not Updated");

            }


        }
        public new void Update()
        {
            comboBox2.Items.Clear();
            var aa = Login.SetValueForText1;
            dataGridView1.DataSource = db.Houses.Where(s => s.User_id == aa).ToList();

            var check = db.Houses.Where(s => s.User_id == Login.SetValueForText1).Select(s => s.id).ToList();
            foreach (var item in check)
            {
                comboBox2.Items.Add(item);
            }
        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var i = int.Parse(comboBox2.SelectedItem.ToString());
                House house = db.Houses.FirstOrDefault(s => s.id == i);
                db.Houses.Remove(house);
                db.SaveChanges();
                MessageBox.Show("Deleted ");
                Update();

            }
            catch (Exception)
            {
                MessageBox.Show("Not Deleted ");
            }


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = int.Parse(comboBox2.SelectedItem.ToString());
            House house = db.Houses.FirstOrDefault(s => s.id == i);
            comboBox1.SelectedItem = house.Is_avalibale.ToString();
            textBox2.Text= house.Price.ToString();
            textBox1.Text= house.Location;
             
        }
    }
}
