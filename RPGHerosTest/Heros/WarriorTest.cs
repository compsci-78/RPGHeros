using RPGHeros.Enums;
using RPGHeros.Exceptions;
using RPGHeros.Heros;
using RPGHeros.Items;

namespace RPGHerosTest.Heros
{
    
    public class WarriorTest
    {
        #region Creation
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
        #endregion

        #region Methods
        [Fact]
        public void Equip_EquippingHeroWithItems_ShouldEquipHeroWithCorrectWeapon()
        {
            //Arrangement
            var weaponSlot = Slot.Weapon;
            var expected = new Weapon("Axe", 0, weaponSlot, WeaponType.Axes, 0);
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(expected);
            var actual = warrior.Equipment[weaponSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Axe", 3, Slot.Weapon, WeaponType.Axes, 0);
            //Act
            var warrior = new Warrior("Warrior");
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(() => warrior.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidWeaponType_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Staffs, 0);
            //Act
            var warrior= new Warrior("Warrior");
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(() => warrior.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItems_ShouldEquipHeroWithCorrectArmor()
        {
            //Arrangement
            var armorSlot = Slot.Body;
            var expected = new Armor("Mail", 0, armorSlot, ArmorType.Mail, new HeroAttributes());
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(expected);
            var actual = warrior.Equipment[armorSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Mail", 3, Slot.Body, ArmorType.Mail, new HeroAttributes());
            //Act
            var warrior = new Warrior("Warrior");
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => warrior.Equip(armorWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidArmorType_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Cloth", 0, Slot.Body, ArmorType.Cloth, new HeroAttributes());
            //Act
            var warrior = new Warrior("Warrior");
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => warrior.Equip(armorWithRequiredLevel));
        }
        #endregion
    }
}

