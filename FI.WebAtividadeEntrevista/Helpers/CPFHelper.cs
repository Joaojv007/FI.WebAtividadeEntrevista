
namespace WebAtividadeEntrevista.Helpers
{
    public static class CPFHelper
    {
        /// <summary>
        /// Valida Campo CPF
        /// </summary>
        /// <param name="CPF">CPF do cliente</param>
        public static bool ValidarCPF(string CPF)
        {
            {
                CPF = CPF.Replace(".", "").Replace("-", "");

                if (CPF.Length != 11)
                    return false;

                if (new string(CPF[0], 11) == CPF)
                    return false;

                int soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += (CPF[i] - '0') * (10 - i);
                int resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                if (CPF[9] != resto + '0')
                    return false;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += (CPF[i] - '0') * (11 - i);
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                if (CPF[10] != resto + '0')
                    return false;

                return true;
            }
        }
    }
}