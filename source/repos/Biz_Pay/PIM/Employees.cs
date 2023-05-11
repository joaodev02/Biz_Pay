using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using PIM.Database;

namespace PIM
{
    public partial class Employees : Form
    {

        private int selectedEmployeeID = 0;
        private string selectedEmployeeStatus = null;

        public Employees()
        {
            InitializeComponent();

            tableEmployees.View = View.Details;
            tableEmployees.LabelEdit = true;
            tableEmployees.AllowColumnReorder = true;
            tableEmployees.FullRowSelect = true;
            tableEmployees.GridLines = true;

            tableEmployees.Columns.Add("ID", 30, HorizontalAlignment.Left);
            tableEmployees.Columns.Add("Nome", 150, HorizontalAlignment.Left);
            tableEmployees.Columns.Add("Cargo", 150, HorizontalAlignment.Left);
            tableEmployees.Columns.Add("CPF", 120, HorizontalAlignment.Left);
            tableEmployees.Columns.Add("E-mail", 200, HorizontalAlignment.Left);
            tableEmployees.Columns.Add("Celular", 100, HorizontalAlignment.Left);
            tableEmployees.Columns.Add("Permissão", 80, HorizontalAlignment.Left);
            tableEmployees.Columns.Add("Status", 80, HorizontalAlignment.Left);

            clearFilters();
        }

        private void getAllEmployees()
        {
           try
            {
                clearTable();

                    List<string> filters = new List<string>();

                    if (inputFilterName.Text.Trim() != "Filtrar por nome..." && inputFilterName.Text.Trim() != "")
                    {
                        filters.Add($"f.nome LIKE '%{inputFilterName.Text}%'");
                    }

                    if ( selectFilterRole.SelectedIndex != 0)
                    {
                       filters.Add($"c.nome = '{selectFilterRole.SelectedItem}'");
                    }

                    if (selectFilterPermition.SelectedIndex != 0)
                    {
                        filters.Add($"p.nome = '{selectFilterPermition.SelectedItem}'");
                    }

                    if(selectFilterStatus.SelectedIndex != 0)
                    {
                        filters.Add($"f.situacao = '{selectFilterStatus.SelectedItem}'");
                    }

                string commandSql = "SELECT f.*, c.nome cargo, p.nome permissao FROM funcionario f INNER JOIN cargo c ON f.idCargo = c.id inner join permissao p on f.idPermissao = p.id";

                if (filters.Count > 0)
                {
                    commandSql += $" WHERE {string.Join(" AND ", filters)}";
                }

                MySqlDataReader reader = PIM.Database.Connection.connectDB($"{commandSql} ORDER BY f.nome ASC;");

                while(reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),// ID
                        reader.GetString(3),// Nome
                        reader.GetString(9),// Nome Cargo
                        reader.GetString(6),// CPF
                        reader.GetString(4),// Email
                        reader.GetString(5),// Telefone
                        reader.GetString(10),// Nome Permissao
                        reader.GetString(8),// Situacao
                    };

                    tableEmployees.Items.Add(new ListViewItem(row));
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PIM.Database.Connection.closeConnetionDB();
            }
        }

        private void updateStatus()
        {
           try
            {
                string commandSql = "";

                if (selectedEmployeeID != 0)
                {
                    if (toolStripMenuItem1.Text == "Ativar")
                    {
                         commandSql = $"UPDATE funcionario SET situacao = 'Ativo' WHERE id = {selectedEmployeeID};";
                    }

                    if (toolStripMenuItem1.Text == "Desativar")
                    {
                        commandSql = $"UPDATE funcionario SET situacao = 'Inativo' WHERE id = {selectedEmployeeID};";
                    }
                }

                 DialogResult confirmation = MessageBox.Show($"Tem certeza que quer {toolStripMenuItem1.Text.ToLower()} funcionario?", "Tornar funcionario inativo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);


                if (confirmation == DialogResult.Yes)
                {
                    MySqlDataReader reader = PIM.Database.Connection.connectDB(commandSql);
                }
               
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                PIM.Database.Connection.closeConnetionDB();
            }
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            getAllEmployees();
        }

        private void inputFilterName_Focus(object sender, EventArgs e)
        {
            if(inputFilterName.Text == "Filtrar por nome...")
            {
                inputFilterName.Text = "";
                inputFilterName.ForeColor = Color.Black;
            }
        }

        private void inputFilterName_RemoveFocus(object sender, EventArgs e)
        {
            if (inputFilterName.Text.Trim() == "")
            {
                inputFilterName.Text = "Filtrar por nome...";
                inputFilterName.ForeColor = Color.LightGray;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            clearTable();
            getAllEmployees();
        }

        private void clearTable ()
        {
            tableEmployees.Items.Clear();
        }

        private void clearFilters()
        {
            inputFilterName.Text = "Filtrar por nome...";
            inputFilterName.ForeColor = Color.LightGray;
            selectFilterPermition.SelectedIndex = 0;
            selectFilterRole.SelectedIndex = 0;
            selectFilterStatus.SelectedIndex = 0;
        }
        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            clearFilters();
            getAllEmployees();
        }

        private void tableEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedItems = tableEmployees.SelectedItems;

            foreach (ListViewItem item in selectedItems)
            {
                selectedEmployeeID = Convert.ToInt32(item.SubItems[0].Text);
                selectedEmployeeStatus = item.SubItems[7].Text;
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            updateStatus();
            getAllEmployees();
            clearFilters();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            PIM.Utils.ContextHome._Home.FormShow(new EditEmployees(selectedEmployeeID));
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
           
            if (selectedEmployeeStatus == "Ativo")
             {
                 toolStripMenuItem1.Text = "Desativar";
             }

             if (selectedEmployeeStatus == "Inativo")
             {
                 toolStripMenuItem1.Text = "Ativar";
             }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            PIM.Utils.ContextHome._Home.FormShow(new Paycheck(selectedEmployeeID));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void inputLoginPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Clique com o botão direito do mouse sobre o funcionário e selecione a operação desejada!", "Ajuda?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
