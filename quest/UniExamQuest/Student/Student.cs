using System;

namespace UniExamQuest
{
    interface IStudent : IStoreBuyer, IActivityConsumer, IPlayer { }
    [Serializable]
    public class Student : IStudent
    {
        public int Health { get; set; }
        public int Satiation { get; set; }
        public int Happiness { get; set; }
        public int Mind { get; set; }
        public Inventory Inventory { get; set; }
        public string Name { get; set; }
        public int StipendSize { get; set; }
        public decimal Money { get; set; }
        public bool IsAlive => Health > 0;

        public Student(string name)
        {
            Name = name;
            Inventory = new Inventory();
        }
        public void GetStipend()
        {                
            Money += StipendSize;
        }

        public void BuyItem(Item item)
        {
            if (Money < item.Price)
            {
                Console.WriteLine("Not efficient money to buy " + item.Name);
            }
            else
            {
                Money -= item.Price;
                Inventory.Add(item);
            }
        }

        public void InteractWith(Activity activity)
        {
            if (IsAlive)
            {
                Happiness = normalizeValue(Happiness, activity.Happiness, 100);
                Satiation = normalizeValue(Satiation, activity.Satiation, 100);
                Health = normalizeValue(Health, activity.Health, 100);
                Mind = normalizeValue(Mind, activity.Mind);
            }
        }
        // move to GameState and read this values from settings
        private int normalizeValue(int prop, int update, int max = int.MaxValue)
        {
            if (prop + update > max)
                return max;
            if (prop + update < 0)
                return 0;
            return prop + update;
        }
    }
}
