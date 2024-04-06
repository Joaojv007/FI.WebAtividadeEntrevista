
using FI.AtividadeEntrevista.DAL;

namespace FI.AtividadeEntrevista.Services
{
    public static class BeneficiarioService
    {
        /// <summary>
        /// VerificarExistenciaCampo
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="campoValor"></param>
        /// <returns></returns>
        public static bool VerificarExistenciaCampo(string campo, string campoValor)
        {
            var cli = new DaoBeneficiario();
            return cli.VerificarExistencia(campo, campoValor);
        }
    }
}