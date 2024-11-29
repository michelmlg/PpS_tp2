using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
 


namespace prjClinicaIMC
{
    public class Utilitarios
    {
        public static string formataCnpj(string cnpj) //  
        {
            try
            {
                string local = cnpj = cnpj.Replace(".", String.Empty).Replace("/", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);

                if ("00000000000000".Equals(cnpj)) return String.Empty;

                if (local.Length == 11)
                {
                    return formataCpf(local);
                }

                if (local.Length != 14) return cnpj;

                return String.Concat(local.Substring(0, 2), ".", local.Substring(2, 3), ".", local.Substring(5, 3), "/", local.Substring(8, 4), "-", local.Substring(12, 2));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static string formataCEP(string cep)
        {
            try
            {
                string local = cep = cep.Replace(".", String.Empty).Replace("/", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty).Replace("_", String.Empty);

                while (local.Length < 8)
                {
                    local = "0" + local;
                }

                if (local.Length > 8)
                {
                    local = local.Substring(0, 8);
                }

                int valor;

                if (Int32.TryParse(local.Substring(0, 5), out valor) == false || Int32.TryParse(local.Substring(5, 3), out valor) == false)
                {
                    throw new ArgumentException("CEP Inválido");
                }

                return String.Concat(local.Substring(0, 5), "-", local.Substring(5, 3));
            }
            catch (Exception)
            {
                throw;
            }
        }


        public static string formataCpf(string cpf) //  32369280778
        {
            try
            {
                string local = cpf.Replace(".", String.Empty).Replace("/", String.Empty).Replace("-", String.Empty).Replace(" ", String.Empty);

                if ("00000000000".Equals(cpf)) return String.Empty;

                if (local.Length != 11) return cpf;

                return String.Concat(local.Substring(0, 3), ".", local.Substring(3, 3), ".", local.Substring(6, 3), "/", local.Substring(9, 2));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool validaNomeDeArquivo(string fileName)
        {
            try
            {
                string pattern = @"^[\w\-. ]+$";
                Regex regex = new Regex(pattern);
                return (regex.IsMatch(fileName));
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static bool ValidaCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int soma;
            int resto;

            string digito;
            string tempCnpj;

            if (cnpj == null)
            {
                return false;
            }

            cnpj = cnpj.Trim();

            cnpj = cnpj.Replace(".", String.Empty).Replace("-", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty);

            if (cnpj.Length != 14)
                return false;

            if ("00000000000000".Equals(cnpj))
                return false;

            tempCnpj = cnpj.Substring(0, 12);

            soma = 0;

            for (int i = 0; i < 12; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            resto = (soma % 11);

            if (resto < 2)

                resto = 0;

            else

                resto = 11 - resto;

            digito = resto.ToString();

            tempCnpj = tempCnpj + digito;

            soma = 0;

            for (int i = 0; i < 13; i++)

                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }    

        public static bool ValidaCpf(string cpf)
        {
            try
            {
                if (cpf == null)
                {
                    return false;
                }

                if (cpf.Length != 11)
                {
                    cpf = cpf.Replace(".", String.Empty).Replace("-", String.Empty).Replace("/", String.Empty).Replace(" ", String.Empty);
                    if (cpf.Length != 11) return false;
                }

                double valor = 0;

                if (Double.TryParse(cpf, out valor) == false) return false;

                int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

                string tempCpf;
                string digito;
                int soma;
                int resto;

                tempCpf = cpf.Substring(0, 9);

                soma = 0;

                for (int i = 0; i < 9; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                }

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCpf = String.Concat(tempCpf, digito);

                soma = 0;

                for (int i = 0; i < 10; i++)
                {
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                }

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = String.Concat(digito, resto);

                return cpf.EndsWith(digito);
            }
            catch (Exception)
            {
                throw;
            }
        } 
         
        public static List<Usuario> loadUsuario(string arquivo)
        {
            try
            {
                if (!File.Exists(arquivo)) return null;

                FileStream fs = new FileStream(arquivo, FileMode.Open);

                if (fs.Length == 0)
                {
                    try
                    {
                        fs.Dispose();
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                    return null;
                }
                try
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    List<Usuario> lista = (List<Usuario>) formatter.Deserialize(fs);
                    return lista;
                }
                finally
                {
                    fs.Dispose();
                }
            }
            catch (Exception)
            {
                return null;
            }

        } 
   
        public static void saveUsuario(List<Usuario> lista, string arquivo)
        {
            if (lista.Count == 0) return;
            try
            {
                FileStream fs = new FileStream(arquivo, FileMode.Create);
                try
                {
                    BinaryFormatter serializer = new BinaryFormatter();
                    serializer.Serialize(fs, lista);
                }
                finally
                {
                    try
                    {
                        fs.Dispose();
                    }
                    catch
                    {
                        //
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}