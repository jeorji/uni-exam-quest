using System;

namespace UniExamQuest
{
    interface IStudent : IStoreBuyer, IActivityConsumer, IPlayer { }

    public class Student : IStudent
    {
        /*
         *public class Property
         *{
         *    public string Name { get; set; }
         *    public int Value { get; set; }
         *    public Property(string name, int value)
         *    {
         *        Name = name;
         *        Value = value;
         *    }
         *    public Property() {}
         *}
         *public List<Property> Properties;
         */
        public int Health { get; set; }
        public int Satiation { get; set; }
        public int Happiness { get; set; }
        public int Mind { get; set; }

        public Inventory Inventory { get; set; }   // *** new
        public string Name { get; set; }
        public bool IsStudy { get; set; }
        public bool IsSick { get; set; }
        public bool IsAlive { get; set; }
        public int StipendSize { get; set; }
        public decimal Money { get; set; }

        public Student(string name)
        {
            IsAlive = true;
            Name = name;
            IsStudy = true; // *** new
            Inventory = new Inventory();
        }
        private Student()
        {
        }

        public void GetStipend()
        {
            if (IsStudy)
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
            if (Happiness + activity.Happiness >= 0)   // *** new
            {
                Happiness += activity.Happiness;
            }
            if (Satiation + activity.Satiation >= 0)
            {
                Satiation += activity.Satiation;
            }
            if (Mind + activity.Mind >= 0)
            {
                Mind += activity.Mind;
            }
            if (Health + activity.Health >= 0)
            {
                Health += activity.Health;
            }

            
        }
    }
}
