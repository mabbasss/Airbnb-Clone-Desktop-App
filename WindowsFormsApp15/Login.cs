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
    public partial class Login : MetroSetForm
    {
        public Login()
        {
            InitializeComponent();
        }
        HotelEntities db = new HotelEntities();
        public static int SetValueForText1 =0 ;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                var login = db.Users.Where(s => s.Email == textBox1.Text && s.Password == textBox2.Text).FirstOrDefault();
                if (login != null)
                {
                    if (login.Roles_id==1)
                    {
                        ViewAdmin admin = new ViewAdmin();
                        this.Visible = false;
                        admin.ShowDialog();
                        Empty();
                        this.Close();

                    }
                    if (login.Roles_id==2)
                    {

                        SetValueForText1 = int.Parse(login.id.ToString());
                        ViewCustomer custmer = new ViewCustomer();
                        this.Visible = false;
                        custmer.ShowDialog();
                        Empty();
                        this.Close();

                    }
                    if (login.Roles_id==3)
                    {
                        SetValueForText1 = int.Parse(login.id.ToString());

                        ViewOwner Owener = new ViewOwner();
                        this.Visible = false;
                        Owener.ShowDialog();
                        Empty();
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Failed To login ");
                    Empty();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Failed To login from catch ");

            }

        }

        private void Empty()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
    }
}
