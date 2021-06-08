using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBCrud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            using (FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {

                var updateUser = new PrimaryUser();
                updateUser.UserID = Int32.Parse(txtBxUserID.Text);
                updateUser.State = txtBxState.Text;
                updateUser.City = txtBxCity.Text;
                updateUser.Zip = Int32.Parse(txtBxZip.Text);

                _dbContext.Entry(updateUser).State = System.Data.Entity.EntityState.Modified;
                _dbContext.SaveChanges();
                MessageBox.Show("Successfully Updated User.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {
                if (Validation())
                {
                    var newUser = new PrimaryUser();
                    newUser.UserID = Int32.Parse(txtBxUserID.Text);
                    newUser.State = txtBxState.Text;
                    newUser.City = txtBxCity.Text;
                    newUser.Zip = Int32.Parse(txtBxZip.Text);

                    _dbContext.PrimaryUsers.Add(newUser);
                    _dbContext.SaveChanges();
                    MessageBox.Show("New User Saved.");

                }

                else
                {
                    MessageBox.Show("User ID field must be populated.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            using(FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {
                int U = int.Parse(txtBxUserID.Text);
                var delUser = _dbContext.PrimaryUsers.First(x => x.UserID == U);


                _dbContext.PrimaryUsers.Remove(delUser);
                _dbContext.SaveChanges();
                MessageBox.Show("User Successfully Deleted.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using(FirstDatabaseEntities _dbContext = new FirstDatabaseEntities())
            {

                int U = int.Parse(txtBxUserID.Text);
                var searchUser = _dbContext.PrimaryUsers.First(x => x.UserID == U);

                txtBxUserID.Text = searchUser.UserID.ToString();
                txtBxCity.Text = searchUser.City;
                txtBxState.Text = searchUser.State;
                txtBxZip.Text = searchUser.Zip.ToString();

                MessageBox.Show("User Found.");

            }
        }


        public bool Validation()
        {

            if (string.IsNullOrWhiteSpace(txtBxUserID.Text))
            {

                return false;

            }

            return true;
            

        }
    }
}
