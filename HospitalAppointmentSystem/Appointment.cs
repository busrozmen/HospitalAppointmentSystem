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
    public partial class Appointment : Form
    {
        
        public HospitalSystem hospital;
        public Login login;
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UQ0368S\\SQLEXPRESS; Initial Catalog=Hospital_Appointment_System; User Id=sa; password=sqlserver;");
        SqlCommand kmt = new SqlCommand();
        DataSet dtst = new DataSet();

        public Appointment()
        {
            InitializeComponent();
        }

        private void Appointment_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete your appointment ? ", "Delete Appointment!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    kmt.Connection = conn;
                    kmt.CommandText = "DELETE from Operation WHERE operationNo = '" + oplabel.Text + "'";
                    kmt.ExecuteNonQuery();
                    conn.Close();
                    kmt.Dispose();
                    dtst.Clear();
                    MessageBox.Show("Your appointment has been deleted successfully!", "Deleted!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Login login = new Login();
                    login.Show();
                    this.Hide();
                }else
                {
                    this.Show();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
    }

