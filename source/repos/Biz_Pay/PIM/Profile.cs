using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();

            tablePaycheck.View = View.Details;
            tablePaycheck.LabelEdit = true;
            tablePaycheck.AllowColumnReorder = true;
            tablePaycheck.FullRowSelect = true;
            tablePaycheck.GridLines = true;

            tablePaycheck.Columns.Add("ID", 30, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Data", 90, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Horas Extras", 100, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Faltas", 60, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Desconto Faltas", 120, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Desconto INSS", 110, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Desconto IRRF", 110, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Valor Bruto", 100, HorizontalAlignment.Left);
            tablePaycheck.Columns.Add("Valor Liquido", 100, HorizontalAlignment.Left);

            clearFilters();
        }

        private void Profile_Load(object sender, EventArgs e)
        {
            nameValue.Text = Database.User.Name.ToString();
            cpfValue.Text = Database.User.Cpf.ToString();
            emailValue.Text = Database.User.Email.ToString();
            phoneValue.Text = Database.User.Phone.ToString();
            roleValue.Text = Database.User.NameRole.ToString();
            permitionValue.Text = Database.User.Permition.ToString();
            getAllPaycheck();
        }

        private void getAllPaycheck()
        {
            try
            {
                clearTable();

                List<string> filters = new List<string>();

                if (selectDate.SelectedIndex != 0)
                {
                    switch (selectDate.SelectedIndex)
                    {
                        case 1:
                            filters.Add($"dtHolerite DESC");
                            break;
                        case 2:
                            filters.Add($"dtHolerite ASC");
                            break;
                        default:
                            filters.Add($"dtHolerite DESC");
                            break;
                    }
                }


                if (selectSalary.SelectedIndex != 0)
                {
                    switch (selectSalary.SelectedIndex)
                    {
                        case 1:
                            filters.Add($"salarioLiquido DESC");
                            break;
                        case 2:
                            filters.Add($"salarioLiquido ASC");
                            break;
                        default:
                            filters.Add($"salarioLiquido DESC");
                            break;
                    }
                }


                string commandSql = $"SELECT * FROM holerite WHERE idFuncionario = {Database.User.Id}";

                if (filters.Count > 0)
                {
                    commandSql += $" ORDER BY {string.Join(" , ", filters)}";
                }

                MySqlDataReader reader = Database.Connection.connectDB($"{commandSql};");

                while (reader.Read())
                {
                    string[] row =
                    {
                        reader.GetString(0),// ID
                        reader.GetDateTime(2).ToString("dd/MM/yyyy"),// Data
                        reader.GetString(3),// Horas Extras
                        reader.GetString(8),// faltas
                        reader.GetString(7),// deconto faltas
                        reader.GetString(6),// desconto INSS
                        reader.GetString(9),// desconto IRRF
                        reader.GetString(5),// Salario bruto
                        reader.GetString(4),// Salario liquido
                    };

                    tablePaycheck.Items.Add(new ListViewItem(row));
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            clearTable();
            getAllPaycheck();
        }

        private void clearFilters()
        {
            selectDate.SelectedIndex = 0;
            selectSalary.SelectedIndex = 0;
        }

        private void clearTable()
        {
            tablePaycheck.Items.Clear();
        }

        private void selectDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectDate.SelectedIndex != 0)
            {
                selectSalary.SelectedIndex = 0;
            }
        }

        private void selectSalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectSalary.SelectedIndex != 0)
            {
                selectDate.SelectedIndex = 0;
            }
        }
    }
}
