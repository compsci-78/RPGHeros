using Microsoft.VisualStudio.TestPlatform.Utilities;
using RPGHeros.Enums;
using RPGHeros.Exceptions;
using RPGHeros.Heros;
using RPGHeros.Items;
using System.Threading;
using Xunit.Abstractions;

namespace RPGHerosTest.Heros
{
    
    public class WarriorTest
    {
        private readonly ITestOutputHelper output;
        public WarriorTest(ITestOutputHelper output)
        {
            this.output = output;
        }
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
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithNoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement            
            var expected = new HeroAttributes() { Strength = 5, Dexterity = 2, Intelligence = 1 };
            //Act
            var warrior = new Warrior("Warrior");
            var actual = warrior.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithOneEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 5, Dexterity = 2, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 6, Dexterity = 3, Intelligence = 2 };
            var armor = new Armor("Mail", 0, Slot.Body, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(armor);
            var actual = warrior.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithTwoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 5, Dexterity = 2, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 7, Dexterity = 4, Intelligence = 3 };
            var armor1 = new Armor("Plate", 0, Slot.Body, ArmorType.Plate, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Mail", 0, Slot.Head, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(armor1);
            warrior.Equip(armor2);
            var actual = warrior.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithReplacedEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 5, Dexterity = 2, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 6, Dexterity = 3, Intelligence = 2 };
            var armor1 = new Armor("Plate", 0, Slot.Body, ArmorType.Plate, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Mail", 0, Slot.Body, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(armor1);
            warrior.Equip(armor2);
            var actual = warrior.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithNoWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 5, Dexterity = 2, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalStrength / 100))
            //If no weapon weaponDamge = 1
            var expected = 1;
            //Act
            var warrior = new Warrior("Warrior");
            var actual = warrior.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 5, Dexterity = 2, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalStrength / 100))
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Axes", 0, Slot.Weapon, WeaponType.Axes, 2);
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(weapon);
            var actual = warrior.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithReplacedValidWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 5, Dexterity = 2, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalStrength / 100))
            //If no weapon weaponDamge = 1
            var expected = 3;
            var weapon1 = new Weapon("Axes", 0, Slot.Weapon, WeaponType.Axes, 2);
            var weapon2 = new Weapon("Hammers", 0, Slot.Weapon, WeaponType.Hammers, 3);
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(weapon1);
            warrior.Equip(weapon2);
            var actual = warrior.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeaponAndArmor_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 5, Dexterity = 2, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalStrength / 100))
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Hammers", 0, Slot.Weapon, WeaponType.Hammers, 2);
            var armor = new Armor("Mail", 0, Slot.Head, ArmorType.Mail, new HeroAttributes());
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(weapon);
            warrior.Equip(armor);

            var actual = warrior.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Display_DisplayingHeroStatus_ShouldReturnCorrectStatus()
        {
            //Arrangement                                    
            var weapon = new Weapon("Hammers", 0, Slot.Weapon, WeaponType.Hammers, 2);
            var armor = new Armor("Mail", 0, Slot.Head, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var warrior = new Warrior("Warrior");
            warrior.Equip(weapon);
            warrior.Equip(armor);
            warrior.LevelUp();

            var actual = warrior.Display();
            //Assertion
            output.WriteLine(actual.ToString());
        }

        #endregion
    }
}

