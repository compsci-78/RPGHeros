using RPGHeros.Heros;


namespace RPGHerosTest.Heros
{
    public class RangerTest
    {
        [Fact]
        public void Ranger_CreatesRangerInstance_ShouldCreateRangerWithCorrectName()
        {
            //Arangement
            var name = "Ranger";
            var expected = "Ranger";
            //Act
            var ranger = new Ranger(name);
            var actual = ranger.Name;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Ranger_CreatesRangerInstance_ShouldCreateRangerWithCorrectLevel()
        {
            //Arangement
            var name = "Ranger";
            var expected = 1;
            //Act
            var ranger = new Ranger(name);
            var actual = ranger.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Ranger_CreatesRangerInstance_ShouldCreateRangerWithCorrectAttributes()
        {
            //Arangement
            var name = "Ranger";
            var expected = new HeroAttributes() { Strength = 1, Dexterity = 7, Intelligence = 1 };
            //Act
            var ranger = new Ranger(name);
            var actual = ranger.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevel_ShouldIncrementLevel()
        {
            //Arangement
            var name = "Ranger";
            var expected = 2;
            //Act
            var ranger = new Ranger(name);
            ranger.LevelUp();
            var actual = ranger.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevelAttributes_ShouldIncrementLevelAttributes()
        {
            // 1 7 1 => Level 1                       
            // 1 5 1 => Adds to level 1 by LeveUp() method.

            //Arangement
            var name = "Ranger";
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 12, Intelligence = 2 };
            //Act
            var ranger = new  Ranger(name);
            ranger.LevelUp();
            var actual = ranger.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
    }
}

