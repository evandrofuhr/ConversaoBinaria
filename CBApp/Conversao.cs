using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBApp
{

    public static class Conversao
    {
        public static string ValorDecimal;
        public static string ValorBinario;
        public static string ValorHex;
        public static string ValorOctal;
        public static string ValorDecimalFrac;
        public static string ValorBinarioFrac;

        public static Dictionary<string, string> hex = null;
        public static Dictionary<string, string> octal = null;

        static Conversao()
        {
            hex = new Dictionary<string, string>();
            for (int i = 0; i <= 9; i++)
            {
                hex.Add(i.ToString(), i.ToString());
            }
            hex.Add("A", "10");
            hex.Add("B", "11");
            hex.Add("C", "12");
            hex.Add("D", "13");
            hex.Add("E", "14");
            hex.Add("F", "15");

            hex.Add("10","A");
            hex.Add("11","B");
            hex.Add("12","C");
            hex.Add("13","D");
            hex.Add("14","E");
            hex.Add("15","F");

            octal = new Dictionary<string, string>();
            var temp = 0;
            for (int i = 0; i <= 1; i++)
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int k = 0; k <= 1; k++)
                    {
                        octal.Add(string.Format("{0}{1}{2}", i, j, k),temp.ToString());
                        octal.Add(temp.ToString(), string.Format("{0}{1}{2}", i, j, k));
                        temp++;
                    }
                }
            }

        }

        public static void DecimalFracToBinary()
        {
            var limite = 1;
            var limiteMax = 0;
            var valorDecimalAntes = ValorDecimal;
            var valorBinaryAntes = ValorBinario;

            var arr = ValorDecimalFrac.Split(',');

            ValorDecimal = arr[0];

            DecimalToBinary();

            var temp = ValorBinario;

            ValorBinario = valorBinaryAntes;
            ValorDecimal = valorDecimalAntes;

            var resto = decimal.Parse(string.Format("0,{0}",arr[1]));
            limiteMax = arr[1].Length * 4;
            var vlrBase = (decimal)2;
            var binary = new List<decimal>();

            while (limite <= limiteMax)
            {
                binary.Add(Math.Truncate((decimal)(resto * vlrBase)));
                resto = (resto * vlrBase) % 1;
                limite++;
            }

            ValorBinario = string.Empty;

            for (int i = 0; i < binary.Count; i++)
            {
                ValorBinario += binary.ElementAt(i);
            }
            ValorBinario = string.Format("{0},{1}", temp, ValorBinario);
        }

        public static void BinaryFracToDecimal()
        {
            var valorBinaryAntes = ValorBinario;
            var arr = ValorBinarioFrac.Split(',');

            ValorBinario = arr[0];
            BinaryToDecimal();

            var tempDec = (decimal)0;
            var vlrBase = 2;
            var potencia = -1;

            var round = arr[1].ToCharArray().Length/4;

            for (int i = 0; i < arr[1].ToCharArray().Length; i++)
            {
                tempDec += (decimal)Math.Pow(vlrBase, potencia) * int.Parse(arr[1].ElementAt(i).ToString());
                potencia--;
            }

            tempDec = Math.Truncate(decimal.Round(tempDec, round) * (decimal)Math.Pow(10,round));

            ValorBinario = valorBinaryAntes;

            ValorDecimal = string.Format("{0},{1}", ValorDecimal, tempDec);
        }

        public static void BinaryToDecimal()
        {
            var temp = 0.0;
            var tamanho = ValorBinario.ToCharArray().Length;

            var potencia = 0;
            var vlrBase = 2;

            for (int i = tamanho-1; i >= 0; i--)
            {
                temp += Math.Pow(vlrBase, potencia) * int.Parse(ValorBinario.ElementAt(i).ToString());
                potencia++;
            }

            ValorDecimal = temp.ToString();
        }

        public static void DecimalToBinary()
        {
            var resto = decimal.Parse(ValorDecimal);
            var vlrBase = (decimal)2;
            var binary = new List<decimal>();

            while ((resto != 0) && (resto != 1))
            {
                binary.Add(resto % vlrBase);
                resto = Math.Truncate((decimal)(resto / vlrBase));
            }
            binary.Add(resto);

            ValorBinario = string.Empty;

            for (int i = binary.Count - 1; i >= 0; i--)
            {
                ValorBinario += binary.ElementAt(i);
            }
        }

        public static void OctalToBinary()
        {
            var resto = decimal.Parse(ValorOctal);
            var vlrBase = (decimal)8;
            var binary = new List<decimal>();

            while ((resto != 0) && (resto != 1))
            {
                binary.Add(resto % vlrBase);
                resto = Math.Truncate((decimal)(resto / vlrBase));
            }
            binary.Add(resto);

            ValorBinario = string.Empty;

            for (int i = binary.Count - 1; i >= 0; i--)
            {
                ValorBinario += binary.ElementAt(i);
            }
        }

        public static void OctalToDecimal()
        {
            var temp = 0.0;
            var tamanho = ValorOctal.ToCharArray().Length;

            var potencia = 0;
            var vlrBase = 8;

            for (int i = tamanho - 1; i >= 0; i--)
            {
                temp += Math.Pow(vlrBase, potencia) * int.Parse(ValorOctal.ElementAt(i).ToString());
                potencia++;
            }

            ValorDecimal = temp.ToString();
        }

        public static void HexToDecimal()
        {
            var temp = 0.0;
            var tamanho = ValorHex.ToCharArray().Length;

            var potencia = 0;
            var vlrBase = 16;

            for (int i = tamanho - 1; i >= 0; i--)
            {
                var elemento = int.Parse(hex[ValorHex.ElementAt(i).ToString()]);
                temp += Math.Pow(vlrBase, potencia) * elemento;
                potencia++;
            }

            ValorDecimal = temp.ToString();
        }


        public static void DecimalToHex()
        {
            var resto = decimal.Parse(ValorDecimal);
            var vlrBase = (decimal)16;
            var hexList = new List<decimal>();

            while ((resto >= vlrBase))
            {
                hexList.Add(resto % vlrBase);
                resto = Math.Truncate((decimal)(resto / vlrBase));
            }
            hexList.Add(resto);

            ValorHex = string.Empty;

            for (int i = hexList.Count - 1; i >= 0; i--)
            {
                ValorHex += hex[hexList.ElementAt(i).ToString()];
            }
        }

        public static void BinaryToOctal()
        {
            var temp = 0;
            var strTemp = string.Empty;
            var tamanho = ValorBinario.ToCharArray().Length;

            ValorOctal = string.Empty;

            for (int i = tamanho - 1; i >= 0; i--)
            {

                temp++;
                strTemp = string.Format("{0}{1}",ValorBinario.ElementAt(i),strTemp);
                if (temp == 3)
                {
                    ValorOctal = string.Format("{0}{1}", octal[strTemp], ValorOctal);
                    temp = 0;
                    strTemp = string.Empty;
                }
            }

            strTemp = strTemp.PadLeft(3, '0');
            ValorOctal = string.Format("{0}{1}", octal[strTemp], ValorOctal);
        }

        public static void BinaryToHex()
        {
            BinaryToDecimal();
            DecimalToHex();
        }

        public static void Decimal()
        {
            DecimalToBinary();
            DecimalToHex();
            BinaryToOctal();

            tratarRetorno();
        }

        public static void DecimalFracionado()
        {
            DecimalFracToBinary();
            tratarRetorno();
        }

        public static void Binario()
        {
            BinaryToHex();
            BinaryToOctal();
            tratarRetorno();
        }

        public static void Hexadecimal()
        {
            HexToDecimal();
            DecimalToBinary();
            BinaryToOctal();
            tratarRetorno();
        }

        public static void Octal()
        {
            OctalToDecimal();
            DecimalToBinary();
            BinaryToHex();
            tratarRetorno();
        }

        public static string RetornaDecimalValido(string valor)
        {
            var arr = valor.ToUpper().Trim().ToCharArray();
            var lista = new List<string>();

            lista.Add(",");
            for (int i = 0; i <= 9; i++)
                lista.Add(i.ToString());

            valor = string.Empty;
            foreach (var item in arr)
            {
                if (lista.IndexOf(item.ToString()) >= 0)
                    valor += item.ToString();
            }
            return valor;
        }

        public static string RetornaBinarioValido(string valor)
        {
            var arr = valor.ToUpper().Trim().ToCharArray();
            var lista = new List<string>();

            for (int i = 0; i <= 1; i++)
                lista.Add(i.ToString());
            lista.Add(",");

            valor = string.Empty;
            foreach (var item in arr)
            {
                if (lista.IndexOf(item.ToString()) >= 0)
                    valor += item.ToString();
            }
            return valor;
        }

        public static string RetornaOctalValido(string valor)
        {
            var arr = valor.ToUpper().Trim().ToCharArray();
            var lista = new List<string>();

            for (int i = 0; i <= 7; i++)
                lista.Add(i.ToString());

            valor = string.Empty;
            foreach (var item in arr)
            {
                if (lista.IndexOf(item.ToString()) >= 0)
                    valor += item.ToString();
            }
            return valor;
        }

        public static string RetornaHexValido(string valor)
        {
            var arr = valor.ToUpper().Trim().ToCharArray();

            valor = string.Empty;
            foreach (var item in arr)
            {
                try
                {
                    if (!string.IsNullOrEmpty(hex[item.ToString()]))
                        valor += item.ToString();
                }
                catch
                {

                }
                    
            }
            return valor;
        }

        private static void tratarRetorno()
        {
            //TODO : Verificar retornos
            if (((ValorBinario.Length % 4) != 0) && (!(ValorBinario.Contains(","))))
                ValorBinario = ValorBinario.PadLeft(ValorBinario.Length + 4 - (ValorBinario.Length % 4), '0');
            if ((ValorOctal.Length % 3) != 0)
                ValorOctal = ValorOctal.PadLeft(ValorOctal.Length + 3 - (ValorOctal.Length % 3), '0');
        }

    }
}
