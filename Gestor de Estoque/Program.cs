using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{
   
    internal class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu {Listar = 1, Adiconar, Remover, Entrada, Saida, Sair}
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (escolheuSair == false)
            {
                Console.WriteLine("Sistema de Estoque");
                Console.WriteLine("1-Listar\n2-Adiconar\n3-Remover\n4-Registrar entrada\n5-Registrar saida\n6-Sair");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if (opInt > 0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adiconar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;
                        case Menu.Sair:
                            escolheuSair = true;
                            break;

                    }
                }
                else
                {
                    escolheuSair = true;
 
                }
                Console.Clear();
            }
           
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de produtos");
            int i = 0;
            foreach(IEstoque produto in produtos) 
            {
                Console.WriteLine("ID:" + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer remover: ");
            int id = int.Parse (Console.ReadLine());
            if(id >= 0 && id < produtos.Count) 
            {
                produtos.RemoveAt(id);
                Salvar();
            } 
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdiconarEntrada();
                Salvar();
            }
        }
        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa: ");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }

        enum Menu2 {Produto = 1,Ebook = 2 , curso = 3 }
        static void Cadastro() 
        {
            Console.WriteLine("cadastro de produto");
            Console.WriteLine("1-produto Fisico\n2-Ebook\n3-curso");
            string opStr = Console.ReadLine();
            int opInt = int.Parse(opStr);

            Menu2 escolha = (Menu2)opInt;
            switch(escolha)
            {
               case Menu2.Produto:
                   CadastrarPFisico();
                   break;
               case Menu2.Ebook:
                    CadastrarEbook();
                    break;
               case Menu2.curso:
                    CadastrarCurso();
                    break;

            }

        }
    
        static void CadastrarPFisico() 
        {
            Console.WriteLine("Cadastrando produto fisico:");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete:");
            float frete = float.Parse(Console.ReadLine());
            Produto_fisico pf = new Produto_fisico(nome,preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando Ebook:");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor:"); 
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Ebook:");
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Console.WriteLine("Preço:");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor:");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar() 
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();

        }

        static void Carregar() 
        {
            FileStream stream = new FileStream("Produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

           
            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque>();    
                }

            }
            catch (Exception e)
            {
                produtos = new List<IEstoque>();

            }
            
            stream.Close ();

        }

    }
}
