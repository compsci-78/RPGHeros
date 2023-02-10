using RPGHeros.Heros;

namespace RPGHerosTest.Heros
{
    public class MageTest
    {
        [Fact]
        public void Mage_CreatesMageInstance_ShouldCreateMageWithCorrectName()
        {
            //Arangement
            var name = "Mage";
            var expected = "Mage";
            //Act
            var mage = new Mage(name);
            var actual = mage.Name;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Mage_CreatesMageInstance_ShouldCreateMageWithCorrectLevel()
        {
            //Arangement
            var name = "Mage";
            var expected = 1;
            //Act
            var mage = new Mage(name);
            var actual = mage.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Mage_CreatesMageInstance_ShouldCreateMageWithCorrectAttributes()
        {
            //Arangement
            var name = "Mage";
            var expectedLevelAttribute = new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 8 };
            //Act
            var mage = new Mage(name);
            var actualLevelAttribute = mage.LevelAttributes;
            //Assertion
            Assert.Equal(expectedLevelAttribute, actualLevelAttribute);
        }
    }
}