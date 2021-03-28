using System;
using System.Collections.Generic;

namespace DependencyInjection
{
    public interface IPet
    {
        void Walk();
    }

    public class Dog : IPet
    {
        public void Walk()
        {
            Console.WriteLine("I'm so excited! I'm going for a walk!");
        }
    }

    public class Cat : IPet
    {
        public void Walk()
        {
            Console.WriteLine("Nope, I'm gonna nap...");
        }
    }

    public class Hamster : IPet
    {
        public void Walk()
        {
            Console.WriteLine("I don't walk!");
        }
    }


    public class PetWalker
    {
        readonly IEnumerable<IPet> _pets;

        public PetWalker(IEnumerable<IPet> pets)
        {
            _pets = pets;
        }

        public void WalkPets()
        {
            foreach (var pet in _pets)
            {
                pet.Walk();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var pets = new List<IPet>() { new Cat(), new Dog(), new Hamster() };

            var walker = new PetWalker(pets);
            walker.WalkPets();
            Console.Read();
        }
    }
}
