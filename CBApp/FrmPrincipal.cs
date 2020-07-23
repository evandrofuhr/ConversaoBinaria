using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CBApp
{
    public partial class FrmPrincipal : Form
    {

        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private void tbDecimal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbDecimal.TextChanged -= tbDecimal_TextChanged;
                tbHex.TextChanged -= tbHex_TextChanged;
                tbOctal.TextChanged -= tbOctal_TextChanged;
                tbBinario.TextChanged -= tbBinario_TextChanged;

                tbBinario.Clear();
                tbHex.Clear();
                tbOctal.Clear();

                if (string.IsNullOrEmpty(tbDecimal.Text))
                    return;

                tbDecimal.Text = tbDecimal.Text.Replace(".", ",");
                if (tbDecimal.Text.Contains(","))
                {
                    tbDecimal.Text = Conversao.RetornaDecimalValido(tbDecimal.Text);
                    tbDecimal.SelectionStart = tbDecimal.Text.Length;

                    try
                    {
                        tbDecimal.Text = decimal.Parse(tbDecimal.Text).ToString();
                    }
                    catch
                    {
                        tbDecimal.Text = "0";
                    }

                    if (!tbDecimal.Text.Contains(","))
                    {
                        tbDecimal.Text = string.Format("{0},",tbDecimal.Text);
                        Conversao.ValorDecimalFrac = tbDecimal.Text;
                        tbDecimal.SelectionStart = tbDecimal.Text.Length;
                        return;
                    }

                    Conversao.ValorDecimalFrac = tbDecimal.Text;

                    try
                    {
                        Conversao.DecimalFracionado();
                    }
                    catch
                    {

                    }

                    tbBinario.Text = Conversao.ValorBinario;
                    tbHex.Clear();
                    tbOctal.Clear();
                }
                else
                {
                    tbDecimal.Text = Conversao.RetornaDecimalValido(tbDecimal.Text);
                    tbDecimal.SelectionStart = tbDecimal.Text.Length;

                    Conversao.ValorDecimal = tbDecimal.Text;
                    try
                    {
                        Conversao.Decimal();
                    }
                    catch
                    {

                    }
                    tbBinario.Text = Conversao.ValorBinario;
                    tbHex.Text = Conversao.ValorHex;
                    tbOctal.Text = Conversao.ValorOctal;
                }
            }
            finally
            {
                tbDecimal.TextChanged += tbDecimal_TextChanged;
                tbHex.TextChanged += tbHex_TextChanged;
                tbOctal.TextChanged += tbOctal_TextChanged;
                tbBinario.TextChanged += tbBinario_TextChanged;
            }
        }

        private void tbHex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbDecimal.TextChanged -= tbDecimal_TextChanged;
                tbHex.TextChanged -= tbHex_TextChanged;
                tbOctal.TextChanged -= tbOctal_TextChanged;
                tbBinario.TextChanged -= tbBinario_TextChanged;

                tbBinario.Clear();
                tbDecimal.Clear();
                tbOctal.Clear();

                if (string.IsNullOrEmpty(tbHex.Text))
                    return;

                tbHex.Text = Conversao.RetornaHexValido(tbHex.Text);
                tbHex.SelectionStart = tbHex.Text.Length;

                Conversao.ValorHex = tbHex.Text;
                try
                {
                    Conversao.Hexadecimal();
                }
                catch
                {

                }
                tbDecimal.Text = Conversao.ValorDecimal;
                tbBinario.Text = Conversao.ValorBinario;
                tbOctal.Text = Conversao.ValorOctal;
            }
            finally
            {
                tbDecimal.TextChanged += tbDecimal_TextChanged;
                tbHex.TextChanged += tbHex_TextChanged;
                tbOctal.TextChanged += tbOctal_TextChanged;
                tbBinario.TextChanged += tbBinario_TextChanged;
            }
        }

        private void tbOctal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tbDecimal.TextChanged -= tbDecimal_TextChanged;
                tbHex.TextChanged -= tbHex_TextChanged;
                tbOctal.TextChanged -= tbOctal_TextChanged;
                tbBinario.TextChanged -= tbBinario_TextChanged;

                tbBinario.Clear();
                tbDecimal.Clear();
                tbHex.Clear();

                if (string.IsNullOrEmpty(tbOctal.Text))
                    return;

                tbOctal.Text = Conversao.RetornaOctalValido(tbOctal.Text);
                tbOctal.SelectionStart = tbOctal.Text.Length;

                Conversao.ValorOctal = tbOctal.Text;
                try
                {
                    Conversao.Octal();
                }
                catch
                {

                }
                tbDecimal.Text = Conversao.ValorDecimal;
                tbBinario.Text = Conversao.ValorBinario;
                tbHex.Text = Conversao.ValorHex;
            }
            finally
            {
                tbDecimal.TextChanged += tbDecimal_TextChanged;
                tbHex.TextChanged += tbHex_TextChanged;
                tbOctal.TextChanged += tbOctal_TextChanged;
                tbBinario.TextChanged += tbBinario_TextChanged;
            }
        }

        private void tbBinario_TextChanged(object sender, EventArgs e)
        {

            try
            {
                tbDecimal.TextChanged -= tbDecimal_TextChanged;
                tbHex.TextChanged -= tbHex_TextChanged;
                tbOctal.TextChanged -= tbOctal_TextChanged;
                tbBinario.TextChanged -= tbBinario_TextChanged;

                tbOctal.Clear();
                tbDecimal.Clear();
                tbHex.Clear();

                if (string.IsNullOrEmpty(tbBinario.Text))
                    return;

                tbBinario.Text = tbBinario.Text.Replace(".", ",");
                tbBinario.Text = Conversao.RetornaBinarioValido(tbBinario.Text);
                tbBinario.SelectionStart = tbBinario.Text.Length;

                if (tbBinario.Text.Contains(","))
                {
                    var arr = tbBinario.Text.Split(',');

                    if (!((arr[1].Length % 4) == 0))
                        return;

                    var achou = false;
                    var temp = string.Empty;
                    foreach (var item in tbBinario.Text.ToCharArray())
                    {
                        if (item.Equals(",") && !achou)
                        {
                            temp += item;
                            achou = true;
                        }
                        else if (!item.Equals(","))
                        {
                            temp += item;
                        }
                    }
                    tbBinario.Text = temp;
                    Conversao.ValorBinarioFrac = tbBinario.Text;
                    try
                    {
                        Conversao.BinaryFracToDecimal();
                    }
                    catch
                    {

                    }
                    tbOctal.Clear();
                    tbHex.Clear();
                    tbDecimal.Text = Conversao.ValorDecimal;
                }
                else {
                    tbBinario.Text = Conversao.RetornaBinarioValido(tbBinario.Text);
                    tbBinario.SelectionStart = tbBinario.Text.Length;

                    Conversao.ValorBinario = tbBinario.Text;
                    try
                    {
                        Conversao.Binario();
                    }
                    catch
                    {

                    }
                    tbDecimal.Text = Conversao.ValorDecimal;
                    tbHex.Text = Conversao.ValorHex;
                    tbOctal.Text = Conversao.ValorOctal;
                }
            }
            finally
            {
                tbDecimal.TextChanged += tbDecimal_TextChanged;
                tbHex.TextChanged += tbHex_TextChanged;
                tbOctal.TextChanged += tbOctal_TextChanged;
                tbBinario.TextChanged += tbBinario_TextChanged;
            }
        }
    }
}
