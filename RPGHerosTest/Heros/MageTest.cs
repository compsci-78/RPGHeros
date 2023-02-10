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
            var expected = new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 8 };
            //Act
            var mage = new Mage(name);
            var actual = mage.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevel_ShouldIncrementLevel() 
        {
            //Arangement
            var name = "Mage";
            var expected = 2;
            //Act
            var mage = new Mage(name);
            mage.LevelUp();
            var actual = mage.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevelAttributes_ShouldIncrementLevelAttributes()
        {                        
            // 1 1 8 => Level 1                       
            // 1 1 5 => Adds to level 1 by LeveUp() method.

            //Arangement
            var name = "Mage";
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 2 ,Intelligence=13 };
            //Act
            var mage = new Mage(name);
            mage.LevelUp();
            var actual = mage.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
    }
}