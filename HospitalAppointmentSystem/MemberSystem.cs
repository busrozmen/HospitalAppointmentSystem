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
    public partial class MemberSystem : Form
    {
        public Login login;
        public HospitalSystem hospital;
       

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-UQ0368S\\SQLEXPRESS; Initial Catalog=Hospital_Appointment_System; User Id=sa; password=sqlserver;");
        SqlCommand kmt = new SqlCommand();
        SqlDataAdapter da;
        DataSet dtst = new DataSet();

        void listele(string sorgu)
        {
            dtst.Clear();
            conn.Open();
            kmt.CommandText = sorgu;
            kmt.Connection = conn;
            da = new SqlDataAdapter(kmt);
            da.Fill(dtst, "Patient");
            dataGridView1.DataSource = dtst;
            dataGridView1.DataMember = "Patient";
            dataGridView1.Columns["password"].Visible = false;
            conn.Close();
        }


        public MemberSystem()
        {

            hospital = new HospitalSystem();
            InitializeComponent();
        }
             public MemberSystem(Appointment appointment)
        {

            hospital = new HospitalSystem();
            InitializeComponent();
           
            



        }

        private void MemberSystem_Load(object sender, EventArgs e)
        {
            }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((passwordtextbox.Text == apasswordtextbox.Text) && (tctextbox.TextLength == 11))
                {

                    conn.Open();
                    kmt.Connection = conn;
                    string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                    string Gender = " ";
                    if (male.Checked == true)
                    {
                        Gender = male.Text;
                    }
                    if (female.Checked == true)
                    {
                        Gender = female.Text;
                    }
                    kmt.CommandText = "INSERT INTO Patient Values( '" + tctextbox.Text + "','" + nametextbox.Text + "','" + surnametextbox.Text + "','" + Gender + "','" + theDate + "','" + passwordtextbox.Text + "')";
                    
                    kmt.ExecuteNonQuery();
                    conn.Close();
                    kmt.Dispose();
                    dtst.Clear();
                    listele("select * from Patient");
                }
                else if (passwordtextbox.Text != apasswordtextbox.Text)
                {
                    MessageBox.Show("Please same password! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if(tctextbox.TextLength != 11)
                {
                
                    MessageBox.Show("Your TC length must be 11 (eleven) ","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void nextbutton_Click(object sender, EventArgs e)
        {
            login.Show();
            
            this.Hide();
        }

        private void viewbutton_Click(object sender, EventArgs e)
        {
            try
            {
                listele("select * from Patient where patientID='" + tctextbox.Text + "'");
                nametextbox.Text = dataGridView1.Rows[0].Cells["firstName"].Value.ToString();
                surnametextbox.Text = dataGridView1.Rows[0].Cells["surName"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[0].Cells["birthDate"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
        private void updatebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (passwordtextbox.Text == apasswordtextbox.Text)
                {
                    conn.Open();
            kmt.Connection = conn; 
            string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                    string Gender = " ";
                    if (male.Checked == true)
                    {
                        Gender = male.Text;
                    }
                    if (female.Checked == true)
                    {
                         Gender = female.Text;
                    }
                    kmt.CommandText = "UPDATE Patient SET firstName = '" + nametextbox.Text + "',surName = '" + surnametextbox.Text + "',gender = '"+ Gender+ "' ,birthDate = '" + theDate + "' WHERE patientID = '" + tctextbox.Text + "'";
           
            kmt.ExecuteNonQuery();
            conn.Close();
            kmt.Dispose();
            dtst.Clear();
            listele("select * from Patient where patientID='" + tctextbox.Text + "'");
                }
                else if (passwordtextbox.Text != apasswordtextbox.Text)
                {
                    MessageBox.Show("Please same password! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void deletebutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete your registration?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    kmt.Connection = conn;
                    kmt.CommandText = "DELETE from Patient WHERE patientID= '" + tctextbox.Text + "'";
                    kmt.ExecuteNonQuery();
                    conn.Close();
                    kmt.Dispose();
                    dtst.Clear();
                    listele("select * from Patient");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            tctextbox.Clear();
            nametextbox.Clear();
            surnametextbox.Clear();
            passwordtextbox.Clear();
            apasswordtextbox.Clear();
            dateTimePicker1.Value = DateTime.Today;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the system?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}

