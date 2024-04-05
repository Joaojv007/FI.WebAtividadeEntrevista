using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FI.AtividadeEntrevista.BLL
{
    public class BoCliente
    {
        /// <summary>
        /// Inclui um novo cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public long Incluir(DML.Cliente cliente)
        {
            ValidarCampos(cliente);
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Incluir(cliente);
        }

        /// <summary>
        /// Valida Campos Cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        private void ValidarCampos(DML.Cliente cliente)
        {
            if (!ValidarCPF(cliente.CPF))
            {
                throw new Exception("CPF inválido.");
            }

            if (VerificarExistencia(nameof(cliente.CPF), cliente.CPF))
            {
                throw new Exception("CPF já cadastrado.");
            }
        }

        /// <summary>
        /// Valida Campo CPF
        /// </summary>
        /// <param name="CPF">CPF do cliente</param>
        private bool ValidarCPF(string CPF)
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

        /// <summary>
        /// Altera um cliente
        /// </summary>
        /// <param name="cliente">Objeto de cliente</param>
        public void Alterar(DML.Cliente cliente)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Alterar(cliente);
        }

        /// <summary>
        /// Consulta o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public DML.Cliente Consultar(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Consultar(id);
        }

        /// <summary>
        /// Excluir o cliente pelo id
        /// </summary>
        /// <param name="id">id do cliente</param>
        /// <returns></returns>
        public void Excluir(long id)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            cli.Excluir(id);
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Listar()
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Listar();
        }

        /// <summary>
        /// Lista os clientes
        /// </summary>
        public List<DML.Cliente> Pesquisa(int iniciarEm, int quantidade, string campoOrdenacao, bool crescente, out int qtd)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.Pesquisa(iniciarEm,  quantidade, campoOrdenacao, crescente, out qtd);
        }

        /// <summary>
        /// VerificaExistencia
        /// </summary>
        /// <param name="campo"></param>
        /// <param name="campoValor"></param>
        /// <returns></returns>
        public bool VerificarExistencia(string campo, string campoValor)
        {
            DAL.DaoCliente cli = new DAL.DaoCliente();
            return cli.VerificarExistencia(campo, campoValor);
        }
    }
}
