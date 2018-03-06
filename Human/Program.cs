using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            human person = new human("Dima");
            human enemy = new human("Akin");
            Console.WriteLine(person.name + " health = " + person.health);
            Console.WriteLine(enemy.name + " health = " + enemy.health);
            person.attack(enemy);
             Console.WriteLine("After the attack...");
            Console.WriteLine(person.name + " health = " + person.health);
            Console.WriteLine(enemy.name + " health = " + enemy.health);
        }
    }
}
