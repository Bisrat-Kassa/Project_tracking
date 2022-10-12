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
    public partial class Reception : Form
    {
        Functions Con;
        public Reception()
        {
            InitializeComponent();
            Con = new Functions();
            ShowRecep();
        }
        private void ShowRecep()
        {
            string Query = "select * from reception";
            Receptionist_list.DataSource = Con.GetData(Query);
        }
        private void reset()
        {
            Rname.Text = "";
            Rphone.Text = "";
            Rpass.Text = "";

        }

        private void Rsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Rphone.Text == "" || Rname.Text == "" || Rdob.Text == "" || Rpass.Text == "" || Rgender.Text == "")
                {
                    MessageBox.Show(" Missing Data !!! ");

                }
                else
                {
                    string RName = Rname.Text;
                    string RGender = Rgender.SelectedItem.ToString();
                    string RPhone = Rphone.Text;
                    string Pass = Rpass.Text;
                    DateTime CDOB = DateTime.Parse(Rdob.Text);
                    string Query = "insert into reception values('{0}' ,'{1}' ,'{2}' ,'{3}' ,'{4}')";
                    Query = string.Format(Query, RName, RGender, Rdob.Value.Date, RPhone ,Pass);
                    Con.SetData(Query);
                    ShowRecep();
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
        private void Receptionist_list_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Rname.Text = Receptionist_list.SelectedRows[0].Cells[1].Value.ToString();
            Rgender.SelectedItem = Receptionist_list.SelectedRows[0].Cells[2].Value.ToString();
            Rdob.Text = Receptionist_list.SelectedRows[0].Cells[3].Value.ToString();
            Rphone.Text = Receptionist_list.SelectedRows[0].Cells[4].Value.ToString();
            Rpass.Text = Receptionist_list.SelectedRows[0].Cells[5].Value.ToString();

            if (Rname.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(Receptionist_list.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void Rdelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (key == 0)
                {
                    MessageBox.Show(" Select a Coach !!! ");

                }
                else
                {
                    
                    string Query = "delete from reception where rid ='{0}'";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowRecep();
                    MessageBox.Show("Receptionist Deleted!!!");
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Redit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Rphone.Text == "" || Rname.Text == "" || Rdob.Text == "" || Rpass.Text == "" || Rgender.Text == "")
                {
                    MessageBox.Show(" Missing Data !!! ");

                }
                else
                {
                    string RName = Rname.Text;
                    string RGender = Rgender.SelectedItem.ToString();
                    string RPhone = Rphone.Text;
                    string Pass = Rpass.Text;
                    //DateTime CDOB = DateTime.Parse(Rdob.Text);
                    string Query = "update reception set rname = '{0}' ,rgender = '{1}' ,rdob = '{2}' , rphone = '{3}' ,rpass ='{4}' where rid = '{5}' ";
                    Query = string.Format(Query, RName, RGender, Rdob.Value.Date, RPhone, Pass, key);
                    Con.SetData(Query);
                    ShowRecep();
                    MessageBox.Show("Succesfully Updated");
                    reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
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

        private void label13_Click(object sender, EventArgs e)
        {
            Membership ob = new Membership();
            ob.Show();
            this.Hide();
        }
    }
   

}
