using System;
using System.Collections.Generic;
using System.Text;

namespace UniExamQuest
{
    class Student
    {
        private int health;
        private bool study;
        private int money;
        private int mind;
        private int happiness;
        public Student()
        {
            health = 80;
            study = false;
            mind = 50;
            money = 5000;
            happiness = 70;
        }
        public void Get_sick()
        {
            health -= 30;
            happiness -= 10;
        }
        public void Get_well()
        {
            health += 25;
            happiness += 15;
        }
        public void Get_money_from_work()
        {
            money += 10000;
            happiness += 20;
        }
        public void Get_stipend()
        {
            money += 5000;
            happiness += 30;
        }
        public void Get_money_from_parents()
        {
            money += 7000;
            happiness += 30;
        }
        public void buy_food()
        {
            money -= 2000;
            happiness += 5;
        }
        public void go_to_club()
        {
            money -= 1500;
            health -= 10;
            happiness += 50;
            mind -= 5;
        }
        public void buy_medicine()
        {
            money -= 2000;
            health += 10;

        }
        public void prepare_to_exam()
        {
            mind += 30;
            health -= 3;
            happiness -= 10;
        }
        public void go_to_work()
        {
            happiness -= 10;
            health -= 10;
            mind += 5;
        }
        public void take_part_in_concerts()
        {
            happiness += 40;

        }
        public void go_to_lecture()
        {
            happiness -= 40;
            health -= 5;
            mind += 20;
        }

    }
}
