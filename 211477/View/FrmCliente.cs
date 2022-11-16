using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _211477.Model;

namespace _211477.View
{
    public partial class FrmCliente : Form

    {
        Cidade ci;
        Cliente cl;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            ci = new Cidade();
            cboCidade.DataSource = ci.Consultar();
            cboCidade.DisplayMember = "Nome";
            cboCidade.ValueMember = "id";

            limpaControles();
            carregarGrid("");

            dgvClientes.Columns["idCidade"].Visible = false;
            dgvClientes.Columns["foto"].Visible = false;
        }

        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            cboCidade.SelectedIndex = -1;   
            txtUF.Clear();  
            mskCPF.Clear();
            txtRenda.Clear();
            dtpDataNasc.Value = DateTime.Now;
            picFOTO.ImageLocation = "";
            chkVenda.Checked = false;   
        }

        private void cboCidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCidade.SelectedIndex == -1)
            {
                DataRowView reg = (DataRowView)cboCidade.SelectedItem;
                txtUF.Text = reg["uf"].ToString();
            }
        }

        private void picFOTO_Click(object sender, EventArgs e)
        {
            ofdArquivo.InitialDirectory = "D:/fotos/cliente/";
            ofdArquivo.FileName = "";
            ofdArquivo.ShowDialog();
            picFOTO.ImageLocation = ofdArquivo.FileName;
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == "") return;
            cl = new Cliente(); 
            {
       
            }
        }
    }
}
