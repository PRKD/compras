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
    public partial class frmComprArticulo : Form
    {
        public frmComprArticulo()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public string empresa { get; set; }
        public string fecha1 { get; set; }
        public string fecha2 { get; set; }
        public string Articulo { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {

            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    empresa = "1";
                    break;
                case 1:
                    empresa = "2";
                    break;

            }
            if (dateTimePicker1.Text.Length == 10)
            {

                fecha1 = this.dateTimePicker1.Text;

            }
            if (dateTimePicker2.Text.Length == 10)
            {

                fecha2 = this.dateTimePicker2.Text;

            }
            Articulo = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
