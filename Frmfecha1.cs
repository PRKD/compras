using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Costes_Logisticos_Quality
{
    public partial class Fecha : Form
    {
        public Fecha()
        {
            InitializeComponent();
            fecha1 = "";
            fecha2 = "";
        }
        public string fecha1 { get; set; }
        public string fecha2 { get; set; }
 

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Text.Length == 10)
            {

                fecha1 = this.dateTimePicker1.Text;

            }
            if (dateTimePicker2.Text.Length == 10)
            {

                fecha2 = this.dateTimePicker2.Text;

            }
            if ((fecha1.Length > 0) && (fecha2.Length > 0))
            this.DialogResult = DialogResult.OK;
        }
    }
}
