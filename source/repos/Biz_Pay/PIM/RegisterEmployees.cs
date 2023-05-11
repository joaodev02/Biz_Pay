using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PIM
{
    public partial class RegisterEmployees : Form
    {

        private MySqlConnection _connection;

        public RegisterEmployees()
        {
            InitializeComponent();
        }

        private void createEmployees()
        {
           
            try
            {
                string commandSql = $"INSERT INTO `holerite_pim`.`funcionario` (`idPermissao`, `idCargo`, `nome`, `email`, `celular`, `cpf`, `senha`) VALUES ({selectPermition.SelectedIndex + 1}, {selectRole.SelectedIndex + 1}, '{PIM.Utils.Capitalize.tranformCapitalize(inputName.Text)}', '{inputEmail.Text}', '{inputPhone.Text}', '{inputCpf.Text}', '{inputPass.Text}');";
                MySqlDataReader reader = PIM.Database.Connection.connectDB(commandSql);

                MessageBox.Show("Funcionario cadastrado com sucesso!",
                "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clearFields();
            }
            catch (MySqlException ex)
            {

                if (ex.Number == 1062)
                {
                    MessageBox.Show("Este CPF já está vinculado a um usuário!",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else
                {
                MessageBox.Show("Erro " + ex.Number + " ocorreu: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

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

        private void clearFields()
        {
            inputCpf.Clear();
            inputEmail.Clear();
            inputName.Clear();
            inputPass.Clear();
            inputConfirmPass.Clear();
            inputPhone.Clear();
            selectRole.SelectedItem = null;
            selectPermition.SelectedItem = null;
        }


        private void eye_Click(object sender, EventArgs e)
        {

            eye.Visible = false;
            eyeLock.Visible = true;
            checkVisiblePass();
        }

        private void eyeConfirm_Click(object sender, EventArgs e)
        {

            eyeConfirm.Visible = false;
            eyeLockConfirm.Visible = true;
            checkVisiblePass();
        }

        private void eyeLock_Click(object sender, EventArgs e)
        {
            eyeLock.Visible = false;
            eye.Visible = true;
            checkVisiblePass();
        }

        private void eyeLockConfirm_Click(object sender, EventArgs e)
        {
            eyeLockConfirm.Visible = false;
            eyeConfirm.Visible = true;
            checkVisiblePass();
        }

        private void RegisterEmployees_Load(object sender, EventArgs e)
        {
            eye.Visible = false;
            eyeConfirm.Visible = false;
            checkVisiblePass();
        }

        private void checkVisiblePass()
        {
            if (eye.Visible == false)
            {
                inputPass.PasswordChar = '*';
            }
            else
            {
                inputPass.PasswordChar = '\0';
            }


            if (eyeConfirm.Visible == false)
            {
                inputConfirmPass.PasswordChar = '*';
            }
            else
            {
                inputConfirmPass.PasswordChar = '\0';
            }

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (validateAllFields())
            {
                createEmployees();
            }
        }

        private bool checkConfirmPass()
        {
            if (inputPass.Text.Length >= 8)
            {

                if (inputPass.Text == inputConfirmPass.Text)
                {
                    return true;
                } else
                {
                    MessageBox.Show("As senhas devem ser iguais para confirmação!");
                    return false;
                }

            } else
            {
                MessageBox.Show("A senha deve conter no minimo 8 caracteres!");
                return false;
            }
        }

        private void inputPhone_TextChanged(object sender, EventArgs e)
        {
            this.inputPhone.TextChanged -= new System.EventHandler(this.inputPhone_TextChanged);
            PIM.Utils.Masks.ApplyPhoneFormat(inputPhone);
            this.inputPhone.TextChanged += new System.EventHandler(this.inputPhone_TextChanged);
        }

        private void inputCpf_TextChanged(object sender, EventArgs e)
        {
            this.inputCpf.TextChanged -= new System.EventHandler(this.inputCpf_TextChanged);
            PIM.Utils.Masks.ApplyCPFformat(inputCpf);
            this.inputCpf.TextChanged += new System.EventHandler(this.inputCpf_TextChanged);
        }


        private bool validateAllFields()
        {

            if (
                PIM.Utils.ValidateInput.validateName(inputName.Text) &&
                PIM.Utils.ValidateInput.validatePhone(inputPhone.Text) &&
                PIM.Utils.ValidateInput.validateCpf(inputCpf.Text) &&
                PIM.Utils.ValidateInput.validateEmail(inputEmail.Text) &&
                PIM.Utils.ValidateInput.validadeComboBox(selectPermition, "permissão") &&
                PIM.Utils.ValidateInput.validadeComboBox(selectRole, "cargo") &&
                checkConfirmPass()
                )
            {
                return true;
            }
            return false;
        }
        private void inputPass_Enter(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tooltipPass = new System.Windows.Forms.ToolTip();
            tooltipPass.ToolTipTitle = "Senha";
            tooltipPass.SetToolTip(inputPass, "A senha deve conter\nno minimo 8 caracteres.");
            tooltipPass.Show("A senha deve conter\nno minimo 8 caracteres.", inputPass, 0, -30, 5000);
        }

        private void inputPass_Leave(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip tooltipPass = new System.Windows.Forms.ToolTip();
            tooltipPass.Hide(inputPass);
        }
    }
}
