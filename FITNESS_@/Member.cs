using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FITNESS__
{
    public partial class Member : Form
    {
        Functions Con;
        public Member()
        {
            InitializeComponent();
            Con= new Functions();
            ShowMemb();
            Getcoach();
            Getmembership();
        }
        private void ShowMemb()
        {
            string Query = "select * from customer";
            Member_list.DataSource = Con.GetData(Query);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

            Member ob = new Member();
            ob.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Coach ob = new Coach();
            ob.Show();
            this.Hide();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Reception ob = new Reception();
            ob.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            Membership ob = new Membership();
            ob.Show();
            this.Hide();
        }

        private void Getcoach()
        {
            string Query = "select * from coach";

            CoachSelelct.DisplayMember = Con.GetData(Query).Columns["cname"].ToString();
            CoachSelelct.ValueMember = Con.GetData(Query).Columns["cid"].ToString();
            CoachSelelct.DataSource = Con.GetData(Query);

        }

        private void Getmembership()
        {
            string Query = "select * from membership";
            Mselect.DisplayMember = Con.GetData(Query).Columns["mname"].ToString();
            Mselect.ValueMember = Con.GetData(Query).Columns["mid"].ToString();
            Mselect.DataSource = Con.GetData(Query);

        }
        private void reset()
        {
            MembDOB.Text ="";
            MembN.Text = "";
            MembPhone.Text ="";
            MembG.SelectedIndex =-1; 
            Timing.SelectedIndex = -1;
            MembStatus.SelectedIndex =-1;
            Mselect.SelectedIndex = -1;
            CoachSelelct.SelectedIndex = -1;
        }

        private void MembSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MembDOB.Text == "" || MembN.Text == "" || MembPhone.Text == "" || MembG.SelectedIndex == -1 || Timing.SelectedIndex  == -1 || MembStatus.SelectedIndex == -1)
                    MessageBox.Show(" Missing Data !!! ");
                else
                {
                    string MName = MembN.Text;
                    string MGender = MembG.SelectedItem.ToString();
                    string MPhone = MembPhone.Text;
                    int MShip = Convert.ToInt32(Mselect.SelectedValue.ToString());
                    int MCoach = Convert.ToInt32(CoachSelelct.SelectedValue.ToString());
                    string MTiming = Timing.SelectedItem.ToString();
                    string MStatus = MembStatus.SelectedItem.ToString();
                    DateTime JoinD = DateTime.Now;
                    string Query = "insert into customer values('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}' ,'{5}','{6}','{7}','{8}' )";
                    Query = string.Format(Query, MName, MGender, MembDOB.Value.Date, MPhone, MShip,MTiming,MCoach,MStatus,JoinD);
                    Con.SetData(Query);
                    ShowMemb();
                    MessageBox.Show("Succesfully Added");  
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        int key;
        private void Member_list_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            reset();
            MembN.Text = Member_list.SelectedRows[0].Cells[1].Value.ToString();
            MembG.SelectedItem = Member_list.SelectedRows[0].Cells[2].Value.ToString();
            MembDOB.Text = Member_list.SelectedRows[0].Cells[3].Value.ToString();
            MembPhone.Text = Member_list.SelectedRows[0].Cells[4].Value.ToString();
            Mselect.Text = Member_list.SelectedRows[0].Cells[5].Value.ToString();
            Timing.Text = Member_list.SelectedRows[0].Cells[6].Value.ToString();
            CoachSelelct.Text = Member_list.SelectedRows[0].Cells[7].Value.ToString();
            MembStatus.Text = Member_list.SelectedRows[0].Cells[8].Value.ToString();

            if (MembN.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Member_list.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void MembEdit_Click(object sender, EventArgs e)
        {

            try
            {
                if (MembDOB.Text == "" || MembN.Text == "" || MembPhone.Text == "" || MembG.SelectedIndex == -1 || Timing.SelectedIndex == -1 || MembStatus.SelectedIndex == -1)
                    MessageBox.Show(" Missing Data !!! ");
                else
                {
                    string MName = MembN.Text;
                    string MGender = MembG.SelectedItem.ToString();
                    string MPhone = MembPhone.Text;
                    int MShip = Convert.ToInt32(Mselect.SelectedValue.ToString());
                    int MCoach = Convert.ToInt32(CoachSelelct.SelectedValue.ToString());
                    string MTiming = Timing.SelectedItem.ToString();
                    string MStatus = MembStatus.SelectedItem.ToString();
                    DateTime JoinD = DateTime.Now;
                    string Query = "update customer set uname='{0}' ,u_gen='{1}' ,udob='{2}' ,u_phone='{3}' ,u_memb='{4}' ,u_t='{5}',ucoach ='{6}',u_stat ='{7}' where u_id = '{8}' ";
                    Query = string.Format(Query, MName, MGender, MembDOB.Value.Date, MPhone, MShip, MTiming, MCoach, MStatus,key);
                    Con.SetData(Query);
                    ShowMemb();
                    MessageBox.Show("Succesfully Updated");
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void MembDelete_Click(object sender, EventArgs e)
        {

            try
            {
                if (key == 0)
                {
                    MessageBox.Show(" Select a Member !!! ");

                }
                else
                {
                    
                    string Query = "delete from customer where u_id ={0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowMemb();
                    MessageBox.Show("Member Deleted!!!");
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
