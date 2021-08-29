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
    public partial class Reservations : MetroSetForm
    {
        public Reservations()
        {
            InitializeComponent();
        }
        HotelEntities db = new HotelEntities();
        DateTime today;

        private void Reservations_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testing_DataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill(this.testing_DataSet.Users);
            // TODO: This line of code loads data into the 'testing_DataSet5.Booking' table. You can move, or remove it, as needed.
            this.bookingTableAdapter.Fill(this.testing_DataSet5.Booking);
            dataGridView1.DataSource = db.Bookings.Where(s => s.House.Is_avalibale == "yes").ToList();
            today = dateTimePicker1.Value;

            var comb1 = db.Bookings.Select(s => s.Booking_id).ToList();
            foreach (var item in comb1)
            {
                comboBox1.Items.Add(item);
            }

            var comb2 = db.Houses.Select(s => s.id).ToList();
            foreach (var item in comb2)
            {
                comboBox3.Items.Add(item);
            }

            /*var comb3 = db.Users.Select(s => s.Email).ToList();
            foreach (var item in comb3)
            {
                comboBox2.Items.Add(item);
            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int res = DateTime.Compare(dateTimePicker1.Value, today);
                int ress = DateTime.Compare(dateTimePicker2.Value, today);

                if (res >= 0 && ress > 0)
                {
                    Booking booking = new Booking();
                    booking.House_id = int.Parse(comboBox3.SelectedItem.ToString());
                    booking.Start_Booking = dateTimePicker1.Value;
                    booking.End_Booking = dateTimePicker2.Value;
                    booking.User_id = int.Parse(comboBox2.SelectedValue.ToString());



                    var check = (from i in db.Bookings
                                 where i.House_id == booking.House_id &&
                                (i.Start_Booking >= booking.Start_Booking && i.End_Booking <= booking.End_Booking)
                                 select i).FirstOrDefault();
                    if (check == null)
                    {
                        db.Bookings.Add(booking);
                        db.SaveChanges();
                        MessageBox.Show("Booking Added");
                        Reset();

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

                MessageBox.Show("Booking Not Added");

            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            dataGridView1.DataSource = db.Bookings.Where(s => s.House.Is_avalibale == "yes").ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var i = int.Parse(comboBox1.SelectedItem.ToString());
                var booking = db.Bookings.FirstOrDefault(s => s.Booking_id == i);
                booking.House_id = int.Parse(comboBox3.SelectedItem.ToString());
                booking.Start_Booking = dateTimePicker1.Value;
                booking.End_Booking = dateTimePicker2.Value;
                booking.User_id = int.Parse(comboBox2.SelectedValue.ToString());

                db.SaveChanges();
                MessageBox.Show("Updated");
                Reset();
            }
            catch (Exception)
            {

                MessageBox.Show("Not Updated");

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = int.Parse(comboBox1.SelectedItem.ToString());
            var booking = db.Bookings.FirstOrDefault(s => s.Booking_id == i);
            comboBox3.SelectedItem = int.Parse(booking.House_id.ToString());
            dateTimePicker1.Value = booking.Start_Booking.Value;
            dateTimePicker2.Value = booking.End_Booking.Value;
            comboBox2.SelectedValue = int.Parse(booking.User_id.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var i = int.Parse(comboBox1.SelectedItem.ToString());
                var booking = db.Bookings.Where(s => s.Booking_id == i ).FirstOrDefault();
                db.Bookings.Remove(booking);
                db.SaveChanges();
                MessageBox.Show("Deleted");
                Reset();
            }
            catch (Exception)
            {

                MessageBox.Show("Not Deleted");

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
