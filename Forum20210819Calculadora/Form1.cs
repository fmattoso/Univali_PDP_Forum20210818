using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forum20210819Calculadora
{
    public partial class Form1 : Form
    {
        public static double fOp1, fOp2, fDec;
        public static char iOp;
        public static bool bNum;

        public Form1()
        {
            InitializeComponent();
            btnC_Click(null, null);
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            fOp1 = 0;
            bNum = false;
            fDec = 0;
            txtResultado.Text = "0.";
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            fOp1 = 0;
            fOp2 = 0;
            iOp = '\0';
            bNum = false;
            fDec = 0;
            txtResultado.Text = "0.";
            listBox1.Items.Clear();
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            double valor;
            valor = Convert.ToSingle((sender as Button).Text);
            if (fDec == 0)
            {
                fOp1 = fOp1 * 10 + valor;
            }
            else
            {
                fOp1 = fOp1 + (valor / fDec);
                fDec *= 10;
            }
            bNum = true;
            txtResultado.Text = Convert.ToString(fOp1);
        }

        private void buttonOp_Click(object sender, EventArgs e)
        {
            if (iOp == '\0')
                fOp2 = fOp1;
            else if (bNum)
                buttonSaldo_Click(sender, e);

            iOp = Convert.ToChar((sender as Button).Text);
            fDec = 0;
            fOp1 = 0;
            bNum = false;
        }

        private void buttonSaldo_Click(object sender, EventArgs e)
        {
            string sOperacao;

            switch (iOp)
            {
                case '/':
                    sOperacao = Convert.ToString(fOp2) + " / " + Convert.ToString(fOp1);
                    fOp2 /= fOp1;
                    break;
                case '-':
                    sOperacao = Convert.ToString(fOp2) + " - " + Convert.ToString(fOp1);
                    fOp2 -= fOp1;
                    break;
                case '*':
                    sOperacao = Convert.ToString(fOp2) + " * " + Convert.ToString(fOp1);
                    fOp2 *= fOp1;
                    break;
                default: // '+':
                    sOperacao = Convert.ToString(fOp2) + " + " + Convert.ToString(fOp1);
                    fOp2 += fOp1;
                    break;
            }
            fDec = 0;
            bNum = false;
            txtResultado.Text = Convert.ToString(fOp2);
            listBox1.Items.Add(sOperacao + " = " + Convert.ToString(fOp2));
        }

        private void buttonPto_Click(object sender, EventArgs e)
        {
            if (fDec == 0)
                fDec = 10;
        }

    }
}
