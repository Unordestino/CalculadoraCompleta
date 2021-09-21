using System;

using System.Windows.Forms;

namespace CalculadoraCompletas {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private double numero1;
        private double numero2;
        private string operacao;
        private double resultado;

        private Boolean PressionouIgual;

        private void Form1_Load(object sender, EventArgs e) {
            LimparCampos();
        }

        private void LimparCampos() {
            txtDisplay.Clear();
            numero1 = 0;
            numero2 = 0;
            operacao = string.Empty;
            PressionouIgual = false;
            resultado = 0;

        }

        private void AdicionarCaracterNumero(string caracter) {
            if (PressionouIgual == true) {
                txtDisplay.Clear();
                PressionouIgual = false;
            }
            if (txtDisplay.Text.Length < 12) {
                if (txtDisplay.Text.Trim().Equals("0")) {
                    txtDisplay.Text = caracter;
                } else {
                    txtDisplay.Text += caracter;
                }
            } else {

                MessageBox.Show("Valor Máximo Alcançado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void AdicionarCaracterOperacao(string caracter) {

            if (!txtDisplay.Text.Trim().Equals(string.Empty)) {

                if (txtDisplay.Text.Trim().Contains(".")) {
                    numero1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                } else {
                    numero1 = Convert.ToDouble(txtDisplay.Text.Trim());
                }

                operacao = caracter;
                txtDisplay.Clear();
            } else {
                MessageBox.Show("Insira um valor");
            }
        }

        private void Calcular() {
            switch (operacao) {
                case "/":
                    if (numero2 == 0) {
                        MessageBox.Show("Divisão por zero!");
                        break;
                    }
                    resultado = numero1 / numero2;
                    break;

                case "*":
                    resultado = numero1 * numero2;
                    break;

                case "+":
                    resultado = numero1 + numero2;
                    break;

                case "-":
                    resultado = numero1 - numero2;
                    break;

                case "^":
                    resultado = CalcularPotencia();

                    break;
            }
            txtDisplay.Text = resultado.ToString().Replace(",", ".");
        }

        public double CalcularPotencia() {
            return Math.Pow(numero1, numero2);

        }


        private void btn0_Click(object sender, EventArgs e) {
            if (txtDisplay.Text.Length < 12) {
                if (!txtDisplay.Text.Trim().Equals("0")) {
                    txtDisplay.Text += "0";
                }
            }
        }

        private void btn1_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("1");
        }

        private void btn2_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("2");
        }

        private void btn3_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("3");
        }

        private void btn4_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("4");
        }

        private void btn5_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("5");
        }

        private void btn6_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("6");
        }

        private void btn7_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("7");
        }

        private void btn8_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("8");
        }

        private void btn9_Click(object sender, EventArgs e) {
            AdicionarCaracterNumero("9");
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e) {

        }

        private void btnDivisao_Click(object sender, EventArgs e) {
            AdicionarCaracterOperacao("/");
        }

        private void btnMultiplicacao_Click(object sender, EventArgs e) {
            AdicionarCaracterOperacao("*");
        }

        private void btnSubtracao_Click(object sender, EventArgs e) {
            AdicionarCaracterOperacao("-");
        }

        private void btnAdicao_Click(object sender, EventArgs e) {
            AdicionarCaracterOperacao("+");
        }

        private void btnIgual_Click(object sender, EventArgs e) {
            if (PressionouIgual) {
                txtDisplay.Clear();
                PressionouIgual = false;
                return;
            }

            if (!txtDisplay.Text.Trim().Equals(string.Empty)) {

                if (txtDisplay.Text.Trim().Contains(".")) {
                    numero2 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                } else {
                    numero2 = Convert.ToDouble(txtDisplay.Text.Trim());
                }

                Calcular();
                PressionouIgual = true;
            }
        }

        private void btnPonto_Click(object sender, EventArgs e) {

            if (PressionouIgual) {
                txtDisplay.Text = "0.";
                PressionouIgual = false;
                return;
            }

            if (txtDisplay.Text.Trim().Equals(string.Empty)) txtDisplay.Text = "0.";

            if (txtDisplay.Text.Trim().Contains(".")) return;

            txtDisplay.Text += ".";

        }

        private void btnC_Click(object sender, EventArgs e) {
            LimparCampos();
        }

        private void btnCE_Click(object sender, EventArgs e) {
            if (operacao.Equals(string.Empty) || PressionouIgual) {
                LimparCampos();
            } else {
                txtDisplay.Clear();
            }
        }

        private void btnMaisMenos_Click(object sender, EventArgs e) {
            if (!txtDisplay.Text.Trim().Equals(string.Empty)){
                txtDisplay.Text = (Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ",")) * (-1)).ToString().Replace(",", ".");
            }
            
        }

        private void btnRemoveUltimoDigito_Click(object sender, EventArgs e) {
            int tam = txtDisplay.Text.Trim().Length;
            string texto = txtDisplay.Text.Trim();
            txtDisplay.Clear();
            for (int i = 0; i < tam - 1; i++) {
                txtDisplay.Text = txtDisplay.Text + texto[i];
            }
        }

        private void btnElevaQuadrado_Click(object sender, EventArgs e) {
            if (!txtDisplay.Text.Trim().Equals(string.Empty)) {
                numero1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));
                numero2 = 2;

                resultado = CalcularPotencia();

                txtDisplay.Text = resultado.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }

        private void btnPotencia_Click(object sender, EventArgs e) {
            AdicionarCaracterOperacao("^");
        }

        private void btnRaizQuadrada_Click(object sender, EventArgs e) {
            if (!txtDisplay.Text.Trim().Equals(string.Empty)) {
                numero1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));


                resultado = Math.Sqrt(numero1);

                txtDisplay.Text = resultado.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }

        private void BtnUmPorX_Click(object sender, EventArgs e) {
            if (!txtDisplay.Text.Trim().Equals(string.Empty)) {
                numero1 = Convert.ToDouble(txtDisplay.Text.Trim().Replace(".", ","));

                if (numero1 == 0) {
                    MessageBox.Show("Error. Divisão por zero!");
                    return;
                }

                resultado = 1 / numero1;

                txtDisplay.Text = resultado.ToString().Replace(",", ".");
                PressionouIgual = true;
            }
        }
    }
}
