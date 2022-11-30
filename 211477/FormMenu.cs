using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _211477.View;

namespace _211477
{
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }


        private void cidadesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmCidade form = new FrmCidade();
            form.Show();
        }

        private void FormMenu_Load_1(object sender, EventArgs e)
        {
            Banco.CriarBanco();
        }

        private void clienteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmCliente form = new FrmCliente();
            form.Show();
        }
    }
}
