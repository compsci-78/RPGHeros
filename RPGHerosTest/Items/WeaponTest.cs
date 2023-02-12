using RPGHeros.Enums;
using RPGHeros.Items;

namespace RPGHerosTest.Items
{
    public class WeaponTest
    {
        [Fact]
        public void Weapon_CreatesWeaponInstance_ShouldCreateWeaponWithCorrectName()
        {
            //Arangement
            var name = "Swords";
            var expected = "Swords";
            //Act
            var weapon = new Weapon(name,0,Slot.Weapon,WeaponType.Swords,0);
            var actual = weapon.Name;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Weapon_CreatesWeaponInstance_ShouldCreateWeaponWithCorrectRequiredLevel()
        {
            //Arangement            
            var expected = 3;
            //Act
            var weapon = new Weapon("Swords", expected, Slot.Weapon, WeaponType.Swords, 0);
            var actual = weapon.RequiredLevel;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Weapon_CreatesWeaponInstance_ShouldCreateWeaponWithCorrectSlot()
        {
            //Arangement            
            var expected = Slot.Weapon;
            //Act
            var weapon = new Weapon("Swords", 0, expected, WeaponType.Swords, 0);
            var actual = weapon.SlotType;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Weapon_CreatesWeaponInstance_ShouldCreateWeaponWithCorrectWeaponType()
        {
            //Arangement            
            var expected = WeaponType.Swords;
            //Act
            var weapon = new Weapon("Swords", 0, Slot.Weapon, WeaponType.Swords, 0);
            var actual = weapon.WeaponType;
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Weapon_CreatesWeaponInstance_ShouldCreateWeaponWithCorrectDamage()
        {
            //Arangement            
            var expected = 5;
            //Act
            var weapon = new Weapon("Swords", 0, Slot.Weapon, WeaponType.Swords, 5);
            var actual = weapon.WeaponDamage;
            //Assertion
            Assert.Equal(expected, actual);
        }
    }
}
