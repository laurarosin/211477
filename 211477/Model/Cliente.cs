using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using _211477.Model;

namespace _211477.Model
{
    public class Cliente
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public int idCidade { get; set; }

        public DateTime dataNasc { get; set; }

        public double renda { get; set; }

        public string cpf { get; set; }

        public string foto { get; set; }

        public bool venda { get; set; }

        public void Incluir()
        {
            try
            {

                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand
                    ("INSERT INTO clientes (nome, idCidade, dataNasc, renda, cpf, foto, venda) " +
                    "VALUES (@nome, @idCidade, @dataNasc, @renda, @cpf, @foto, @venda)", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
                Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                Banco.Comando.Parameters.AddWithValue("@renda", renda);
                Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                Banco.Comando.Parameters.AddWithValue("@foto", foto);
                Banco.Comando.Parameters.AddWithValue("@venda", venda);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            public void Alterar()
            {
                try
                {
                    Banco.Conexao.Open();
                    Banco.Comando = new MySqlCommand
                        ("UPDATE clientes SET nome  = @nome, @idCidade = @idCidade, dataNasc = @dataNasc," +
                        "renda = @renda, cpf = @cpf, foto = @foto, venda = @venda where id = @id", Banco.Conexao);
                    Banco.Comando.Parameters.AddWithValue("@nome", Nome);
                    Banco.Comando.Parameters.AddWithValue("@idCidade", idCidade);
                    Banco.Comando.Parameters.AddWithValue("@dataNasc", dataNasc);
                    Banco.Comando.Parameters.AddWithValue("@renda", renda);
                    Banco.Comando.Parameters.AddWithValue("@cpf", cpf);
                    Banco.Comando.Parameters.AddWithValue("@foto", foto);
                    Banco.Comando.Parameters.AddWithValue("@venda", venda);
                    Banco.Comando.Parameters.AddWithValue("@ID", ID);
                    Banco.Comando.ExecuteNonQuery();
                    Banco.Conexao.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        public void Excluir()
        {
            try
            {
                Banco.Conexao.Open();
                Banco.Comando = new MySqlCommand("delete from clientes where id = @id", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@id", ID);
                Banco.Comando.ExecuteNonQuery();
                Banco.Conexao.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public DataTable Consultar()
        {
            try
            {
                Banco.Comando = new MySqlCommand("SELECT cl.*, ci.nome cidade, " +
                   "ci.uf FROM Clientes cl inner join Cidades ci on (ci.id = cl.idCidade) " +
                   "where cl.nome like ?Nome order by cl.nome", Banco.Conexao);
                Banco.Comando.Parameters.AddWithValue("@Nome", Nome + "%");
                Banco.Adaptador = new MySqlDataAdapter(Banco.Comando);
                Banco.datTabela = new DataTable();
                Banco.Adaptador.Fill(Banco.datTabela);
                return Banco.datTabela;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        




    }
    }
          
       

    
