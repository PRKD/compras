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
    public partial class FrmAgencia : Form
    {
        public FrmAgencia()
        {
            InitializeComponent();
            
        }
        public string agencia { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    agencia = "101";
                    break;
                case 1:
                    agencia = "102";
                    break;
                case 2:
                    agencia = "105";
                    break;
                case 3:
                    agencia = "106";
                    break;
                case 4:
                    agencia = "109";
                    break;
                case 5:
                    agencia = "112";
                    break;
                case 6:
                    agencia = "113";
                    break;
                case 7:
                    agencia = "115";
                    break;
                case 8:
                    agencia = "118";
                    break;
                case 9:
                    agencia = "122";
                    break;
                case 10:
                    agencia = "123";
                    break;
                case 11:
                    agencia = "124";
                    break;
                case 12:
                    agencia = "125";
                    break;
                case 13:
                    agencia = "126";
                    break;
                case 14:
                    agencia = "127";
                    break;
            }
        }
    }
}
