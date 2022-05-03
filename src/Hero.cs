using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeros
{
    // Dostępne kolotry w enumie
    enum Colors
    {
        red, green, yellow
    }
    // Dostępne kolotry w enumie

    // Interfejs odpowiedzialny za atak specjalny
    interface ISpecialAttack
    {
        void SpecialAttack(Hero hero);
    }
    // Interfejs odpowiedzialny za atak specjalny

    // Interfejs odpowiedzialny za apteczke wojskową
    interface IFirstAidKit
    {
        void FirstAidKit();
    }
    // Interfejs odpowiedzialny za apteczke wojskową

    // Klasa Hero odpowiada za dziedziczenie(Umożliwia tworzenie bohaterów z potrzebymi informacjami)
    abstract class Hero
    {
        public string Name { get; }
        public int FullHP { get; }
        public int ActualFirstAidKits;
        public int FullFirstAidKits;
        private int actualHP;

        public int ActualHP
        {
            get { return actualHP; }
            set 
            {
                if (value < 0)
                {
                    actualHP = 0;
                }
                else if (value > FullHP)
                {
                    actualHP = FullHP;
                }
                else
                {
                    actualHP = value;
                }
            }
        }
        // Klasa Hero odpowiada za dziedziczenie(Umożliwia tworzenie bohaterów z potrzebymi informacjami)

        public Colors Color { get; set; }

        protected Random rnd = new Random();

        public bool UsedSpecialAttack { get; set; } = false;
        public bool UsedAttackBlock { get; set; } = false;
        // Funkcja z wymaganymi informacjami bohatera
        public Hero(string name, int fullhp, Colors color, int fullfirstaidkits)
        {
            Name = name;
            FullHP = fullhp;
            ActualHP = FullHP;
            Color = color;
            FullFirstAidKits = fullfirstaidkits;
            ActualFirstAidKits = FullFirstAidKits;
        }
        // Funkcja z wymaganymi informacjami bohatera

        public abstract void DefaultAttack(Hero hero);
        public abstract void Heal();
        //public abstract void FirstAidKit();

        public override string ToString()
        {
            return $"{Name} - {ActualHP}/{FullHP} hp";
        }
    }
}
