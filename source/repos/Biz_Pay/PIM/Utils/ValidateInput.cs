using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PIM.Utils
{
    static public class ValidateInput
    {
        public static bool validateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(email))
            {
                MessageBox.Show("Endereço de e-mail inválido!","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }
            
         return true;
            
        }

        public static bool validatePhone(string phone)
        {
            string pattern = @"^\(\d{2}\) \d{5}-\d{4}$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(phone))
            {
                MessageBox.Show("Número de telefone inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public static bool validateName(string name)
        {
            string pattern = @"^[a-zA-ZÀ-ú]+([ ][a-zA-ZÀ-ú]+)*[ ]?$";
            Regex regex = new Regex(pattern);


            if (!regex.IsMatch(name))
            {
                MessageBox.Show("Nome inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public static bool validateCpf(string cpf)
        {
            string pattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";
            Regex regex = new Regex(pattern);


            if (!regex.IsMatch(cpf))
            {
                MessageBox.Show("CPF inválido!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }

        public static bool validadeComboBox(ComboBox comboBox, string fieldName)
        {
            if (comboBox.SelectedItem == null)
            {
                MessageBox.Show($"Selecione um valor para o campo {fieldName}", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }


    }
}
