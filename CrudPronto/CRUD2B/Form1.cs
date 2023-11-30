using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUD2B.Model;
using CRUD2B.BLL;

namespace CRUD2B
{
    public partial class Form1 : Form
    {
      public Form1()
      {
            InitializeComponent();
      } 
        

        //Método para salvar
        private void Salvar (Pessoa pessoa)
        {
            PessoaBLL pessoaBLL = new PessoaBLL();

            if  (txtNome.Text.Trim() == String.Empty || txtNome.Text.Trim().Length < 3)
            {
                MessageBox.Show("O campo NOME não pode ser vazio!", "Alerta",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.BackColor = Color.LightCoral;
                mtbCPF.BackColor = Color.White;
                cbSexo.BackColor = Color.White;
            }
            else if (!mtbCPF.MaskCompleted)
            {
                MessageBox.Show("O campo CPF não pode ser vazio!", "Alerta",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                mtbCPF.BackColor = Color.LightCoral;
                txtNome.BackColor = Color.White;
                cbSexo.BackColor= Color.White;
            }
            else if (cbSexo.Text == String.Empty)
            {
                MessageBox.Show("O campo Sexo não pode ser vazio!", "Alerta",
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbSexo.BackColor = Color.LightCoral;
                txtNome.BackColor = Color.White;
                mtbCPF.BackColor = Color.White;
            }
            else
            {
                pessoa.Nome = txtNome.Text;
                pessoa.Nascimento = dtDataNasc.Text;
                pessoa.Sexo = char.Parse(cbSexo.Text);
                mtbCPF.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                pessoa.Cpf = mtbCPF.Text;
                mtbCelular.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                pessoa.Celular = mtbCelular.Text;
                pessoa.Endereco = txtEndereco.Text;
                pessoa.Bairro = txtBairro.Text;
                pessoa.Cidade = txtCidade.Text;
                pessoa.Estado = cbUF.Text;
                mtbCEP.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                pessoa.Cep = mtbCEP.Text;

                pessoaBLL.Salvar(pessoa);
                MessageBox.Show("Cadastro realizado com sucesso!", "Aviso",
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Limpar();
            }
        }      

        //Método para limpar os campos do formulário

        public void Limpar()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            mtbCPF.Clear();
            mtbCEP.Clear();
            mtbCelular.Clear();
            cbSexo.SelectedItem = -1;
            cbUF.SelectedItem = -1;
            dtDataNasc.ResetText();
            txtNome.BackColor = Color.White;
            mtbCPF.BackColor = Color.White;
            cbSexo.BackColor = Color.White;
        }
        //Métodos para exibir os dados na tela
        private void Listar()
        {
            PessoaBLL pessoaBLL = new PessoaBLL();
            dataGridView1.DataSource = pessoaBLL.Listar();

            //Renomear os cabeçalhos das colunas
            dataGridView1.Columns[0].HeaderText = "Código";
            dataGridView1.Columns[1].HeaderText = "Nome";
            dataGridView1.Columns[2].HeaderText = "Dt Nasc";
            dataGridView1.Columns[3].HeaderText = "Sexo";
            dataGridView1.Columns[4].HeaderText = "CPF";
            dataGridView1.Columns[5].HeaderText = "Celular";

            //Ajustar largura das colunas
            dataGridView1.Columns[0].Width = 50;
            dataGridView1.Columns[1].Width = 243;
            dataGridView1.Columns[2].Width = 75;
            dataGridView1.Columns[3].Width = 45;
            dataGridView1.Columns[4].Width = 85;
            dataGridView1.Columns[5].Width = 80;

            //Remover Colunas
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.Columns[10].Visible = false;
        }

        //Métodos dos botões do formulário
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            Salvar(pessoa);
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            Limpar();
            Listar();
        }
    }
}