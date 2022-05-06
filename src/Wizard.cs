using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeros
{
    class Wizard : Hero, ISpecialAttack
    {
        public Wizard(string name, int fullhp, Colors color, int fullfirstaidkits) : base(name, fullhp, color, fullfirstaidkits)
        {

        }

        // Zwykły atak postaci
        public override void DefaultAttack(Hero hero)
        {
            int hp = rnd.Next(100, 151);
            hero.ActualHP -= hp;
            Console.WriteLine($"\nGracz {Name} zadał {hp} punktów obrażeń graczowi {hero.Name}.");
        }

        // Zwykły atak postaci

        // Leczenie postaci
        public override void Heal()
        {
            int hp = rnd.Next(150, 251);
            ActualHP += hp;
            Console.WriteLine($"\nGracz o nazwie {Name} uzdrowił się o {hp} punktów życia.");
        }

        // Atak Specjalny
        public void SpecialAttack(Hero hero)
        {
            int hp = rnd.Next(200, 251);
            hero.ActualHP -= hp;
            Console.WriteLine($"\nGracz {Name} użył swojego specjalnego ataku i zadał {hp} punktów obrażeń graczowi {hero.Name}.");
        }
        // Leczenie postaci

    }
}
