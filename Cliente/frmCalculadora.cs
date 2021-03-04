using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cliente
{
    public partial class frmCalculadora : Form
    {
        public frmCalculadora()
        {
            InitializeComponent();
        }

        private bool presionado = false;
        private int posicionMouseX = 0;
        private int posicionMousey = 0;

        //
        // Comportamiento de la Tittle Bar
        //
        private void titleBar_MouseDown(object sender, MouseEventArgs e)
        {
            this.presionado = true;
            posicionMouseX = e.X;
            posicionMousey = e.Y;
        }

        private void titleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.presionado)
            {
                this.SetDesktopLocation(
                    MousePosition.X - posicionMouseX,
                    MousePosition.Y - posicionMousey);
            }
        }

        private void titleBar_MouseUp(object sender, MouseEventArgs e)
        {
            this.presionado = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExpandir_Click(object sender, EventArgs e)
        {
            DialogResult value;
            value = MessageBox.Show("Si expandes esta ventana se desbaratara " +
                                    "todo puesto que no se trata de un formulario " +
                                    "responsivo!",
                                    "Warnig message!", 
                                     MessageBoxButtons.YesNo, 
                                     MessageBoxIcon.Warning);

            if (value == DialogResult.Yes)
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            { 
                numero = Convert.ToDouble(txtBigDisplay.Text + "3");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "2");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "1");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "0");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "4");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "5");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "6");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "7");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "8");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            double numero;
            if (txtBigDisplay.Text.Length < 9)
            {
                numero = Convert.ToDouble(txtBigDisplay.Text + "9");
                txtBigDisplay.Text = numero.ToString();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string contenido = txtBigDisplay.Text;
            StringBuilder result = new StringBuilder();
            
            for (var i = 0; i < contenido.Length - 1; i++)
            {
                result.Append(contenido[i]);
            }

            if (result.Length > 0)
            {
                txtBigDisplay.Text = result.ToString();
            }
            else
            {
                txtBigDisplay.Text = "0";
            }
        }
    }
}
