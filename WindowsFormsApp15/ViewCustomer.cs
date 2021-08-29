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
    public partial class ViewCustomer : MetroSetForm
    {
        public ViewCustomer()
        {
            InitializeComponent();
        }
        DateTime today;
        
        HotelEntities db = new HotelEntities();
        private void ViewCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testing_DataSet4.Houses' table. You can move, or remove it, as needed.
            this.housesTableAdapter.Fill(this.testing_DataSet4.Houses);
            dataGridView1.DataSource = db.Houses.Where(s => s.Is_avalibale == "yes").ToList();

            var combolocation = from i in db.Houses
                                where i.Is_avalibale == "yes"
                                select i.Location;
            foreach (var item in combolocation)
            {
                comboBox1.Items.Add(item);

            }

            today = dateTimePicker1.Value;

            var Check = from i in db.Houses
                        where i.Is_avalibale == "yes"
                        select i.id;
            foreach (var item in Check)
            {
                comboBox2.Items.Add(item);

            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                int res = DateTime.Compare(dateTimePicker1.Value,today);
                int ress = DateTime.Compare(dateTimePicker2.Value,dateTimePicker1.Value);

                if (res >= 0 && ress > 0)
                {
                    Booking booking = new Booking();
                    booking.House_id = int.Parse(comboBox2.SelectedItem.ToString());
                    booking.User_id = Login.SetValueForText1;
                    booking.Start_Booking = dateTimePicker1.Value;
                    booking.End_Booking = dateTimePicker2.Value;

                  

                    var check = (from i in db.Bookings
                                 where i.House_id == booking.House_id  &&
                                ( i.Start_Booking >= booking.Start_Booking && i.End_Booking <= booking.End_Booking)
                                 select i).FirstOrDefault();

                    if (check == null)
                    {
                        db.Bookings.Add(booking);
                        db.SaveChanges();
                        MessageBox.Show("your Bookind added");
                        
                        db.SaveChanges();

                    }
                    else
                    {
                        MessageBox.Show("its not avalibale");
                    }



                }
                else
                {
                    MessageBox.Show("Check Your Booking date");

                }


            }
            catch (Exception)
            {

                MessageBox.Show("your Bookind not added");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.Houses.Where(s => s.Is_avalibale == "yes").ToList();
        }

       

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
   
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            
            
            dataGridView1.DataSource = db.Houses.Where(s => s.Location == comboBox1.SelectedItem.ToString()).ToList();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ahmed = db.Houses.Where(s => s.Is_avalibale == "yes").ToList();
            foreach (var item in ahmed)
            {
                comboBox1.Items.Add(item);

            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            int res = DateTime.Compare(dateTimePicker1.Value, today);

            if (res < 0)
            {
                MessageBox.Show("Wrong date");
            }
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
            int res = DateTime.Compare(dateTimePicker2.Value, today);

            if (res < 0)
            {
                MessageBox.Show("Wrong date");
            }
        }
    }
}
