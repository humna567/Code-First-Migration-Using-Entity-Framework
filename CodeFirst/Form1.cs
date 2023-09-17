using CODEFIRST.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CODEFIRST
{
    public partial class Form1 : Form
    {
        int id = 0;
        Employee model = new Employee();
        DatabaseContext db = new DatabaseContext();
        public Form1()
        {
            InitializeComponent();
        }
        void bindGridView()
        {
            dataGridView1.DataSource = db.Employees.ToList<Employee>();
        }



        private void label1_Click(object sender, EventArgs e)
        {


        }

        void ResetControls()
        {
            NAMEtextBox.Clear();
            GENDERcomboBox.SelectedItem = null;
            AGEtextBox.Clear();
            DESIGtextBox.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            model.Name = NAMEtextBox.Text;
            model.Gender = GENDERcomboBox.SelectedItem.ToString();
            model.Age = Convert.ToInt32( AGEtextBox.Text);
            model.Designation= DESIGtextBox.Text;
            db.Employees.Add(model);
          int a =  db.SaveChanges();
            if(a>0)
            {
                MessageBox.Show("Data Inserted!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Not Inserted!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            bindGridView();

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = Convert.ToInt32 ( dataGridView1.SelectedRows[0].Cells[0].Value);
            model = db.Employees.Where( x => x.Id == id ).FirstOrDefault(); // where keyword is of linq , we use keyword here , // x is refering our model //lambda exp 
            NAMEtextBox.Text = model.Name;
            GENDERcomboBox.SelectedItem = model.Gender;
            AGEtextBox.Text = model.Age.ToString();
            DESIGtextBox.Text = model.Designation;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            model.Id = id;
            model.Name = NAMEtextBox.Text;
            model.Gender = GENDERcomboBox.SelectedItem.ToString();
            model.Age= Convert .ToInt32( AGEtextBox.Text);
            model.Designation = DESIGtextBox.Text;

            db.Entry(model).State = EntityState.Modified; // entity state property (modified)

            int a = db.SaveChanges();
            if (a > 0)
            {
                MessageBox.Show("Data Updated!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bindGridView();
                ResetControls();
            }
            else
            {
                MessageBox.Show("Data Not Updated!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete data? ", "Alert" , MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if ( dr == DialogResult.Yes)
            {
                model = db.Employees.Where(x => x.Id == id).FirstOrDefault();
                db.Entry(model).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    MessageBox.Show("Data Deleted!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bindGridView();
                    ResetControls();
                }
                else
                {
                    MessageBox.Show("Data Not Deleted!!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            else
            {
                MessageBox.Show("You have Cancelled the deleted operation.");   
            }
        }
    }
}
