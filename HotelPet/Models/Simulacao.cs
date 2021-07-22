using Hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelPet.Models
{
    public class Simulacao
    {
        public HotelInfo Hotel { get; set; }
        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
        public int QntsDias { get; set; }
        public double ValorTotal { get; private set; }

        public Simulacao()
        {

        }

        public Simulacao(int qntsDias, HotelInfo hotel, ICollection<Pet> pets)
        {
            QntsDias = qntsDias;
            Hotel = hotel;
            Pets = pets;
        }
        public double Calcular()
        {
             ValorTotal = Hotel.Preco;

            foreach (var p in Pets)
            {
                //RECUPERANDO O TAMANHO E FAZENDO UM CAST PARA O INT:
                int tamanho = (int)p.Tamanho;

                if (tamanho == 0) //Pequeno
                {
                    ValorTotal += 5; //TAXA
                }
                else if (tamanho == 1) //Medio
                {
                    ValorTotal += 15; //TAXA
                }
                else //Grande
                {
                    ValorTotal += 30; //TAXA
                }
            }
            return ValorTotal *= QntsDias;
        }

    }
}
