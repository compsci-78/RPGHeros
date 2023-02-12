using RPGHeros.Heros;

namespace RPGHerosTest.Heros
{
    public class RogueTest
    {
        [Fact]
        public void Rogue_CreatesRogueInstance_ShouldCreateRogueWithCorrectName()
        {
            //Arangement
            var name = "Rogue";
            var expected = "Rogue";
            //Act
            var rogue = new Rogue(name);
            var actual = rogue.Name;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Rogue_CreatesRogueInstance_ShouldCreateRogueWithCorrectLevel()
        {
            //Arangement
            var name = "Rogue";
            var expected = 1;
            //Act
            var rogue = new Rogue(name);
            var actual = rogue.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Rogue_CreatesRogueInstance_ShouldCreateRogueWithCorrectAttributes()
        {
            //Arangement
            var name = "Rogue";
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 6, Intelligence = 1 };
            //Act
            var rogue = new Rogue(name);
            var actual = rogue.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevel_ShouldIncrementLevel()
        {
            //Arangement
            var name = "Rogue";
            var expected = 2;
            //Act
            var rogue = new Rogue(name);
            rogue.LevelUp();
            var actual = rogue.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevelAttributes_ShouldIncrementLevelAttributes()
        {
            // 2 6 1 => Level 1                       
            // 1 4 1 => Adds to level 1 by LeveUp() method.

            //Arangement
            var name = "Rogue";
            var expected = new HeroAttributes() { Strength = 3, Dexterity = 10, Intelligence = 2 };
            //Act
            var rogue = new Rogue(name);
            rogue.LevelUp();
            var actual = rogue.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
    }
}