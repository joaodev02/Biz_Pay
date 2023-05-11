using MySql.Data.MySqlClient;
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
    public partial class EditEmployees : Form
    {
        private int employeeID;

        public EditEmployees(int employeeID)
        {
            InitializeComponent();
            this.employeeID = employeeID;
        }

        private void EditEmployees_Load(object sender, EventArgs e)
        {
            eye.Visible = false;
            eyeConfirm.Visible = false;
            checkVisiblePass();
            getEmployee(this.employeeID);
        }

        private void getEmployee(int employeeID)
        {
            try
            {
                string commandSql = $"SELECT * FROM funcionario WHERE id = '{employeeID}';";
                MySqlDataReader reader = PIM.Database.Connection.connectDB(commandSql);

                while (reader.Read())
                {
                    inputName.Text = reader.GetString(3);
                    inputEmail.Text = reader.GetString(4);
                    inputPhone.Text = reader.GetString(5);
                    inputCpf.Text = reader.GetString(6);
                    inputPass.Text = reader.GetString(7);
                    inputConfirmPass.Text = reader.GetString(7);
                    selectRole.SelectedIndex = reader.GetInt32(2) - 1;
                    selectPermition.SelectedIndex = reader.GetInt32(1) - 1;
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


        public void updateEmployee()
        {

            try
            {
                string commandSql = $"UPDATE funcionario SET idPermissao = {selectPermition.SelectedIndex + 1}, idCargo = {selectRole.SelectedIndex + 1}, nome = '{PIM.Utils.Capitalize.tranformCapitalize(inputName.Text)}', email = '{inputEmail.Text}', celular = '{inputPhone.Text}', cpf = '{inputCpf.Text}', senha = '{inputPass.Text}' WHERE id = {employeeID};";
                MySqlDataReader reader = PIM.Database.Connection.connectDB(commandSql);

                MessageBox.Show("Funcionario atualizado com suceso!");
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show("Este CPF já está vinculado a um usuário!",
                               "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (validateAllFields())
            {
                updateEmployee();
                PIM.Utils.ContextHome._Home.FormShow(new Employees());
            }
        }

        private bool checkConfirmPass()
        {
            if (inputPass.Text.Length >= 8)
            {

                if (inputPass.Text == inputConfirmPass.Text)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("As senhas devem ser iguais para confirmação!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

            }
            else
            {
                MessageBox.Show("A senha deve conter no minimo 8 caracteres!","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void inputPhone_TextChanged(object sender, EventArgs e)
        {
            inputPhone.TextChanged -= new System.EventHandler(this.inputPhone_TextChanged);
            PIM.Utils.Masks.ApplyPhoneFormat(inputPhone);
            inputPhone.TextChanged += new System.EventHandler(this.inputPhone_TextChanged);
        }

        private void inputCpf_TextChanged(object sender, EventArgs e)
        {
            inputCpf.TextChanged -= new System.EventHandler(this.inputCpf_TextChanged);
            PIM.Utils.Masks.ApplyCPFformat(inputCpf);
            inputCpf.TextChanged += new System.EventHandler(this.inputCpf_TextChanged);
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            PIM.Utils.ContextHome._Home.FormShow(new Employees());
        }
    }
}

