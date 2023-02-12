using RPGHeros.Heros;

namespace RPGHerosTest.Heros
{
    public class WarriorTest
    {
        [Fact]
        public void Warrior_CreatesWarriorInstance_ShouldCreateWarriorWithCorrectName()
        {
            //Arangement
            var name = "Warrior";
            var expected = "Warrior";
            //Act
            var warrior = new Warrior(name);
            var actual = warrior.Name;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Warrior_CreatesWarriorInstance_ShouldCreateWarriorWithCorrectLevel()
        {
            //Arangement
            var name = "Warrior";
            var expected = 1;
            //Act
            var warrior = new Warrior(name);
            var actual = warrior.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Warrior_CreatesWarriorInstance_ShouldCreateWarriorWithCorrectAttributes()
        {
            //Arangement
            var name = "Warrior";
            var expected = new HeroAttributes() { Strength = 5, Dexterity = 2, Intelligence = 1 };
            //Act
            var warrior = new Warrior(name);
            var actual = warrior.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevel_ShouldIncrementLevel()
        {
            //Arangement
            var name = "Warrior";
            var expected = 2;
            //Act
            var warrior = new Warrior(name);
            warrior.LevelUp();
            var actual = warrior.Level;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void LevelUp_IncreasesHeroLevelAttributes_ShouldIncrementLevelAttributes()
        {
            // 5 2 1 => Level 1                       
            // 3 2 1 => Adds to level 1 by LeveUp() method.

            //Arangement
            var name = "Warrior";
            var expected = new HeroAttributes() { Strength = 8, Dexterity = 4, Intelligence = 2 };
            //Act
            var warrior = new Warrior(name);
            warrior.LevelUp();
            var actual = warrior.LevelAttributes;
            //Assertion
            Assert.Equal(expected, actual);
        }
    }
}

