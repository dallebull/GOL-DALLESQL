using System;
using System.Linq;
using System.Windows.Forms;
using GOL_DALLESQL.BLL;

namespace GOL_DALLESQL
{
    public partial class Form1 : Form
    {
        public string SeedString { get; set; }


        public Form1()
        {
            InitializeComponent();
            Populate();

        }


        private void button1_Click(object sender, EventArgs e)
        {

            HelperClass helper = new HelperClass();
            SeedString = helper.RandomSeed();
            textBox1.Text = SeedString;
        }

        private void FillButton_Click(object sender, EventArgs e)
        {
            string SeedString = textBox1.Text;

            for (int i = 0; i < SeedString.Length; i++)
            {
                bool hit = SeedString.Substring(i, 1).Contains("1");
                if (hit == true)
                {

                    var ctrl = this.Controls.Find("checkbox" + i, true).FirstOrDefault() as CheckBox;
                    if (ctrl != null)
                    {
                        ctrl.Checked = true;
                    }
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var checkBoxes = this.Controls.OfType<CheckBox>();
            foreach (CheckBox cbx in checkBoxes)
            {
                cbx.Checked = false;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SeedString = textBox1.Text;
                GameArray ga = new GameArray {Name = nameBox.Text.ToString(), Seed = SeedString};
                ga.AddToDB(ga);
            }
            catch
            {
                MessageBox.Show("Error Saving");
            }
            Populate();

        }


        void Populate()
        {

            listBox1.ResetText();
            GameArray ga = new GameArray();
            using (Context conn = new Context())
            {
                listBox1.DataSource = conn.GameArrays.ToList();
                listBox1.DisplayMember = "Name";

            }
        }

        private void Delete_Click(object sender, System.EventArgs e)
        {
            GameArray ga = new GameArray();
            var deleteme = listBox1.SelectedItem as GameArray;
           
          
            try
            {
            ga.DeleteFromDb(deleteme);
            }
            catch { MessageBox.Show("Error Removing"); }
            Populate();
        }

        private void Xbutton_Click(object sender, System.EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GameArray ga = new GameArray();
            var thisobject = listBox1.SelectedItem as GameArray;
            textBox1.Text = thisobject.Seed;
            nameBox.Text = thisobject.Name;
        }
    }
}