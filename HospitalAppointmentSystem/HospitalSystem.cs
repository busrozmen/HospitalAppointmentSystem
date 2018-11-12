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
    public partial class HospitalSystem : Form
    {

        public Login login;
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

            conn.Close();
        }



        public HospitalSystem()
        {
            InitializeComponent();
          
            
        }

        private void HospitalSystem_Load(object sender, EventArgs e)
        {
           patientıdlabel.Text = login.tctextBox.Text;
           label7.Visible = false;
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void branchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string a = branchComboBox.Text;
            clinicComboBox.Items.Add(a + " POL 1 ");
            clinicComboBox.Items.Add(a + " POL 2 ");
        }

        private void clinicComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void doctorbutton_Click(object sender, EventArgs e)
        {

            try
            {
                string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                listele("SELECT [Name Surname],branch,clinic,date FROM Doctor WHERE branch = '" + branchComboBox.Text + "' AND clinic= '" + clinicComboBox.Text + "' AND date= '" + theDate + "'");
                conn.Open();
                SqlCommand cmd2 = new SqlCommand("SELECT [Name Surname] FROM Doctor WHERE branch = '" + branchComboBox.Text + "' AND clinic= '" + clinicComboBox.Text + "' AND date= '" + theDate + "'", conn);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    
                    comboBox1.Items.Add(rdr2.GetString(0));
                }
                conn.Close();

                rdr2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       

        private void btn1_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn1.Text;
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn2.Text;
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn3.Text;
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn4.Text;
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn5.Text;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn6.Text;
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn7.Text;
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn8.Text;
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn9.Text;
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn10.Text;
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn11.Text;
        }

        private void btn12_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn12.Text;
        }

        private void btn13_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn13.Text;
        }

        private void btn14_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn14.Text;
        }

        private void btn15_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn15.Text;
        }

        private void btn16_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn16.Text;
        }

        private void btn17_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn17.Text;
        }

        private void btn18_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn18.Text;
        }

        private void btn19_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn19.Text;
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn20.Text;
        }

        private void btn21_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn21.Text;
        }

        private void btn22_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn22.Text;
        }
        public int dr_id;
        private void btn23_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn23.Text;
        }

        private void btn24_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn24.Text;
        }
        private void btn25_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn25.Text;
        }

        private void btn26_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn26.Text;
        }

        private void btn27_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn27.Text;
        }

        private void btn28_Click(object sender, EventArgs e)
        {
            hourtextBox.Text = btn28.Text;
        }
        public void readhour()
        {
            try
            {
                conn.Open();
                string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
                SqlCommand cmd3 = new SqlCommand("SELECT hour FROM Operation WHERE date='" + theDate + "' and doctorName='" + comboBox1.Text + "' and clinicName='" + clinicComboBox.Text + "' and doctorID='" + label7.Text + "'", conn);
                SqlDataReader rdr3 = cmd3.ExecuteReader();
                listBox1.Items.Clear();
                while (rdr3.Read())
                {
                    listBox1.Items.Add(rdr3.GetString(0).ToString());
                }
                rdr3.Close();
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
        public void listAll()
        {
            btn1.Enabled = true; btn2.Enabled = true; btn3.Enabled = true; btn4.Enabled = true; btn5.Enabled = true; btn6.Enabled = true; btn7.Enabled = true; btn8.Enabled = true; btn9.Enabled = true; btn10.Enabled = true; btn11.Enabled = true; btn12.Enabled = true; btn13.Enabled = true; btn14.Enabled = true;
            btn15.Enabled = true; btn16.Enabled = true; btn17.Enabled = true; btn18.Enabled = true; btn19.Enabled = true; btn20.Enabled = true; btn21.Enabled = true; btn22.Enabled = true; btn23.Enabled = true; btn24.Enabled = true; btn25.Enabled = true; btn26.Enabled = true; btn27.Enabled = true; btn28.Enabled = true;

            btn1.BackColor = Color.SpringGreen; btn2.BackColor = Color.SpringGreen; btn3.BackColor = Color.SpringGreen; btn4.BackColor = Color.SpringGreen;
            btn5.BackColor = Color.SpringGreen; btn6.BackColor = Color.SpringGreen; btn7.BackColor = Color.SpringGreen; btn8.BackColor = Color.SpringGreen;
            btn9.BackColor = Color.SpringGreen; btn10.BackColor = Color.SpringGreen; btn11.BackColor = Color.SpringGreen; btn12.BackColor = Color.SpringGreen;
            btn13.BackColor = Color.SpringGreen; btn14.BackColor = Color.SpringGreen; btn15.BackColor = Color.SpringGreen; btn16.BackColor = Color.SpringGreen;
            btn17.BackColor = Color.SpringGreen; btn18.BackColor = Color.SpringGreen; btn19.BackColor = Color.SpringGreen; btn20.BackColor = Color.SpringGreen;
            btn21.BackColor = Color.SpringGreen; btn22.BackColor = Color.SpringGreen; btn23.BackColor = Color.SpringGreen; btn24.BackColor = Color.SpringGreen;
            btn25.BackColor = Color.SpringGreen; btn26.BackColor = Color.SpringGreen; btn27.BackColor = Color.SpringGreen; btn28.BackColor = Color.SpringGreen;

            listBox1.Items.Clear();
            readhour();
            int count = listBox1.Items.Count;
            string value = null;
            for (int i = 0; i < count; i++)
            {
                if (listBox1.Items[i].ToString() == btn1.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn1.BackColor = Color.Gray;
                    btn1.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn2.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn2.BackColor = Color.Gray;
                    btn2.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn3.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn3.BackColor = Color.Gray;
                    btn3.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn4.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn4.BackColor = Color.Gray;
                    btn4.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn5.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn5.BackColor = Color.Gray;
                    btn5.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn6.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn6.BackColor = Color.Gray;
                    btn6.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn7.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn7.BackColor = Color.Gray;
                    btn7.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn8.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn8.BackColor = Color.Gray;
                    btn8.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn9.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn9.BackColor = Color.Gray;
                    btn9.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn10.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn10.BackColor = Color.Gray;
                    btn10.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn11.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn11.BackColor = Color.Gray;
                    btn11.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn12.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn12.BackColor = Color.Gray;
                    btn12.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn13.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn13.BackColor = Color.Gray;
                    btn13.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn14.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn14.BackColor = Color.Gray;
                    btn14.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn15.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn15.BackColor = Color.Gray;
                    btn15.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn16.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn16.BackColor = Color.Gray;
                    btn16.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn17.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn17.BackColor = Color.Gray;
                    btn17.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn18.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn18.BackColor = Color.Gray;
                    btn18.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn19.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn19.BackColor = Color.Gray;
                    btn19.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn20.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn20.BackColor = Color.Gray;
                    btn20.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn21.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn21.BackColor = Color.Gray;
                    btn21.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn22.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn22.BackColor = Color.Gray;
                    btn22.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn24.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn24.BackColor = Color.Gray;
                    btn24.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn25.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn25.BackColor = Color.Gray;
                    btn25.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn26.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn26.BackColor = Color.Gray;
                    btn26.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn27.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn27.BackColor = Color.Gray;
                    btn27.Enabled = false;
                }
                else if (listBox1.Items[i].ToString() == btn28.Text)
                {
                    value = listBox1.Items[i].ToString();
                    btn28.BackColor = Color.Gray;
                    btn28.Enabled = false;
                }

                readhour();
            }

        }
        public string value;

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
             DateTime d_date = Convert.ToDateTime(dateTimePicker1.Text);
             string day = string.Empty;
             day = d_date.ToString("dddd");
             if (day != "Cumartesi" && day != "Pazar")
             {
                 listAll();
             }
             else
             {
                 MessageBox.Show("You can not take appoinment on Saturday and Sunday ");
             }


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Select your choise from Doctor combobox!");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {try
            {
                conn.Open();
                SqlCommand cmd9 = new SqlCommand("SELECT doctorID FROM Doctor  WHERE [Name Surname] = '" + comboBox1.Text + "'", conn);
                SqlDataReader rdr9 = cmd9.ExecuteReader();
                while (rdr9.Read())
                {
                    label7.Text = rdr9.GetInt32(0).ToString();
                }
                conn.Close();
                rdr9.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == -1)
            {
                MessageBox.Show("Please make a selection");
            }
            else
            {
                readhour();
                listAll();

            }
        }

        private void appointmentbutton_Click(object sender, EventArgs e)
        {
           try { 
            Appointment appointment = new Appointment();
            conn.Open();
            kmt.Connection = conn;
            string theDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            kmt.CommandText = "INSERT INTO Operation(date,hour,doctorName,clinicName,patientID,doctorID) Values('" + theDate + "','" + hourtextBox.Text + "','" + comboBox1.Text + "','" + clinicComboBox.Text + "','"+patientıdlabel.Text+"','"+label7.Text+"')";
            kmt.ExecuteNonQuery();
            conn.Close();
            kmt.Dispose();

                if (MessageBox.Show("Your appointment has been saved successfully! ", "Good job!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {

                    conn.Open();
                    SqlCommand cmd5 = new SqlCommand("SELECT OperationNo,CONCAT(firstName,' ',surName ) AS [Name Surname] FROM Operation O inner join Patient P ON O.patientID = P.patientID WHERE date = '" + theDate + "' AND hour= '" + hourtextBox.Text + "' AND doctorName= '" + comboBox1.Text + "' AND clinicName='" + clinicComboBox.Text + "'", conn);
                    SqlDataReader rdr5 = cmd5.ExecuteReader();
                    while (rdr5.Read())
                    {


                        appointment.oplabel.Text = rdr5["OperationNo"].ToString();
                        appointment.patientnslabel.Text = rdr5["Name Surname"].ToString();

                    }
                    conn.Close();
                    rdr5.Close();

                    appointment.doctorlabel.Text = comboBox1.Text;
                    appointment.branchlabel.Text = branchComboBox.Text;
                    appointment.cliniclabel.Text = clinicComboBox.Text;
                    appointment.datelabel.Text = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd"); ;
                    appointment.hourlabel.Text = hourtextBox.Text;
                    appointment.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }


        }
    }
}
    
        
  
