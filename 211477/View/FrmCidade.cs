using _211477.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.Windows.Forms;

namespace _211477.View
{
    public partial class FrmCidade : Form
    {
        public Cidade c;
        public FrmCidade()
        {
            InitializeComponent();
        }
        void limpaControles()
        {
            txtID.Clear();
            txtNome.Clear();
            txtPesquisa.Clear();
            txtUF.Clear();
        }

        void carregarGrid(string pesquisa)
        {
            c = new Cidade()
            {
                Nome = pesquisa,
            };
            dgvCidades.DataSource = c.Consultar();
        }

        private void FrmCidade_Load(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty) return;

            c = new Cidade()
            {
                Nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Incluir();
            limpaControles();
            carregarGrid("");
        }

        private void DgvCidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCidades.RowCount > 0)
            {
                txtID.Text = dgvCidades.CurrentRow.Cells["id"].Value.ToString();
                txtNome.Text = dgvCidades.CurrentRow.Cells["nome"].Value.ToString();
                txtUF.Text = dgvCidades.CurrentRow.Cells["UF"].Value.ToString();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtID.Text == String.Empty) return;

            c = new Cidade()
            {
                ID = int.Parse(txtID.Text),
                Nome = txtNome.Text,
                uf = txtUF.Text
            };
            c.Alterar();
            limpaControles();
            carregarGrid("");
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")return;
            if (MessageBox.Show("Deseja excluir a cidade?","Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                c = new Cidade()
                {
                    ID = int.Parse(txtID.Text)
                };
                c.Excluir();
                limpaControles();
                carregarGrid("");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpaControles();
            carregarGrid("");
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            carregarGrid(txtPesquisa.Text);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();    
        }
    }
}
