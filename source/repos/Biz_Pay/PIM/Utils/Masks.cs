using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIM.Utils
{
    static public class Masks
    {
        public static void ApplyCPFformat(TextBox textBox)
        {

            string text = textBox.Text.Replace(".", "").Replace("-", "");

            if (text.Length > 3)
                text = text.Insert(3, ".");
            if (text.Length > 7)
                text = text.Insert(7, ".");
            if (text.Length > 11)
                text = text.Insert(11, "-");

            textBox.Text = text;

            textBox.SelectionStart = textBox.Text.Length;
        }

        public static void ApplyPhoneFormat(TextBox textBox)
        {

            string text = textBox.Text.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");

            if (text.Length > 0)
                text = text.Insert(0, "(");
            if (text.Length > 3)
                text = text.Insert(3, ")");
            if (text.Length > 4)
                text = text.Insert(4, " ");
            if (text.Length > 10)
                text = text.Insert(10, "-");

            textBox.Text = text;

            textBox.SelectionStart = textBox.Text.Length;

        }

    }
}
