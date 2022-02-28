using System;

namespace JogoDaVelha
{
    internal class Program
    {

        public static int MenuPrincipal()
        {
            bool flag = true;
            int opcao = 0;
            string selecao;

            do
            {
                Console.Clear();
                Console.WriteLine("----- Jogo da Velha -----");
                Console.WriteLine("----- Menu de Opções -----");
                Console.WriteLine("1 - Jogar:\n2 - Imprimir Lista de Vencedores\n3 - Sair");
                selecao = Console.ReadLine();
                int.TryParse(selecao, out opcao);
                if ((opcao < 1) || (opcao > 3))
                {
                    Console.WriteLine("Opcão inválida");
                    Console.WriteLine("Pressione ENTER para voltar...");
                    Console.ReadKey();
                }
                else
                {
                    flag = false;
                }
            } while (flag);
            return opcao;
        }
        static void Main(string[] args)
        {
            char[,] tabuleiro = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
            int opcao = 0, quantidadeDeJogadas = 0;
            bool flag = true;
            string nomePrimeiroJogador, nomeSegundoJogador;


            void ImprimirTabuleiro()
            {
                Console.Clear();
                Console.WriteLine("Tabuleiro de Jogo da Velha\n");
                Console.WriteLine($"     |     |      ");
                Console.WriteLine($"  {tabuleiro[0, 0]}  |  {tabuleiro[0, 1]}  |  {tabuleiro[0, 2]}");
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine($"  {tabuleiro[1, 0]}  |  {tabuleiro[1, 1]}  |  {tabuleiro[1, 2]}");
                Console.WriteLine("_____|_____|_____ ");
                Console.WriteLine("     |     |      ");
                Console.WriteLine($"  {tabuleiro[2, 0]}  |  {tabuleiro[2, 1]}  |  {tabuleiro[2, 2]}");
                Console.WriteLine("     |     |      ");

                Console.WriteLine("Opções de posicionamento: ");
                Console.WriteLine("1 - [0, 0]\n2 - [0, 1]\n3 - [0, 2]");
                Console.WriteLine("4 - [1, 0]\n5 - [1, 1]\n6 - [1, 2]");
                Console.WriteLine("7 - [2, 0]\n8 - [2, 1]\n9 - [2, 2]");
            }

            void VerificacaoNomeJogador()
            {
                Console.WriteLine("Insira o nome do primeiro jogador: ");
                nomePrimeiroJogador = Console.ReadLine();
                Console.WriteLine("Insira o nome do segundo jogador: ");
                nomeSegundoJogador = Console.ReadLine();
            }

            void InserirJogada()
            {
                bool ehOPrimeiroJogador = true;
                int linhaJogada, colunaJogada;
                quantidadeDeJogadas = 0;
                tabuleiro = new char[3, 3] { { '1', '2', '3' }, { '4', '5', '6' }, { '7', '8', '9' } };
                VerificacaoNomeJogador();
                while (quantidadeDeJogadas < 9)
                {
                    ImprimirTabuleiro();
                    Console.WriteLine("Jogada: " + (quantidadeDeJogadas + 1));
                    if (ehOPrimeiroJogador)
                    {
                        Console.WriteLine($"----- Jogador {nomePrimeiroJogador} 'X' -----");
                        do
                        {
                            Console.WriteLine("Qual linha deseja inserir a jogada: ");
                            linhaJogada = int.Parse(Console.ReadLine());
                        } while (linhaJogada < 0 || linhaJogada > 2);
                        do
                        {
                            Console.WriteLine("Qual coluna deseja inserir a jogada: ");
                            colunaJogada = int.Parse(Console.ReadLine());
                        } while (colunaJogada < 0 || colunaJogada > 2);
                        Console.WriteLine($"O jogador {nomePrimeiroJogador} inseriu um X na linha {linhaJogada} e coluna {colunaJogada} ");
                        if ((tabuleiro[linhaJogada, colunaJogada].CompareTo('X') != 0) && (tabuleiro[linhaJogada, colunaJogada].CompareTo('O') != 0))
                        {
                            tabuleiro[linhaJogada, colunaJogada] = 'X';
                            ehOPrimeiroJogador = false;
                            quantidadeDeJogadas++;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"----- Jogador {nomeSegundoJogador} 'O' -----");
                        do
                        {
                            Console.WriteLine("Qual linha deseja inserir a jogada: ");
                            linhaJogada = int.Parse(Console.ReadLine());
                        } while (linhaJogada < 0 || linhaJogada > 2);
                        do
                        {
                            Console.WriteLine("Qual coluna deseja inserir a jogada: ");
                            colunaJogada = int.Parse(Console.ReadLine());
                        } while (colunaJogada < 0 || colunaJogada > 2);
                        Console.WriteLine($"O jogador {nomeSegundoJogador} inseriu um O na linha {linhaJogada} e coluna {colunaJogada} ");
                        if ((tabuleiro[linhaJogada, colunaJogada].CompareTo('X') != 0) && (tabuleiro[linhaJogada, colunaJogada].CompareTo('O') != 0))
                        {
                            tabuleiro[linhaJogada, colunaJogada] = 'O';
                            ehOPrimeiroJogador = true;
                            quantidadeDeJogadas++;
                        }
                    }
                    VerificarVitoria();
                }
            }

            void VerificarVitoria()
            {
                int linha = 0;
                int coluna = 0;
                if (quantidadeDeJogadas >= 4)
                {
                    if (tabuleiro[linha, coluna].CompareTo(tabuleiro[linha, coluna + 1]) == 0 && tabuleiro[linha, coluna].CompareTo(tabuleiro[linha, coluna + 2]) == 0)
                    {
                        if (tabuleiro[linha, coluna] == 'X')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomePrimeiroJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                        else if (tabuleiro[linha, coluna] == 'O')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomeSegundoJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                    }
                    else if (tabuleiro[linha, coluna].CompareTo(tabuleiro[linha + 1, coluna]) == 0 && tabuleiro[linha, coluna].CompareTo(tabuleiro[linha + 2, coluna]) == 0)
                    {
                        if (tabuleiro[linha, coluna] == 'X')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomePrimeiroJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                        else if (tabuleiro[linha, coluna] == 'O')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomeSegundoJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                    }
                    else if (tabuleiro[linha, coluna].CompareTo(tabuleiro[linha + 1, coluna + 1]) == 0 && tabuleiro[linha, coluna].CompareTo(tabuleiro[linha + 2, coluna + 2]) == 0)
                    {
                        if (tabuleiro[linha, coluna] == 'X')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomePrimeiroJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                        else if (tabuleiro[linha, coluna] == 'O')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomeSegundoJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                    }
                    else if (tabuleiro[linha, coluna].CompareTo(tabuleiro[linha, coluna + 2]) == 0 && (tabuleiro[linha, coluna].CompareTo(tabuleiro[linha + 1, coluna + 1]) == 0) && (tabuleiro[linha, coluna].CompareTo(tabuleiro[linha + 2, coluna]) == 0))
                    {
                        if (tabuleiro[linha, coluna] == 'X')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomePrimeiroJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                        else if (tabuleiro[linha, coluna] == 'O')
                        {
                            Console.WriteLine($"Vitória do Jogador {nomeSegundoJogador}");
                            quantidadeDeJogadas = 10;
                            Console.ReadLine();
                        }
                    }
                    else if (quantidadeDeJogadas > 8)
                    {
                        Console.WriteLine("Empate");
                        Console.ReadLine();
                    }
                }
            }

            ImprimirTabuleiro();
            opcao = MenuPrincipal();
            do
            {
                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Jogo da Velha");
                        InserirJogada();
                        opcao = MenuPrincipal();
                        break;
                    case 2:
                        Console.WriteLine("Lista de Vencedores");
                        opcao = MenuPrincipal();
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Opcão inválida");
                        Console.WriteLine("Pressione ENTER para voltar...");
                        Console.ReadKey();
                        break;
                }
            } while (flag);
        }
    }
}
