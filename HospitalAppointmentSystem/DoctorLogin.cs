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

namespace HospitalAppointmentSystem
{
    public partial class DoctorLogin : Form

    {
        
        public DoctorSystem doctor;
        public Open open1 = null;
        SqlConnection conn;
        SqlCommand kmt;
        SqlDataReader dr;
        
        public DoctorLogin()
        {
            InitializeComponent();
            
            doctor = new DoctorSystem();
            doctor.doctorlogin = this;

        }
        public DoctorLogin(Open open)
        {
            InitializeComponent();
            open1 = open;
            doctor = new DoctorSystem();
            doctor.doctorlogin = this;

        }
        public static string id;
        public static string controlid;
        public DoctorLogin(string id,string controlid)
        {
            ıdtextBox.Text = id;
            controlıdtxtbox.Text = controlid;

        }
        private void signupButton_Click(object sender, EventArgs e)
        {
            doctor.Show();
            this.Hide();

        }
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                DoctorSystem doctor = new DoctorSystem(this);
                id = ıdtextBox.Text;
                controlid = controlıdtxtbox.Text;
                if (ıdtextBox.Text == "" && passwordtextBox.Text != "")
                {
                    MessageBox.Show("Please enter your ID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (passwordtextBox.Text == "" && ıdtextBox.Text != "")
                {
                    MessageBox.Show("Please enter your Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (ıdtextBox.Text == "" && passwordtextBox.Text == "")
                {
                    MessageBox.Show("Please enter your ID and Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    conn = new SqlConnection("Data Source=DESKTOP-UQ0368S\\SQLEXPRESS; Initial Catalog=Hospital_Appointment_System; User Id=sa; password=sqlserver;");
                    kmt = new SqlCommand();
                    conn.Open();
                    kmt.Connection = conn;
                    kmt.CommandText = "SELECT * FROM Doctor WHERE doctorID='" + ıdtextBox.Text + "' AND password='" + passwordtextBox.Text + "'";
                    dr = kmt.ExecuteReader();

                    if (controlıdtxtbox.Text == "7564")
                    {
                        if (dr.Read())
                        {


                            doctor.textBox1.Text = id;
                            doctor.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong ID or Password!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Wrong Control ID!");
                    }

                    conn.Close();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            open1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the system?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
    }