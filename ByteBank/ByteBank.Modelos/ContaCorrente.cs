using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define tipo como conta corrente do banco bytebank
    /// </summary>
    public class ContaCorrente
    {
        private static int TaxaOperacao;

        public static int TotalDeContasCriadas { get; private set; }

        public Cliente Titular { get; set; }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public int Numero { get; }
        public int Agencia { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Construtor responsavel por criar contas do banco bytebank
        /// </summary>
        /// <param name="agencia">Numero da agencia (Atributo <see cref="Agencia"/>), o numero deve ser maior que zero</param>
        /// <param name="numero">Numero da conta (Atributo <see cref="Conta"/>), o numero deve ser maior que zero</param>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if (numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }
        /// <summary>
        /// Função responsavel por receber valor do saque (<paramref name="valor"/>) e subitrair do saldo da conta (<see cref="Saldo"/>)
        /// </summary>
        /// <exception cref="ArgumentException">Erro acontece quando o paramentro <paramref name="valor"/> é menor que zero</exception>
        /// <exception cref="SaldoInsuficienteException">Erro acontece quando <see cref="Saldo"/> é menor que o valor do parametro <paramref name="valor"/></exception>
        /// <param name="valor">Valor que sera subtraido do saldo da conta, valor deve ser maior que zero e menor que o <see cref="Saldo"/> da conta!</param>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }
        /// <summary>
        /// Função recebe valor que sera crescentado ao saldo da propriedade <see cref="Saldo"/> 
        /// </summary>
        /// <param name="valor">Parametro para acressam ao saldo da conta, valor deve ser maior que zero</param>
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        /// <summary>
        /// Função para tranferencia de saldo entre contas bytebank
        /// </summary>
        /// <param name="valor">Parametro que recebe o valor que sera transferido, valor deve ser positivo.</param>
        /// <param name="contaDestino">Parametro que diz qual conta sera a beneficiaria da transferencia. Passar objeto do tipo ContaCorrente.</param>
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }
    }

}
