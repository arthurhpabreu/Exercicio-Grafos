using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Exercicio_Pratico_1
{
    class Program
    {
        public class Grafo
        {

            public int[,] matriz;
            public int nvertice;

            public Grafo()
            {
            }
            public void CarregarNaoDirigido(string arquivo)
            {
                string linha;

                using (StreamReader file = new StreamReader(arquivo))
                {
                    linha = file.ReadLine();
                    this.nvertice = int.Parse(linha);
                    this.matriz = new int[nvertice, nvertice];

                    for (int x = 0; x < nvertice; x++)
                    {
                        for (int y = 0; y < nvertice; y++)
                        {
                            matriz[x, y] = 0;
                        }
                    }

                    while (!(file.EndOfStream))
                    {
                        linha = file.ReadLine();
                        string[]temp = linha.Split(';');
                        
                        matriz[(int.Parse(temp[0])-1),(int.Parse(temp[1])-1)] = int.Parse(temp[2]);
                    }

                }

            }
            public void CarregarDirigido(string arquivo)
            {
                string linha;

                using (StreamReader file = new StreamReader(arquivo))
                {
                    linha = file.ReadLine();
                    this.nvertice = int.Parse(linha);
                    this.matriz = new int[nvertice, nvertice];

                    for (int x = 0; x < nvertice; x++)
                    {
                        for (int y = 0; y < nvertice; y++)
                        {
                            matriz[x, y] = 0;
                        }
                    }

                    while (!file.EndOfStream)
                    {
                        linha = file.ReadLine();
                        string[] temp = linha.Split(';');

                        if (int.Parse(temp[3]) < 0)
                        {
                            matriz[(int.Parse(temp[1])-1), (int.Parse(temp[0])-1)] = int.Parse(temp[2]);
                        }
                        else
                        {
                            matriz[(int.Parse(temp[0])-1),(int.Parse(temp[1])-1)] = int.Parse(temp[2]);
                        }
                    }

                }
            }
            public bool isAdjacente(int x, int y)
            {
                x = x - 1;
                y = y - 1;

                if (matriz[x, y] != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        
           public int getGrau(int vertice)
            {
                vertice = vertice - 1;
                int contador = 0;
                for(int x = 0; x < nvertice; x++)
                {
                    if(matriz[vertice, x] > 0 || matriz[x,vertice] > 0)
                    {
                        contador++;
                    }
                }
                return contador;
            }
            public bool isIsolado(int vertice)
            {
                vertice = vertice - 1;
                int contador = 0;
                for (int x = 0; x < nvertice; x++)
                {
                    if (matriz[vertice, x] > 0 || matriz[x, vertice] > 0)
                    {
                        contador++;
                    }
                }
               if(contador == 0)
                {
                    return true;
                }
               else
                {
                    return false;
                }
            }
            public bool isPendente(int vertice)
            {
                vertice = vertice - 1;
                int contador = 0;
                for (int x = 0; x < nvertice; x++)
                {
                    if (matriz[vertice, x] > 0 || matriz[x,vertice] > 0)
                    {
                        contador++;
                    }
                }
                if (contador == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool isRegular()
            {

              int contador = 0;
              bool teste = true;
              int parametro = 0;

              for(int x = 0; x < nvertice; x++)
                {
                    for(int y = 0; y < nvertice;y++)
                    {
                            if (matriz[(nvertice-1), x] > 0 || matriz[x,(nvertice-1)] > 0)
                            {
                                contador++;

                                if (y == nvertice - 1)
                                {
                                    if (parametro == 0)
                                    {
                                        parametro = contador;
                                    }
                                    else
                                    { 
                                        if (parametro != contador)
                                        {
                                            teste = false;
                                        }
                                        else
                                        {
                                            teste = teste && true;
                                        }
                                    }
                                    contador = 0;
                                }
                            } 
                    }
                }
                return teste;
            }
            public bool isNulo()
            {
                int contador = 0;

                for (int x = 0; x < nvertice; x++)
                {
                    for (int y = 0; y < nvertice; y++)
                    {
                        if (matriz[x, y] > 0 || matriz[y,x] > 0)
                        {
                            contador++;
                        }
                    }
                }
                if (contador == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public bool isCompleto()
            {
                int contador = 0;
                bool teste = true;

                for (int x = 0; x < nvertice; x++)
                {
                    for (int y = 0; x < nvertice; x++)
                    {
                        
                            if (matriz[x, y] > 0 || matriz[y,x] >0 )
                            {
                                contador++;

                                if (y == nvertice-1)
                                {
                                    if (contador == (nvertice - 1))
                                    {
                                        teste = teste && true;
                                    }
                                    else
                                    {
                                        teste = false;
                                    }
                                }
                            }
                    }
                }
                return teste;
            }
            public bool isConexo()
            {
                int contador = 0;
                bool teste = true;

                for (int x = 0; x < nvertice; x++)
                {
                    for (int y = 0; y < nvertice; y++)
                    {
                        if (matriz[x, y] > 0)
                        {
                            contador++;

                            if(y == nvertice-1)
                            {
                                if(contador > 0)
                                {
                                    teste = teste && true;
                                }
                                else
                                {
                                    teste = false;
                                }

                                contador = 0;  
                            }

                        }
                    }
                }
                return teste;
            }
             public Grafo getComplementar()
            {
                int[,] complementar = new int[nvertice, nvertice];
                Random random = new Random();
                for (int x = 0; x < nvertice; x++)
                {
                    for (int  y = 0; y < nvertice; y++)
                    {
                        if (matriz[x, y] == 0)
                        {
                            complementar[x,y] = random.Next(1, 9);
                        }
                    }
                }
                Grafo grafocomplementar = new Grafo();
                grafocomplementar.matriz = complementar;
                grafocomplementar.nvertice = nvertice;
                grafocomplementar.PrintMatrizGrafo();

                return grafocomplementar;
            }
            public int getGrauEntrada(int x)
            {
                x = x - 1;
                int contador = 0;

                for(int y = 0; y < nvertice; y++)
                {
                    if(matriz[y,x] > 0)
                    {
                        contador++;
                    }
                }
                return contador;
            }
            public int getGrauSaida(int x)
            {
                x = x - 1;
                int contador = 0;

                for (int y = 0; y < nvertice; y++)
                {
                    if (matriz[x,y] > 0)
                    {
                        contador++;
                    }
                }
                return contador;
            }
            public void PrintMatrizGrafo()
            {
                for (int x = 0; x < nvertice; x++)
                {
                    for (int y = 0; y < nvertice; y++)
                    {
                        if (y == nvertice-1)
                        {
                            Console.WriteLine(" " + matriz[x,y]);
                        }
                        else
                        {
                            Console.Write(" " + matriz[x,y]);
                        }
                    }
                }
            }
           
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Selecione: \n 1-Grafo nao-dirigido \n 2-Grafo dirigido \n 3-Fechar ");
            string opcao1 = Console.ReadLine();
            int opcao2 = 0;
            Grafo matriz = new Grafo();
            Console.Clear();
            int a, b;
            if (opcao1 == "1")
            {
                while (opcao2 != 10)
                {
                    Console.WriteLine("Matriz de Adjacência:");
                    matriz.CarregarNaoDirigido("arquivo.txt");
                    matriz.PrintMatrizGrafo();
                    Console.WriteLine();
                    Console.WriteLine("OS VÉRTICES SÃO AS POSIÇOES DA MATRIZ, NAO COMEÇA EM 1, COMEÇA EM 0 \n");

                    Console.WriteLine("Menu \n 1-Verificar se os vértices são adjacentes \n 2-Grau do vertice \n 3-Verificar se o vertice é isolado \n 4-Verificar se o vertice é pendente \n 5-Verificar se o Grafo é regular \n 6-Verificar se o Grafo é nulo \n 7-Verificar se o Grafo é completo \n 8-Verificar se o Grafo é Conexo \n 9-Mostrar Grafo complementar \n 10-Sair");
                    opcao2 = int.Parse(Console.ReadLine());

                    switch (opcao2)
                    {
                        case 1:

                            Console.WriteLine("Entre com o 1º vertice:");
                            a = int.Parse(Console.ReadLine());
                            Console.WriteLine("Entre com o 2º vertice:");
                            b = int.Parse(Console.ReadLine());
                            if (matriz.isAdjacente(a,b) == true)
                            {
                                Console.WriteLine("São vertices adjacentes");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Nao são vertices adjacentes");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 2:
                            Console.WriteLine("Entre com o vertice desejado:");
                            a = int.Parse(Console.ReadLine());
                            Console.WriteLine("Vertice de grau " + matriz.getGrau(a));
                            Console.WriteLine("Aperte Enter para voltar");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Console.WriteLine("Entre com o vertice desejado:");
                            a = int.Parse(Console.ReadLine());
                            if (matriz.isIsolado(a))
                            {
                                Console.WriteLine("Vertice é Isolado");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Vertice nao é Isolado");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 4:
                            Console.WriteLine("Entre com o vertice desejado:");
                            a = int.Parse(Console.ReadLine());
                            if (matriz.isPendente(a))
                            {
                                Console.WriteLine("Vertice é pendente");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Vertice nao é pendente");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 5:

                            if (matriz.isRegular())
                            {
                                Console.WriteLine("Grafo é Regular");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Grafo nao é Regular");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 6:
                            if (matriz.isNulo())
                            {
                                Console.WriteLine("Grafo é Nulo");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Grafo nao é Nulo");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;

                        case 7:
                            if (matriz.isCompleto())
                            {
                                Console.WriteLine("Grafo é Completo");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Grafo nao é Completo");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 8:
                            if (matriz.isConexo())
                            {
                                Console.WriteLine("Grafo é Conexo");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Grafo nao é conexo");
                                Console.WriteLine("Aperte Enter para voltar");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            break;
                        case 9:
                            Grafo Complementar = new Grafo();
                            Complementar = matriz.getComplementar();
                            Console.WriteLine("Aperte Enter para voltar");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 10:
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                           
                    }
                }
            }
            else if (opcao1 == "2")
            {
                while(opcao2 != 3)
                {
                Console.WriteLine("Matriz de Adjacência:");
                matriz.CarregarDirigido("arquivo2.txt");
                matriz.PrintMatrizGrafo();
                Console.WriteLine();
                Console.WriteLine("OS VÉRTICES SÃO AS POSIÇOES DA MATRIZ, NAO COMEÇA EM 1, COMEÇA EM 0 \n");
                Console.WriteLine("Selecione: \n 1-Grau de entrada do vertice \n 2-Grau de saída do vertice \n 3-Sair");
                opcao2 = int.Parse(Console.ReadLine());

                    switch (opcao2)
                    {
                        case 1:
                            Console.WriteLine("Entre com o vertice desejado:");
                            a = int.Parse(Console.ReadLine());
                            Console.WriteLine("Vertice possui grau de entrada " + matriz.getGrauEntrada(a));
                            Console.WriteLine("Aperte Enter para voltar");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 2:
                            Console.WriteLine("Entre com o vertice desejado:");
                            a = int.Parse(Console.ReadLine());
                            Console.WriteLine("Vertice possui grau de saída " + matriz.getGrauSaida(a));
                            Console.WriteLine("Aperte Enter para voltar");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
            else if (opcao1 == "3")
            {
                Environment.Exit(0);
            }

            
        }
    }
}
