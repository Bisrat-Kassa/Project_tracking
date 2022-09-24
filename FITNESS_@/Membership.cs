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
    public partial class Membership : Form
    {
        Functions Con;
        public Membership()
        {
            InitializeComponent();
            Con = new Functions();
            showMembership();
        }

        private void showMembership()
        {
            string Query = "select * from membership";
            Membership_list.DataSource = Con.GetData(Query);
        }
        private void Membership_Load(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            Mname.Text = "";
            Mduration.Text = "";
            Mcoast.Text = "";
        }

        private void Msave_Click(object sender, EventArgs e)
        {
            try
            {
                if ( Mname.Text == "" || Mduration.Text == "" || Mcoast.Text == "" )
                {
                    MessageBox.Show(" Missing Data !!! ");

                }
                else
                {
                    string name = Mname.Text;
                    int duration = Convert.ToInt32(Mduration.Text);
                    int coast = Convert.ToInt32(Mcoast.Text);
                    string Query = "insert into membership values('{0}' ,'{1}' ,'{2}' )";
                    Query = string.Format(Query, name, duration, coast);
                    Con.SetData(Query);
                    showMembership();
                    MessageBox.Show("Succesfully Added");
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
        int key = 0;
        private void Membership_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Mname.Text = Membership_list.SelectedRows[0].Cells[1].Value.ToString();
            Mduration.Text = Membership_list.SelectedRows[0].Cells[2].Value.ToString();
            Mcoast.Text = Membership_list.SelectedRows[0].Cells[3].Value.ToString();
            if (Mname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Membership_list.SelectedRows[0].Cells[0].Value.ToString());
            }

        }

        private void Mdelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show(" Select a Membership !!! ");

                }
                else
                {
                    string Query = "delete from membership where mid ={0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    showMembership();
                    MessageBox.Show("Membership Deleted!!!");
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Medit_Click(object sender, EventArgs e)
        {


            try
            {
                if (key == 0)
                {
                    MessageBox.Show(" Select a Membership !!! ");

                }
                else
                {
                    string name = Mname.Text;
                    int duration = Convert.ToInt32(Mduration.Text);
                    int coast = Convert.ToInt32(Mcoast.Text);
                    string Query = "update membership set mname ='{0}' ,mduration ='{1}' ,mcoast = '{2}' where mid ={3}";
                    Query = string.Format(Query,name,duration,coast ,key);
                    Con.SetData(Query);
                    showMembership();
                    MessageBox.Show("Membership Updated!!!");
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }
    }
}
