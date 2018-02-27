using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade_Lemaf
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(".....................MEET GROUP.....................");
            Console.WriteLine("....BEM-VINDO AO SISTEMA DE AGENDAMENDO DE SALAS....");
            int escolha = Interface();

            int verifica = Execucao(escolha);
            while (verifica != 1)
            {
                escolha = Interface();
                verifica = Execucao(escolha);
            }

            Console.ReadKey();
        }

        static int Interface()
        {
            Console.WriteLine(" ");
            Console.WriteLine(".......MENU.......");
            Console.WriteLine("Escolha uma opção:");
            Console.WriteLine("1)Reservar uma sala:");
            Console.WriteLine("2)Salas dispoíveis:");
            Console.WriteLine("3)Desmarcar uma sala:");
            Console.WriteLine("4)Sair.");
            Console.WriteLine(" ");
            Console.Write("Digite a opção escolhida: ");

            int opcao;
            opcao = Convert.ToInt32(Console.ReadLine());
           
            return opcao;            
        }

        static int Execucao (int escolha)
        {
            if(escolha == 1)
            {
                Reserva();
                return 0;
            }
            else if(escolha == 2)
            {
                Consulta();
                return 0;
            }
            else if(escolha == 3)
            {
                Cancelamento();
                return 0;
            }
            else if(escolha == 4)
            {
                Console.WriteLine("Você finalizou o programa. Até breve!");
                return 1;
            }
            else {
                Console.WriteLine("Opção Inválida. Digite novamente.");
                return 0;
            }
        }

        struct Sala
        {
            public int computador;
            public int capacidade;
            public string internet;
            public string tv_web;
            public int ocupado;
        }

        static void CriaSalas (Sala[] salas)
        {
            System.IO.StreamReader arquivo = new System.IO.StreamReader("salas.txt");
            for (int i = 0; i < 12; i++)
            {
                string aux = arquivo.ReadLine();
                salas[i].ocupado = (Convert.ToInt32(aux.Substring(aux.Length - 1)));
            }
            arquivo.Close();

            salas[0].computador = 1;
            salas[0].capacidade = 10;
            salas[0].internet = "Sim";
            salas[0].tv_web = "Sim";
           
            salas[1].computador = 1;
            salas[1].capacidade = 10;
            salas[1].internet = "Sim";
            salas[1].tv_web = "Sim";
            
            salas[2].computador = 1;
            salas[2].capacidade = 10;
            salas[2].internet = "Sim";
            salas[2].tv_web = "Sim";
           
            salas[3].computador = 1;
            salas[3].capacidade = 10;
            salas[3].internet = "Sim";
            salas[3].tv_web = "Sim";
           
            salas[4].computador = 1;
            salas[4].capacidade = 10;
            salas[4].internet = "Sim";
            salas[4].tv_web = "Sim";
           
            salas[5].computador = 0;
            salas[5].capacidade = 10;
            salas[5].internet = "Sim";
            salas[5].tv_web = "Não";
            
            salas[6].computador = 0;
            salas[6].capacidade = 10;
            salas[6].internet = "Sim";
            salas[6].tv_web = "Não";

            salas[7].computador = 1;
            salas[7].capacidade = 3;
            salas[7].internet = "Sim";
            salas[7].tv_web = "Sim";

            salas[8].computador = 1;
            salas[8].capacidade = 3;
            salas[8].internet = "Sim";
            salas[8].tv_web = "Sim";

            salas[9].computador = 1;
            salas[9].capacidade = 3;
            salas[9].internet = "Sim";
            salas[9].tv_web = "Sim";

            salas[10].computador = 0;
            salas[10].capacidade = 20;
            salas[10].internet = "Não";
            salas[10].tv_web = "Não";

            salas[11].computador = 0;
            salas[11].capacidade = 20;
            salas[11].internet = "Não";
            salas[11].tv_web = "Não";
        }

        static void Consulta()
        {
            string[] texto = new string[12];

            System.IO.StreamReader reader = new System.IO.StreamReader("salas.txt");

            for (int i = 0; i < 12; i++)
            {
                texto[i] = reader.ReadLine();
                if(Convert.ToInt32(texto[i].Substring(texto[i].Length - 1)) == 0){
                    Console.WriteLine("Sala {0} encontra-se vaga.", i+1);
                }
            }
            reader.Close();

        }

        static void Cancelamento()
        {
            int num_sala = 0;
            Console.Write("Digite qual sala deseja liberar: ");
            num_sala = Convert.ToInt32(Console.ReadLine());

            string[] texto = new string[12];

            System.IO.StreamReader reader = new System.IO.StreamReader("salas.txt");

            for (int i = 0; i < 12; i++)
            {
                texto[i] = reader.ReadLine();
            }

            reader.Close();

            if(Convert.ToInt32(texto[num_sala-1].Substring(texto[num_sala - 1].Length - 1)) == 0)
            {
                Console.WriteLine("Sala já estava vaga.");
            }
            else
            {
                texto[num_sala - 1] = num_sala + ";" + "0";
                Console.WriteLine("Sala {0} foi liberada", num_sala);
            }
            

            System.IO.File.WriteAllLines("salas.txt", texto);

        }
        
        public struct DadosEntrada
        {
           public string data_inicio;
           public string hora_inicio;
           public string data_fim;
           public string hora_fim;
           public string quantidade_pessoas;
           public string acesso_internet;
           public string tv_webcam;
        }

        static void EscreveArquivo(int num)
        {

            string[] texto = new string[12];

            System.IO.StreamReader reader = new System.IO.StreamReader("salas.txt");
           
            for (int i = 0; i < 12; i++)
            {
                texto[i] = reader.ReadLine();
            }

            reader.Close();
            texto[num - 1] = num + ";" + "1";

                System.IO.File.WriteAllLines("salas.txt", texto);

        }

        static void Reserva()
        {

            Sala[] salas = new Sala[12];

            CriaSalas (salas);

            Console.WriteLine(" ");
            Console.Write("Digite o nome do arquivo:");
            string nome_arquivo = Console.ReadLine();

            DadosEntrada dadosLidos;
            System.IO.StreamReader arquivo = new System.IO.StreamReader(nome_arquivo);
            string linha = "";
            
                linha = arquivo.ReadLine();
                
                    string[] DadosColetados = linha.Split(';');
                    dadosLidos.data_inicio = DadosColetados[0];
                    dadosLidos.hora_inicio = DadosColetados[1];
                    dadosLidos.data_fim = DadosColetados[2];
                    dadosLidos.hora_fim = DadosColetados[3];
                    dadosLidos.quantidade_pessoas = DadosColetados[4];
                    dadosLidos.acesso_internet = DadosColetados[5];
                    dadosLidos.tv_webcam = DadosColetados[6];

            if ((Convert.ToInt32(dadosLidos.hora_fim.Substring(0, 2))) - ((Convert.ToInt32(dadosLidos.hora_inicio.Substring(0, 2)))) > 8)
            {
                Console.WriteLine("Agendamento não permitido. Reuniões não podem durar mais que 8 horas.");
                return; 
            }

            int totalDias = (DateTime.Parse(dadosLidos.data_inicio).Subtract(DateTime.Parse(dadosLidos.data_fim))).Days;

            if (totalDias < 1)
            {
                Console.WriteLine("Agendamento não permitido.As reuniões devem ser agendadas com no mínimo um dia de antecedência.");
                return;
            }
            if (totalDias > 40)
            {
                Console.WriteLine("Agendamento não permitido. As reuniões devem ser agendadas com no máximo 40 dia de antecedência.");
                return;
            }
            else
            {
                if (dadosLidos.tv_webcam == "Sim")
                {
                    int num_sala = -1;
                    if (((Convert.ToInt32(dadosLidos.quantidade_pessoas)) > 3) & ((Convert.ToInt32(dadosLidos.quantidade_pessoas)) <= 10))
                    {

                       for(int i = 0; i<5; i++)
                        {
                            if(salas[i].ocupado == 0)
                            {
                                num_sala = i+1;
                                salas[i].ocupado = 1;
                                break;
                            }
                        }

                       if (num_sala != -1)
                        {
                            Console.WriteLine("Sala Reservada: Sala {0}.", num_sala);
                            EscreveArquivo(num_sala);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Não há sala disponível com as específicações passadas.");
                            Console.WriteLine("Porém temos as outras salas vagas:");
                            Console.WriteLine(" ");
                            Consulta();
                            return;

                        }
                    }

                    if ((Convert.ToInt32(dadosLidos.quantidade_pessoas)) <= 3)
                    {

                        for (int i = 7; i < 10; i++)
                        {
                            if (salas[i].ocupado == 0)
                            {
                                num_sala = i + 1;
                                salas[i].ocupado = 1;
                                break;
                            }
                        }

                        if (num_sala != -1)
                        {
                            Console.WriteLine("Sala Reservada: Sala {0}.", num_sala);
                            EscreveArquivo(num_sala);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Não há sala disponível com as específicações passadas.");
                            Console.WriteLine("Porém temos as outras salas vagas:");
                            Console.WriteLine(" ");
                            Consulta();
                            return;

                        }
                    }
                }

                else
                {

                    int num_sala = -1;
                    if (((Convert.ToInt32(dadosLidos.quantidade_pessoas)) <= 10) & (dadosLidos.acesso_internet == "Sim"))
                    {
                        for (int i = 5; i < 7; i++)
                        {
                            if (salas[i].ocupado == 0)
                            {
                                num_sala = i + 1;
                                salas[i].ocupado = 1;
                                break;
                            }
                        }

                        if (num_sala != -1)
                        {
                            Console.WriteLine("Sala Reservada: Sala {0}.", num_sala);
                            EscreveArquivo(num_sala);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Não há sala disponível com as específicações passadas.");
                            Console.WriteLine("Porém temos as outras salas vagas:");
                            Console.WriteLine(" ");
                            Consulta();
                            return;

                        }
                    }

                    if (((Convert.ToInt32(dadosLidos.quantidade_pessoas)) > 10) & (dadosLidos.acesso_internet == "Não") & ((Convert.ToInt32(dadosLidos.quantidade_pessoas)) <= 20))
                    {
                        for (int i = 10; i < 12; i++)
                        {
                            if (salas[i].ocupado == 0)
                            {
                                num_sala = i + 1;
                                salas[i].ocupado = 1;
                                break;
                            }
                        }

                        if (num_sala != -1)
                        {
                            Console.WriteLine("Sala Reservada: Sala {0}.", num_sala);
                            EscreveArquivo(num_sala);
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Não há sala disponível com as específicações passadas.");
                            Console.WriteLine("Porém temos as outras salas vagas:");
                            Console.WriteLine(" ");
                            Consulta();
                            return;

                        }
                    }
                }
            }

        }
    }
}
