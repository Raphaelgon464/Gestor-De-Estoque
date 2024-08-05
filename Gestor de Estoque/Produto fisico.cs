using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor_de_Estoque
{

    [System.Serializable]
    class Produto_fisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public Produto_fisico(string nome, float preco, float frete) 
        {
            this.nome = nome; 
            this.preco = preco;
            this.frete = frete;
             
        
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saida no estoque do produto {nome}");
            Console.WriteLine("Digite a Quantidade que você quer dar baixa: ");
            int entrada =int.Parse( Console.ReadLine());
            estoque = entrada;
            Console.WriteLine("Saida registrada");
            Console.ReadLine();
        }

        public void AdiconarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a Quantidade que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"Nome:{nome}");
            Console.WriteLine($"Frete: {frete}");
            Console.WriteLine($"Preço:{preco}");
            Console.WriteLine($"Estoque:{estoque}");
            Console.WriteLine("===========================");
        }
    }
}
