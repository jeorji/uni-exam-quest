using UniExamQuest;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestBuyStudent1()
        {
            Student student = new Student("Ivanov");
            student.BuyItem(new Item("Bread", 30));
            Assert.AreEqual(0, student.Money);
            Assert.AreEqual(0, student.Inventory.Content.Count);
        }

        [TestMethod]
        public void TestBuyStudent2()
        {
            Student student = new Student("Ivanov");
            student.Money = 70;

            student.BuyItem(new Item("Bread", 30));
            Assert.AreEqual(40, student.Money);
            Assert.AreEqual(1, student.Inventory.Content.Count);

            student.BuyItem(new Item("Butter", 41));
            Assert.AreEqual(40, student.Money);
            Assert.AreEqual(1, student.Inventory.Content.Count);
        }

        [TestMethod]
        public void TestMakeQuestHealth()
        {
            Student student = new Student("Ivanov");
            student.Health = 50;

            Quest quest = new Quest("Exams", Quest.QuestType.UNIVERSIRTY);
            quest.Health = -10;

            student.InteractWith(quest);

            Assert.AreEqual(40, student.Health);
        }

        [TestMethod]
        public void TestMakeQuestMind()
        {
            Student student = new Student("Ivanov");
            student.Mind = 50;

            Quest quest = new Quest("Exams", Quest.QuestType.UNIVERSIRTY);
            quest.Mind = +10;

            student.InteractWith(quest);

            Assert.AreEqual(60, student.Mind);
        }

        [TestMethod]
        public void TestMakeQuestHappiness()
        {
            Student student = new Student("Ivanov");
            student.Happiness = 50;

            Quest quest = new Quest("Exams", Quest.QuestType.WORK);
            quest.Happiness = -10;

            student.InteractWith(quest);

            Assert.AreEqual(40, student.Happiness);
        }
        [TestMethod]
        public void TestStudentPlayGame()
        {
            Student student = new Student("Ivanov");
            student.StipendSize = 100;
            GameSettings settings = new GameSettings();
            settings.DailySatiationChange = 5;
            settings.DailyHealthChange = 2;
            settings.DailyMindChange = -1;
            settings.DailyHappinesChange = 1;
            settings.StipendPayoutFrequency = 5;

            GameState game = new UniExamQuest.GameState();
            game.Player = student;
            game.Settings = settings;

            game.NextDay();
            Assert.AreEqual(5, student.Satiation);
            Assert.AreEqual(2, student.Health);
            Assert.AreEqual(0, student.Mind);
            Assert.AreEqual(1, student.Happiness);
            Assert.AreEqual(100, student.Money);

            game.NextDay();
            game.NextDay();
            game.NextDay();
            game.NextDay();
            Assert.AreEqual(100, student.Money);
            game.NextDay();
            Assert.AreEqual(200, student.Money);

        }

    }
}