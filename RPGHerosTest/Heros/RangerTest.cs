using RPGHeros.Enums;
using RPGHeros.Exceptions;
using RPGHeros.Heros;
using RPGHeros.Items;
using System;
using Xunit.Abstractions;

namespace RPGHerosTest.Heros
{
    public class RangerTest
    {
        private readonly ITestOutputHelper output;
        public RangerTest(ITestOutputHelper output)
        {
            this.output = output;
        }

        #region Creation
        [Fact]
        public void Ranger_CreatesRangerInstance_ShouldCreateRangerWithCorrectName()
        {
            //Arrangement
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
            //Arrangement
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
            //Arrangement
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
            //Arrangement
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

            //Arrangement
            var name = "Ranger";
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 12, Intelligence = 2 };
            //Act
            var ranger = new  Ranger(name);
            ranger.LevelUp();
            var actual = ranger.LevelAttributes;
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
            var expected = new Weapon("Bows", 0, weaponSlot, WeaponType.Bows, 0);
            //Act
            var ranger = new Ranger("Ranger");
            ranger.Equip(expected);
            var actual = ranger.Equipment[weaponSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Bows", 3, Slot.Weapon, WeaponType.Bows, 0);
            //Act
            var ranger = new Ranger("Ranger");
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(() => ranger.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidWeaponType_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Staffs, 0);
            //Act
            var ranger = new Ranger("Ranger");
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(() => ranger.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItems_ShouldEquipHeroWithCorrectArmor()
        {
            //Arrangement
            var armorSlot = Slot.Body;
            var expected = new Armor("Leather", 0, armorSlot, ArmorType.Leather, new HeroAttributes());
            //Act
            var ranger = new Ranger("Ranger");
            ranger.Equip(expected);
            var actual = ranger.Equipment[armorSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Leather", 3, Slot.Body, ArmorType.Cloth, new HeroAttributes());
            //Act
            var ranger = new Ranger("Ranger");
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => ranger.Equip(armorWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidArmorType_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Cloth", 0, Slot.Body, ArmorType.Cloth, new HeroAttributes());
            //Act
            var ranger = new Ranger("Ranger");
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => ranger.Equip(armorWithRequiredLevel));
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithNoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement            
            var expected = new HeroAttributes() { Strength = 1, Dexterity = 7, Intelligence = 1 };
            //Act
            var ranger = new Ranger("Ranger");
            var actual = ranger.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithOneEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 1, Dexterity = 7, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 8, Intelligence = 2 };
            var armor = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var ranger = new Ranger("Ranger");
            ranger.Equip(armor);
            var actual = ranger.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithTwoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 1, Dexterity = 7, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 3, Dexterity = 9, Intelligence = 3 };
            var armor1 = new Armor("Leather", 0, Slot.Head, ArmorType.Leather, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Mail", 0, Slot.Body, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var ranger = new Ranger("Ranger");
            ranger.Equip(armor1);
            ranger.Equip(armor2);
            var actual = ranger.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithReplacedEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 1, Dexterity = 7, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 8, Intelligence = 2 };
            var armor1 = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Mail", 0, Slot.Body, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var ranger = new Ranger("Ranger");
            ranger.Equip(armor1);
            ranger.Equip(armor2);
            var actual = ranger.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithNoWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 1, Dexterity = 7, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalDexterity / 100))
            //If no weapon weaponDamge = 1
            var expected = 1;                       
            //Act
            var ranger = new Ranger("Ranger");
            var actual = ranger.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 1, Dexterity = 7, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalDexterity / 100))
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Bows", 0, Slot.Weapon, WeaponType.Bows, 2);
            //Act
            var ranger = new Ranger("Ranger");
            ranger.Equip(weapon);
            var actual = ranger.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeaponAndArmor_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 1, Dexterity = 7, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalDexterity / 100))
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Bows", 0, Slot.Weapon, WeaponType.Bows, 2);
            var armor = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes());
            //Act
            var ranger = new Ranger("Ranger");
            ranger.Equip(weapon);
            ranger.Equip(armor);

            var actual = ranger.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Display_DisplayingHeroStatus_ShouldReturnCorrectStatus()
        {
            //Arrangement                                    
            var weapon = new Weapon("Bows", 0, Slot.Weapon, WeaponType.Bows, 2);
            var armor = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var ranger= new Ranger("Ranger");
            ranger.Equip(weapon);
            ranger.Equip(armor);
            ranger.LevelUp();

            var actual = ranger.Display();
            //Assertion
            output.WriteLine(actual.ToString());
        }
        #endregion
    }
}

