using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace _2_14fi_class_with_minimal_responsiveness
{
    public partial class Form1 : Form
    {
        public static ObservableCollection<ChristmasPresent> AllChristmasPresent = new ObservableCollection<ChristmasPresent>();
        public Form1()
        {
            InitializeComponent();
            Start();
        }
        void Start() {
            button1.Click += AddEvent;
            AllChristmasPresent.CollectionChanged += RestockEvent;
        }
        void RestockEvent(Object s, EventArgs e) {
            int num = 0;
            foreach (ChristmasPresent item in AllChristmasPresent)
            {
                item.Top = num * item.Height + 15;
                num++;
            }
        }
        void AddEvent(Object s, EventArgs e) {
            if (textBox1.Text.Length > 1 && textBox2.Text.Length > 1)
            {
                try
                {
                    ChristmasPresent onePresent = new ChristmasPresent(textBox1.Text, int.Parse(textBox2.Text));
                    //onePresent.Top = 15 + AllChristmasPresent.Count * onePresent.Height;
                    AllChristmasPresent.Add(onePresent);
                    groupBox1.Controls.Add(onePresent);
                    textBox1.Clear();
                    textBox2.Clear();
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
            else
            {
                MessageBox.Show("There is no data in the textboxes");
            }
            
        }
    }
}
