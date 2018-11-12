using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalAppointmentSystem
{
    public partial class Login : Form
    {
        public MemberSystem member;
        public HospitalSystem hospital;
        public DoctorSystem doctor;
        SqlConnection conn;
        SqlCommand kmt;
        SqlDataReader dr;
        public Open open2 = null;

        public Login()
        {
            InitializeComponent();
            member = new MemberSystem();
            hospital = new HospitalSystem();
            doctor = new DoctorSystem();
            member.login = this;
            hospital.login = this;
            doctor.login = this;

        }
        public Login(Open open)
        {
            InitializeComponent();
            open2 = open;
            member = new MemberSystem();
            hospital = new HospitalSystem();
            doctor = new DoctorSystem();
            member.login = this;
            hospital.login = this;
            doctor.login = this;
          

        }

        public static string tc;
        public Login(string tc)
        {
            tctextBox.Text = tc;

        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            member.Show();
            this.Hide();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            tc = tctextBox.Text;
            if (tctextBox.Text == "" && passwordtextBox.Text != "")
            {
                MessageBox.Show("Please enter your TC", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (passwordtextBox.Text == "" && tctextBox.Text != "")
            {
                MessageBox.Show("Please enter your Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (tctextBox.Text == "" && passwordtextBox.Text == "")
            {
                MessageBox.Show("Please enter your TC and Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                 
                conn = new SqlConnection("Data Source=DESKTOP-UQ0368S\\SQLEXPRESS; Initial Catalog=Hospital_Appointment_System; User Id=sa; password=sqlserver;");
                kmt = new SqlCommand();
                conn.Open();
                kmt.Connection = conn;
                kmt.CommandText = "SELECT * FROM Patient WHERE patientID='" + tctextBox.Text + "' AND password='" + passwordtextBox.Text + "'";
                dr = kmt.ExecuteReader();
                if(dr.Read())
                {
                hospital.Show();
                this.Hide();
                }
               else {
                    MessageBox.Show("Wrong TC or Password!");
                }

                conn.Close();
            }
            }
       
        private void button7_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            open2.Show();
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


