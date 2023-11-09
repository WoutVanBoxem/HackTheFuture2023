using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AnimalChainBuilder
    {
        private Animal[] animals;

        public AnimalChainBuilder(Animal[] animals)
        {
            this.animals = animals;
        }

        public List<Animal> BuildChain()
        {
            List<Animal> chain = new List<Animal> { animals[0] };
            animals = animals.Where(animal => animal != animals[0]).ToArray();
            ExtendChain(chain, true); 
            ExtendChain(chain, false);

            return chain;
        }

        private void ExtendChain(List<Animal> chain, bool forward)
        {
            Animal current = forward ? chain.Last() : chain.First();

            while (animals.Any())
            {
                Animal next = FindNextAnimal(current);
                if (next != null)
                {
                    if (forward)
                    {
                        chain.Add(next);
                    }
                    else
                    {
                        chain.Insert(0, next);
                    }
                    animals = animals.Where(animal => animal != next).ToArray();
                    current = next;
                }
                else
                {
                    break;
                }
            }
        }

        private Animal FindNextAnimal(Animal current)
        {
            foreach (var animal in animals)
            {
                if (ShareCharacteristic(current, animal))
                {
                    return animal;
                }
            }
            return null;
        }

        private bool ShareCharacteristic(Animal a, Animal b)
        {

            return a.Species == b.Species ||
                   a.AgeInDays == b.AgeInDays ||
                   a.WeightInGrams == b.WeightInGrams ||
                   a.HeightInCm == b.HeightInCm;
        }
    }
}
