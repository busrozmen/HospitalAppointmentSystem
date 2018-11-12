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
    public partial class DoctorSystem : Form
    {
        public Login login;
        public DoctorLogin doctorlogin;
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
            da.Fill(dtst, "Doctor");
            dataGridView1.DataSource = dtst;
            dataGridView1.DataMember = "Doctor";
            dataGridView1.Columns["password"].Visible = false;
            conn.Close();     

        }

        public DoctorSystem()
        {
            InitializeComponent();

          
        }

        public DoctorSystem(DoctorLogin doctorlogin)
        {
            this.doctorlogin = doctorlogin;
            InitializeComponent();


        }

        private void DoctorSystem_Load(object sender, EventArgs e)
        {
         

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if ((passwordtextbox.Text == apasswordtextbox.Text) && (controlıdtextbox.Text == "7564"))
                {

                    conn.Open();
                    kmt.Connection = conn;
                    string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                  
                    kmt.CommandText = "INSERT INTO Doctor([Name Surname],branch,clinic,date,password) VALUES ('" + textBox2.Text + "','" + BranchListBox.Text + "','" + ClinicListBox.Text + "','" + theDate + "','" + passwordtextbox.Text + "')";
                    kmt.ExecuteNonQuery();
                    conn.Close();
                    kmt.Dispose();
                    dtst.Clear();
                    listele("select *from Doctor");
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("SELECT doctorID FROM Doctor WHERE [Name Surname] = '" + textBox2.Text + "' AND branch= '" + BranchListBox.Text + "' AND clinic='" + ClinicListBox.Text + "' AND date='"+theDate+"' AND password='"+passwordtextbox.Text+"'", conn);
                    SqlDataReader rdr1= cmd1.ExecuteReader();
                    while (rdr1.Read())
                    {
                       
                        textBox1.Text= rdr1.GetInt32(0).ToString() ;

                       

                    }
                    conn.Close();
                    rdr1.Close();
                }
                else if (passwordtextbox.Text != apasswordtextbox.Text)
                {
                    MessageBox.Show("Please Enter Same Password! ");
                }
                else if (controlıdtextbox.Text != "7564")
                {
                    MessageBox.Show("Wrong ControlID ! ");
                }
                else if ((controlıdtextbox.Text != "7564") && (passwordtextbox.Text != apasswordtextbox.Text))
                {
                    MessageBox.Show("Wrong ControlID or Different Password! ");
                }
            } 
         catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
}

        private void BranchListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
                   }
       

        private void button2_Click(object sender, EventArgs e)
        {
            string a = BranchListBox.Text;
            ClinicListBox.Items.Add(a + " POL 1 ");
            ClinicListBox.Items.Add(a + " POL 2 ");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {
                if ((passwordtextbox.Text == apasswordtextbox.Text) && (controlıdtextbox.Text == "7564"))
                {
                    conn.Open();
            kmt.Connection = conn;
                
            string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            kmt.CommandText = "UPDATE Doctor SET [Name Surname] = '" + textBox2.Text + "',branch = '"+ BranchListBox.Text + "',clinic = '"+ ClinicListBox.Text + "', date = '"+theDate+ "', password= '"+passwordtextbox.Text + "' WHERE doctorID = '" + textBox1.Text + "'";
            kmt.ExecuteNonQuery();
            conn.Close();
            kmt.Dispose();
            dtst.Clear();
            listele("select *from Doctor where doctorID ='" + textBox1.Text +"'");
                }
                else if (passwordtextbox.Text != apasswordtextbox.Text)
                {
                    MessageBox.Show("Please Enter Same Password! ");
                }
                else if (controlıdtextbox.Text != "7564")
                {
                    MessageBox.Show("Wrong ControlID ! ");
                }
                else if ((controlıdtextbox.Text != "7564") && (passwordtextbox.Text != apasswordtextbox.Text))
                {
                    MessageBox.Show("Wrong ControlID or Different Password! ");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {

            try
            {
                if (MessageBox.Show("Do you want to delete your registration?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    conn.Open();
                    kmt.Connection = conn;
                    kmt.CommandText = "DELETE from Doctor WHERE doctorID= '" + textBox1.Text + "'";
                    kmt.ExecuteNonQuery();
                    conn.Close();
                    kmt.Dispose();
                    dtst.Clear();
                    listele("select * from Doctor");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                listele("select * from Doctor where doctorID='" + textBox1.Text + "'");
                textBox2.Text = dataGridView1.Rows[0].Cells["Name Surname"].Value.ToString();
                BranchListBox.Text = dataGridView1.Rows[0].Cells["branch"].Value.ToString();
                ClinicListBox.Items.Add(dataGridView1.Rows[0].Cells["clinic"].Value.ToString());
                dateTimePicker1.Text = dataGridView1.Rows[0].Cells["date"].Value.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
         {
             textBox1.Clear();
             textBox2.Clear();
             ClinicListBox.ClearSelected();
             ClinicListBox.Items.Clear();
             BranchListBox.ClearSelected();
             passwordtextbox.Clear();
             apasswordtextbox.Clear();
             controlıdtextbox.Clear();
             dateTimePicker1.Value = DateTime.Today;



        }

         private void button7_Click(object sender, EventArgs e)
         {
             doctorlogin.Show();
             this.Hide();
         }

         private void button8_Click(object sender, EventArgs e)
         {
             if (MessageBox.Show("Do you want to close the system?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
             {
                 Application.Exit();
             }
         }

         private void button9_Click(object sender, EventArgs e)
         {
            try
            {
                if ((passwordtextbox.Text == apasswordtextbox.Text) && (controlıdtextbox.Text == "7564"))
                {

                    conn.Open();
                    kmt.Connection = conn;
                    string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");

                    kmt.CommandText = "INSERT INTO Doctor([Name Surname],branch,clinic,date,password) VALUES ('" + textBox2.Text + "','" + BranchListBox.Text + "','" + ClinicListBox.Text + "','" + theDate + "','" + passwordtextbox.Text + "')";
                    kmt.ExecuteNonQuery();
                    conn.Close();
                    kmt.Dispose();
                    dtst.Clear();
                    listele("select *from Doctor");
                    conn.Open();
                    SqlCommand cmd1 = new SqlCommand("SELECT doctorID FROM Doctor WHERE [Name Surname] = '" + textBox2.Text + "' AND branch= '" + BranchListBox.Text + "' AND clinic='" + ClinicListBox.Text + "' AND date='" + theDate + "' AND password='" + passwordtextbox.Text + "'", conn);
                    SqlDataReader rdr1 = cmd1.ExecuteReader();
                    while (rdr1.Read())
                    {

                        textBox1.Text = rdr1.GetInt32(0).ToString();



                    }
                    conn.Close();
                    rdr1.Close();
                }
                else if (passwordtextbox.Text != apasswordtextbox.Text)
                {
                    MessageBox.Show("Please Enter Same Password! ");
                }
                else if (controlıdtextbox.Text != "7564")
                {
                    MessageBox.Show("Wrong ControlID ! ");
                }
                else if ((controlıdtextbox.Text != "7564") && (passwordtextbox.Text != apasswordtextbox.Text))
                {
                    MessageBox.Show("Wrong ControlID or Different Password! ");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

         private void button10_Click(object sender, EventArgs e)
         {

             try
             {
                 conn.Open();

                 SqlCommand cmd8 = new SqlCommand("SELECT O.operationNo,CONCAT(P.firstName, ' ', P.surName) AS[Name Surname] ,P.gender,P.birthDate,O.hour,O.date FROM Operation O inner join Patient P ON O.patientID = P.patientID inner join Doctor D ON D.doctorID = O.doctorID WHERE O.doctorID = '" + textBox1.Text + "'",conn);
                 SqlDataReader rdr8 = cmd8.ExecuteReader();
                 while (rdr8.Read())
                 {
                     string operation_id = rdr8[0].ToString();
                     string PatientName = rdr8[1].ToString();
                     string gender = rdr8[2].ToString();
                     string birthdate = rdr8[3].ToString();
                     string hour = rdr8[4].ToString();
                     string date = rdr8[5].ToString();
                     string[] arry = { operation_id, PatientName, gender, birthdate, hour,date };
                     ListViewItem item = new ListViewItem(arry);
                     lvDoctors.Items.Add(item);
                 }
                 conn.Close();
                 rdr8.Close();


             }
             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message);
             }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime d_date = Convert.ToDateTime(dateTimePicker1.Text);
            string day = string.Empty;
            day = d_date.ToString("dddd");
            if (day != "Cumartesi" && day != "Pazar")
            {   
            }
            else {
                MessageBox.Show("You can not take appoinment on Saturday and Sunday ");
            }    
    }
    }
}