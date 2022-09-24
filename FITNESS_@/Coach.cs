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
using System.Data;
namespace FITNESS__
{
    public partial class Coach : Form
    {
        Functions Con;
        public Coach()
        {
            InitializeComponent();
            Con  = new Functions();
            ShowCoach();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
        private SqlConnection Conn = new SqlConnection("Data Source=LAPTOP-NCEDVHBS;Initial Catalog=defense_project;Integrated Security=True");


        private void ShowCoach()
        {
            string Query = "select * from coach";
            coachlist.DataSource = Con.GetData(Query);
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (Cphone.Text == "" || Cname.Text == "" || Cdob.Text == "" || Cpass.Text == "" || Cgender.Text == "")
                {
                    MessageBox.Show(" Missing Data !!! ");

                }
                else
                {
                    string CName = Cname.Text;
                    string CGender = Cgender.SelectedItem.ToString();
                    string CPhone = Cphone.Text;
                    string Speial = Cspeciality.Text;
                    string Pass = Cpass.Text;
                    DateTime CDOB = DateTime.Parse(Cdob.Text);
                    SqlCommand c = new SqlCommand("exec add_coach " + CName + "','" + CDOB + "','" + CPhone + "',default,'" + Pass, Conn);
                    string Query = "insert into coach values('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}' )";
                    Query = string.Format(Query, CName, CGender, Cdob.Value.Date, CPhone, Speial, Pass);
                    Con.SetData(Query);
                    ShowCoach();
                    MessageBox.Show("Succesfully Added");
                }
            }
            catch (Exception ex) { 
              MessageBox.Show(ex.Message);
            
            }
            
        }
        int key;
        private void coachlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Cname.Text = coachlist.SelectedRows[0].Cells[1].Value.ToString();
            Cgender.SelectedItem = coachlist.SelectedRows[0].Cells[2].Value.ToString();
            Cdob.Text = coachlist.SelectedRows[0].Cells[3].Value.ToString();
            Cphone.Text = coachlist.SelectedRows[0].Cells[4].Value.ToString();
            Cspeciality.Text = coachlist.SelectedRows[0].Cells[5].Value.ToString();
            Cpass.Text = coachlist.SelectedRows[0].Cells[6].Value.ToString();

            if(Cname.Text == "")
            {
                key= 0;
            }
            else
            {
                key = Convert.ToInt32(coachlist.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show(" Select a Coach !!! ");

                }
                else
                {
                    string CName = Cname.Text;
                    string CGender = Cgender.SelectedItem.ToString();
                    string CPhone = Cphone.Text;
                    string Speial = Cspeciality.Text;
                    string Pass = Cpass.Text;
                    DateTime CDOB = DateTime.Parse(Cdob.Text);
                    string Query = "delete from coach where cid ={0}";
                    Query = string.Format(Query,key);
                    Con.SetData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Deleted!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show(" Select a Coach !!! ");

                }
                else
                {
                    string CName = Cname.Text;
                    string CGender = Cgender.SelectedItem.ToString();
                    string CPhone = Cphone.Text;
                    string Speial = Cspeciality.Text;
                    string Pass = Cpass.Text;
                    DateTime CDOB = DateTime.Parse(Cdob.Text);
                    string Query = "update coach set cname= '{0}',cgender ='{1}',cdob = '{2}',cphone = '{3}',speciality = '{4}', cpass = '{5}' where cid= '{6}' ";
                    Query = string.Format(Query, CName, CGender, Cdob.Value.Date, CPhone, Speial, Pass,key);
                    Con.SetData(Query);
                    ShowCoach();
                    MessageBox.Show("Coach Updated!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
