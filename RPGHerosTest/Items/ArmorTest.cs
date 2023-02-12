using RPGHeros.Enums;
using RPGHeros.Items;
using RPGHeros.Heros;

namespace RPGHerosTest.Items
{
    public class ArmorTest
    {
        [Fact]
        public void Armor_CreatesArmorInstance_ShouldCreateArmorWithCorrectName()
        {
            //Arangement
            var name = "Leather";
            var expected = "Leather";
            //Act
            var armor = new Armor(name, 0, Slot.Body, ArmorType.Leather, new HeroAttributes());
            var actual = armor.Name;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Armor_CreatesArmorInstance_ShouldCreateArmorWithCorrectRequiredLevel()
        {
            //Arangement            
            var expected = 2;
            //Act
            var armor = new Armor("Leather", expected, Slot.Body, ArmorType.Leather, new HeroAttributes());
            var actual = armor.RequiredLevel;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Armor_CreatesArmorInstance_ShouldCreateArmorWithCorrectSlot()
        {
            //Arangement            
            var expected = Slot.Body;
            //Act
            var armor = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes());
            var actual = armor.SlotType;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Armor_CreatesArmorInstance_ShouldCreateArmorWithCorrectArmorType()
        {
            //Arangement            
            var expected = ArmorType.Leather;
            //Act
            var armor = new Armor("Leather", 0, Slot.Body, expected , new HeroAttributes());
            var actual = armor.ArmorType;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Armor_CreatesArmorInstance_ShouldCreateArmorWithCorrectArmorAttribute()
        {
            //Arangement            
            var expected = new HeroAttributes() {Strength=1,Dexterity=1,Intelligence=1 };
            //Act
            var armor = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, expected);
            var actual = armor.ArmorAttribute;
            //Assertion
            Assert.Equal(expected, actual);
        }
    }
}
