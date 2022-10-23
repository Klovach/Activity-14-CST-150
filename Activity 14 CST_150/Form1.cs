using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Activity_14_CST_150
{
    public partial class Form1 : Form
    {
        DataTable table;
        public Form1()
        {
            InitializeComponent();
        }


        /* Here, upon loading the foam, we add a new DataTable.
         We add two columns to that table, a title column and a messages column.
        For visual purposes, we hide the messages column and make the width of the
        title column equal to the data grid's width.*/
        private void Form1_Load_1(object sender, EventArgs e)
        {
            table = new DataTable();
            table.Columns.Add("Title", typeof(String));
            table.Columns.Add("Messages", typeof(String));

            DataGridView.DataSource = table;

            DataGridView.Columns["Messages"].Visible = false;
            DataGridView.Columns["Title"].Width = DataGridView.Width;
        }

        // Here we let the user create a new document by clearing the screen of any text.
        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtMessage.Clear();
            MessageBox.Show("You made a new document.");
        }

        /* Here we add our title text and message text to our rows in our datagrid table.
         Then we clear the application of any text.*/
        private void btnSave_Click(object sender, EventArgs e)
        {
            table.Rows.Add(txtTitle.Text, txtMessage.Text);
            txtTitle.Clear();
            txtMessage.Clear();
        }

        /* Here we let the user read the file. This is accomplished by getting
         data from the table rows and replacing the blank text on the screen with the
        text in our saved notes.*/
        private void btnRead_Click(object sender, EventArgs e)
        {
            int index = DataGridView.CurrentCell.RowIndex;

            if (index > -1)
            {
                txtTitle.Text = table.Rows[index].ItemArray[0].ToString();
                txtMessage.Text = table.Rows[index].ItemArray[1].ToString();

            }
        }

        /* Here we delete a cell from the datagrid.*/
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = DataGridView.CurrentCell.RowIndex;
            table.Rows[index].Delete();
        }

        // CHANGE FONT STYLE 
        /* This is where we employ check boxes to let the user change the font style.
         In each checkbox_CheckedChanged event, we invoke the UpdateFontStyle() method.*/
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFontStyle();
        }

        /* This is our method for changing the font. By using |=, we enable the user
         to apply multiple font styles to the text. This is important because check boxes
        are intended to let users select more than one option.*/
        private void UpdateFontStyle()
        {
            System.Drawing.FontStyle style = System.Drawing.FontStyle.Regular;
            if (checkBox1.Checked) style |= System.Drawing.FontStyle.Bold;
            if (checkBox2.Checked) style |= System.Drawing.FontStyle.Italic;
            if (checkBox3.Checked) style |= System.Drawing.FontStyle.Underline;
            txtMessage.Font = new Font(txtMessage.Font, style);
            txtTitle.Font = new Font(txtTitle.Font, style);
        }


        /* We employ a simple switch case to let the user choose a font from a list box.*/
        private void fontList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int TextFont;
            TextFont = fontList.SelectedIndex;
            switch (TextFont)
            {
                case 0:
                    Font timesFont = new Font("Times New Roman", 10.0f);
                    txtMessage.Font = timesFont;
                    txtTitle.Font = timesFont; 
                    break;

                case 1:
                    Font arialFont = new Font("Arial", 10.0f);
                    txtMessage.Font = arialFont;
                    txtTitle.Font = arialFont;
                    break;

                case 2:
                    Font palatinoFont = new Font("Palatino Linotype", 10.0f);
                    txtMessage.Font = palatinoFont;
                    txtTitle.Font = palatinoFont;
                    break;

                case 3:
                    Font montserratFont = new Font("Montserrat", 10.0f);
                    txtMessage.Font = montserratFont;
                    txtTitle.Font = montserratFont;
                    break;

                case 4:
                    Font mongolianFont = new Font("Mongolian Baiti", 10.0f);
                    txtMessage.Font = mongolianFont;
                    txtTitle.Font = mongolianFont;
                    break;

                case 5:
                    Font boliFont = new Font("MV Boli", 10.0f);
                    txtMessage.Font = boliFont;
                    txtTitle.Font = boliFont;
                    break;

                case 6:
                    Font defaultFont = new Font("Microsoft Sans Serif", 10.0f);
                    txtMessage.Font = defaultFont;
                    txtTitle.Font = defaultFont; 
                    break;

                default:
                    break;

            }
        }

        /* Here we can change the TextColor. Instead of having an event for every radio button in the
         project, we change what happens in the radio buttons under properties and let them know to
        employ this method when any of them are clicked.*/
            private void ChangeTextColour(object sender, EventArgs e)
            {
                RadioButton tempButton = sender as RadioButton;

                txtMessage.ForeColor = tempButton.ForeColor;
                txtTitle.ForeColor = tempButton.ForeColor;
            }

        // Exit the application. 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
    }
