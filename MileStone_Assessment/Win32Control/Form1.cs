using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Win32Control
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeListView();
        }

        // Initialize the ListView control
        private void InitializeListView()
        {
            // Set up the ListView properties
            listView.Items.Clear();
            listView.View = View.List; // Set the view to show items as a list
            listView.FullRowSelect = true; // Allow selecting a full row

            // Adding some sample items to the ListView initially
            listView.Items.Add("Item 1");
            listView.Items.Add("Item 2");
            listView.Items.Add("Item 3");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newItem = txtItem.Text.Trim();
            if (!string.IsNullOrEmpty(newItem))
            {
                listView.Items.Add(newItem);
                txtItem.Clear();  // Clear the text box after adding the item
            }
            else
            {
                MessageBox.Show("Please enter a valid item name.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listView.SelectedItems.Count > 0)  // Check if an item is selected
            {
                listView.Items.Remove(listView.SelectedItems[0]);
            }
            else
            {
                MessageBox.Show("Please select an item to remove.", "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}