using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>()
            {
                new ContaCorrente(341, 87480),
                new ContaCorrente(342, 56734),
                new ContaCorrente(342, 00001),
                new ContaCorrente(342, 99999),
                new ContaCorrente(340, 29867),
                new ContaCorrente(290, 67453)
            };

            // contas.Sort(); ~~> Chama a implementação dada em IComparable

            contas.Sort(new ComparadorContaCorrentePorAgencia());

            foreach (var conta in contas)
            {
                Console.WriteLine($"Conta número {conta.Numero}, ag. {conta.Agencia}");
            }
            





            Console.ReadLine();
        }

        static void TestaSort()
        {

            //INFERÊNCIA DE TIPO DE VARIÁVEL:

            var conta = new ContaCorrente(345, 673452);
            var gerenciador = new GerenciadorBonificacao();
            var gerenciadores = new List<GerenciadorBonificacao>();

            conta.Depositar(3000);

            //var idade; - não compila, precisamos atribuir um valor à variável
            //para que o compilador entenda que "var" é do tipo int.
            var idade = 14;

            //idade = "catorze"; - não compila, pois a variável já foi declarada
            //como sendo do tipo int ao ser atribuído o valor 14 a ela.

            //var nome;
            var nome = "Bruno";


            var resultado = SomarVarios(1, 5, 9);












            var idades = new List<int>();

            //A lista 'idades' foi criada como sendo do tipo int.
            //Portanto, não poderá receber parâmetros de outros tipos.
            //idades.Adicionar("texto qualquer"); - NÃO COMPILA

            idades.Add(1);
            idades.Add(5);
            idades.Add(14);
            idades.Add(25);
            idades.Add(38);
            idades.Add(61);

            //idades.AddRange(new int[]{16, 18, 22, 40});
            //ListExtensoes.AdicionarVarios(idades, 16, 18, 22, 40);
            idades.AdicionarVarios(16, 18, 22, 40);

            //idades.Remove(5);

            idades.AdicionarVarios(99, -1);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }




            var nomes = new List<string>()
            {
                "Victor",
                "Bruno",
                "Marcelle",
                "Guilherme",
                "Ana"
            };

            nomes.Sort();

            foreach (var item in nomes)
            {
                Console.WriteLine(item);
            }
        }

        static void TesteLista()
        {
            Lista<int> idades = new Lista<int>();

            //A lista 'idades' foi criada como sendo do tipo int.
            //Portanto, não poderá receber parâmetros de outros tipos.
            //idades.Adicionar("texto qualquer"); - NÃO COMPILA

            idades.Adicionar(10);
            idades.AdicionarVarios(1, 5, 78);

            idades.Remover(5);

            for (int i = 0; i < idades.Tamanho; i++)
            {
                int idadeAtual = idades[i];
                Console.WriteLine(idadeAtual);
            }
        }

        static void TesteListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(5);
            listaDeIdades.Adicionar(4);
            listaDeIdades.AdicionarVarios(16, 23, 60);

            listaDeIdades.Remover(5);

            for (int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no índice {i}: {idade}");
            }





            //Console.WriteLine(SomarVarios(1, 2, 3, 4, 5, 6, 7, 8, 9));
            //Console.WriteLine(SomarVarios(1, 2, 3));
        }

        static void TesteListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDeBruno = new ContaCorrente(010101, 3654260);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDeBruno,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5546678)
            };

            lista.AdicionarVarios(contas);

            //A palavra chave 'params'escrita na criação do método faz com que
            //o AdicionarVarios primeiro crie uma array com os parâmetros inseridos
            //abaixo, para depois chamar o método como ele foi chamado acima.
            lista.AdicionarVarios(
                contaDeBruno,
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5679787)
                );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Agencia} / {itemAtual.Numero}");
            }

            //lista.EscreverListaNaTela();

            //lista.Remover(contaDeBruno);

            //Console.WriteLine("Após remover o item");
            //lista.EscreverListaNaTela();
        }

        static void TestaArrayDeContaCorrente()
        {

            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(874, 5679787),
                new ContaCorrente(874, 5546678),
                new ContaCorrente(874, 7781438)
            };


            for (int i = 0; i < contas.Length; i++)
            {
                Console.WriteLine($"Conta {i} {contas[i].Numero}");
            }
        }

        static void TestaArrayIndice()
        {
            //ARRAY de inteiros com 5 posições
            int[] idades = null;
            idades = new int[3];

            idades[0] = 15;
            idades[1] = 28;
            idades[2] = 35;
            //idades[3] = 50;
            //idades[4] = 28;
            //idades[5] = 60;

            Console.WriteLine(idades.Length);

            int acumulador = 0;
            for (int i = 0; i < idades.Length; i++)
            {
                int idade = idades[i];

                Console.WriteLine($"Acessando  o array idades no índice {i}");
                Console.WriteLine($"Valor de idades[{i}] = {idade}");

                acumulador += idade;
            }

            int media = acumulador / idades.Length;
            Console.WriteLine($"Média de idades = {media}");
        }

        //Outro exemplo do uso de params
        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach (int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }
    }
}