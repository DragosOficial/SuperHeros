﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHeros
{
    class Knight : Hero, IFirstAidKit
    {
        public Knight(string name, int fullhp, Colors color, int fullfirstaidkits) : base(name, fullhp, color, fullfirstaidkits)
        {

        }

        // Zwykły atak postaci
        public override void DefaultAttack(Hero hero)
        {
            int hp = rnd.Next(50, 201);
            hero.ActualHP -= hp;
            Console.WriteLine($"\nGracz {Name} zadał {hp} punktów obrażeń graczowi {hero.Name}.");
        }

        public void FirstAidKit()
        {
            FullFirstAidKits = 1;
            ActualFirstAidKits = 1;
            if (ActualFirstAidKits > 0)
            {
                int hp = rnd.Next(150, 251);
                ActualHP += hp;
                Console.WriteLine($"\nGracz o nazwie {Name} użył apteczki i uzdrowił się o {hp} punktów życia.");
            }
            else if (ActualFirstAidKits <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nie posiadasz już żadnych apteczek!");
                Console.ResetColor();
            }
        }

        // Zwykły atak postaci

        // Leczenie postaci
        public override void Heal()
        {
            int hp = rnd.Next(50, 101);
            ActualHP += hp;
            Console.WriteLine($"\nGracz o nazwie {Name} uzdrowił się o {hp} punktów życia.");
        }
        // Leczenie postaci
    }
}
