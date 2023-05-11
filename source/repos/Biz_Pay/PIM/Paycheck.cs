using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using PIM.Database;
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
    public partial class Paycheck : Form
    {

        private int employeeID;
        private decimal grossSalary;
        private decimal netSalary;
        private decimal aliquot;
        private decimal weekHours;
        private decimal hourPay;
        private decimal overtime = 0;
        private decimal discountINSS;
        private decimal discountAbsences;
        private decimal discountIRRF;
        private int absences = 0;
        private DateTime lastPaycheck;

        public Paycheck(int employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;

            getInfoEmployee();
            calculateAllInfo();
            absencesValue.Text = absences.ToString();
            overtimeValue.Text = overtime.ToString();
            discountINSSValue.Text = discountINSS.ToString("F2");
            discountAbsencesValue.Text = discountAbsences.ToString("F2");
            netSalaryValue.Text = netSalary.ToString("F2");
            grossSalaryValue.Text = grossSalary.ToString("F2");
            discountIRRFValue.Text = discountIRRF.ToString("F2");
        }

        private void getInfoEmployee()
        {
            try
            {
                string commandSql = $"SELECT f.nome, c.nome as cargo, c.horasSemanais, c.valorHora FROM holerite_pim.funcionario f INNER JOIN cargo c ON f.idCargo = c.id where f.id = {employeeID};";
                MySqlDataReader reader = PIM.Database.Connection.connectDB(commandSql);

                while (reader.Read())
                {
                    nameValue.Text = reader.GetString(0);
                    roleValue.Text = reader.GetString(1);
                    weeHourValue.Text = Convert.ToString(reader.GetInt32(2));
                    payHourValue.Text = Convert.ToString(reader.GetDecimal(3));
                    hourPay = reader.GetDecimal(3);
                    weekHours = reader.GetInt32(2);
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

        private bool checkDateLastPaycheck ()
        {
            bool result = true;

            try 
            {
                string commandSql = $"select * from holerite_pim.holerite where idFuncionario = {employeeID} ORDER BY dtHolerite DESC limit 1;";
                MySqlDataReader reader =  PIM.Database.Connection.connectDB(commandSql);
                DateTime date = DateTime.Now;

                if (reader.Read())
                {
                    lastPaycheck = reader.GetDateTime(2);

                    if (date.Month == reader.GetDateTime(2).Month && date.Year == reader.GetDateTime(2).Year)
                    {
                        result = false;
                    } 
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

            return result;
        }

        private void calculateGrossSalary()
        {
            discountAbsences = (absences * weekHours / 5) * hourPay;
            this.grossSalary = ((weekHours * 4 + overtime) - (absences * weekHours / 5)) * hourPay;
        }

        public void calculateDiscount(decimal grossSalary)
        {
            // Tabela do INSS para 2023
            decimal[] inssTabela = { 1100.00m, 2203.48m, 3305.22m, 6433.57m };
            decimal[] inssAliquotas = { 0.075m, 0.09m, 0.12m, 0.14m };

            // Tabela do IRRF para 2023
            decimal[] irrfTabela = { 1903.98m, 2826.65m, 3751.05m, 4664.68m, 5574.84m };
            decimal[] irrfAliquotas = { 0.075m, 0.15m, 0.225m, 0.275m, 0.3m };
            decimal[] irrfDeduzir = { 142.80m, 354.80m, 636.13m, 869.36m, 1143.08m };

            // Calcula o valor do INSS
            decimal valorInss = 0.0m;
            for (int i = inssTabela.Length - 1; i >= 0; i--)
            {
                if (grossSalary >= inssTabela[i])
                {
                    valorInss = (grossSalary - inssTabela[i]) * inssAliquotas[i];
                    for (int j = i - 1; j >= 0; j--)
                    {
                        valorInss += (inssTabela[j + 1] - inssTabela[j]) * inssAliquotas[j];
                    }
                    break;
                }
            }

            // Calcula o valor do IRRF
            decimal valorIrrf = 0.0m;
            decimal salarioBase = grossSalary - valorInss;
            for (int i = irrfTabela.Length - 1; i >= 0; i--)
            {
                if (salarioBase >= irrfTabela[i])
                {
                    valorIrrf = (salarioBase * irrfAliquotas[i]) - irrfDeduzir[i];
                    break;
                }
            }

            // Calcula o valor do salário líquido
            this.netSalary = grossSalary - valorInss - valorIrrf;

            // Retorna os valores dos descontos
            this.discountINSS = valorInss;
            this.discountIRRF = valorIrrf;
        }

        private void calculateAllInfo()
        {
            calculateGrossSalary();
            calculateDiscount(grossSalary);
            refreshAllFields();
        }

        private void refreshAllFields()
        {
            absencesValue.Text = absences.ToString();
            overtimeValue.Text = overtime.ToString("F2");
            discountINSSValue.Text = discountINSS.ToString("F2");
            discountAbsencesValue.Text = discountAbsences.ToString("F2");
            grossSalaryValue.Text = grossSalary.ToString("F2");
            netSalaryValue.Text = netSalary.ToString("F2");
            discountIRRFValue.Text = discountIRRF.ToString("F2");
        }


        private void inputOvertime_TextChanged(object sender, EventArgs e)
        {
           if (inputOvertime.Text.Trim() == "")
            {
                overtime = 0;
            }
            else
            {
                overtime = Convert.ToDecimal(inputOvertime.Text);
            }
            calculateAllInfo();
        }

        private void inputAbsences_TextChanged(object sender, EventArgs e)
        {
            if (inputAbsences.Text.Trim() == "")
            {
                absences = 0;
            }
            else
            {
                absences = Convert.ToInt16(inputAbsences.Text);
            }
            calculateAllInfo();
        }

        private void inputOvertime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void inputAbsences_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void createPaycheck()
        {
            if (checkDateLastPaycheck()) {
                try
                {

                MySqlConnection connection = new MySqlConnection(Database.Connection.stringConnection);
                 connection.Open();

                string sql = "INSERT INTO holerite (idFuncionario, salarioLiquido, salarioBruto, descontoInss, descontoFaltas, horasExtras, faltas, descontoIRRF) VALUES (@idFuncionario, @salarioLiquido, @salarioBruto, @descontoInss, @descontoFaltas, @horasExtras, @faltas, @descontoIRRF);";
                MySqlCommand command = new MySqlCommand(sql, connection);

                command.Parameters.Add("@idFuncionario", MySqlDbType.Int32).Value = employeeID;
                command.Parameters.Add("@horasExtras", MySqlDbType.Decimal).Value = overtime;
                command.Parameters.Add("@salarioLiquido", MySqlDbType.Decimal).Value = netSalary;
                command.Parameters.Add("@salarioBruto", MySqlDbType.Decimal).Value = grossSalary;
                command.Parameters.Add("@descontoInss", MySqlDbType.Decimal).Value = discountINSS;
                command.Parameters.Add("@descontoFaltas", MySqlDbType.Decimal).Value = discountAbsences;
                command.Parameters.Add("@faltas", MySqlDbType.Int32).Value = absences;
                command.Parameters.Add("@descontoIRRF", MySqlDbType.Int32).Value = discountIRRF;


                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Holerite gerado com sucesso!");
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

            } else
            {
                MessageBox.Show($"Não é possivel gerar dois holerites no mesmo mês. Data do ultimo holerite: {lastPaycheck}");
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            createPaycheck();
        }

        private void inputOvertime_KeyPress_1(object sender, KeyPressEventArgs e)
        {

        }
    }
}
