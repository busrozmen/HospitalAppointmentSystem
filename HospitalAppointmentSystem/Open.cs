using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalAppointmentSystem
{
    public partial class Open : Form
    {
        public Login login;
        public MemberSystem member;
        public DoctorSystem doctor;
        public DoctorLogin doctorlogin;

        public Open()
        {
            InitializeComponent();
            login = new Login(this);
            member = new MemberSystem();
            doctor = new DoctorSystem();
            doctorlogin = new DoctorLogin(this);

        }

        private void enterbutton_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                doctorlogin.Show();
                this.Hide();
            }
            if (radioButton2.Checked == true)
            {
                login.Show();
                this.Hide();
            }
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
               
                MessageBox.Show("Please Select One ","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }

        }


        private void male_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void female_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Open_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


