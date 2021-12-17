/*                                                                          Jogo da Memória  
 *                  Created by: Ericles, Joane, Kendy e Milena
 *                                            
*/

using System.Diagnostics;
namespace Memory
{
    //3 botoes de dificuldade faltou fazer
    public partial class Tela : Form
    {
        public const int dificuldade_Facil = 5;
        public const int dificuldade_Media = 7;
        public const int dificuldade_Dificil = 10;
        public bool rodando = true;
        public int indice = 0;
        public int rodada = 1;
        public int[] numeros = new int[5];
        public int[] dadosDigitados = new int [5];
        public bool ganhouBool = false;

        public Tela()
        {
            InitializeComponent();
            desabilitarBotoes();
        }

        private async Task<string> DelayAsync()
        {
            await Task.Delay(5000);
            return "Done";
        }

        public string directory()
        {
            try
            {
                DelayAsync();
                String text = File.ReadAllText("Combination.txt");
                return text;
            }
            catch (FileNotFoundException e)
            {
                //DelayAsync();
                String text = directory();
               // String text = File.ReadAllText("Combination.txt");
                return text;
            }    
        }


        public void guardaCombinacao()
        {

            Process.Start("assemble.bat");   //pegar a subpasta bin do projeto
            String text = directory();
            for (int i = 0; i < 5; i++)
            {
                numeros[i] = int.Parse(text.Substring(i, 1));
            }
        }

        public void desabilitarBotoes()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
        }
        public void habilitarBotoes()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
        }

        public void reseta()
        {
            guardaCombinacao();
            ganhouBool = false;
            rodando = true;
            rodada = 1;
            indice = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                dadosDigitados[i] = 0;
            }
        }
        public void zera()
        {
            indice = 0;
            for(int i=0; i<numeros.Length; i++)
            {
                dadosDigitados[i] = 0;
            }
        }

        public void errou()
        {
            reseta();
            label2.Text = "Errou :(";
        }
        public void ganhou()
        {
            button10.Visible = true;
            ganhouBool = true;
            label2.Text = "Parabens :D";
            button10.Text = "Jogar\nNovamente";
        }

        public void acertou()
        {
            rodada++;
            indice = 0;
        }
        public void verifica()
        {
            for(int i = 0; i < rodada; i++)
            {
                if (numeros[i] == dadosDigitados[i])
                {
                    if (i == dificuldade_Facil-1) //
                    {
                        ganhou();
                        return;
                    }
                    if(i == (rodada - 1))
                    {
                        acertou();                        
                        printarAsync();
                        return;
                    }
                    else
                    {
                        continue;
                    }
                }
                errou();
                return;
                
                
                }
            }
        
        async Task printarAsync()
        {
            desabilitarBotoes();
            label2.Text = "";
                for (int j = 0; j < rodada; j++)
                {
                    label1.Text = numeros[j].ToString();
                    await Task.Delay(600);                      
                    label1.Text = "";
                    await Task.Delay(100);
            }

            label1.Text = "";
            habilitarBotoes();
        }
        private void startar(object sender, EventArgs e) //Colocar botao carregar
        {
            reseta();
            guardaCombinacao();            
            button10.Visible = false;
            habilitarBotoes();
            button10.Text = "";
            printarAsync();
            rodando = false;
                        
        }

        void gerenciadorDeEventos(int botao)
        {
            if (indice < rodada)
            {
                dadosDigitados[indice++] = botao;
                rodando = true;
                if(indice == rodada)
                    rodando = false;
                
                
            }

            if (!rodando)
            {
                verifica();
                if (!ganhouBool) { 
                printarAsync();
                zera();
                }
                else
                {
                    reseta();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            gerenciadorDeEventos(9);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       
    }
}