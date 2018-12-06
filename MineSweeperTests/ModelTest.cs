using MineSweeper;
using NUnit.Framework;
using View = MineSweeper.View;

namespace MineSweeperTests
{
    [TestFixture]
    public class ModelTest
    {
        [TestCase("Easy", 10, 10)]
        [TestCase("Medium", 40, 20)]
        [TestCase("Hard", 90, 30)]
        public void CreateRulesTest(string level, int value, int gameButtons)
        {
            var test = new Model(new Controller(new View()));
            test.LoadGame(level);

            Assert.AreEqual(test.BombsCount, value);
            Assert.AreEqual(test.FlagsCount, value);
            Assert.AreEqual(test.GameButtons.GetLength(0), gameButtons);
            Assert.AreEqual(test.GameButtons.GetLength(1), gameButtons);
        }
    }
}
