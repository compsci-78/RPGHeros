using RPGHeros.Enums;
using RPGHeros.Exceptions;
using RPGHeros.Heros;
using RPGHeros.Items;

namespace RPGHerosTest.Heros
{
    public class RogueTest
    {
        #region Creation
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
        #endregion

        #region Methods
        [Fact]
        public void Equip_EquippingHeroWithItems_ShouldEquipHeroWithCorrectWeapon()
        {
            //Arrangement
            var weaponSlot = Slot.Weapon;
            var expected = new Weapon("Daggers", 0, weaponSlot, WeaponType.Daggers, 0);
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(expected);
            var actual = rogue.Equipment[weaponSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Daggers", 3, Slot.Weapon, WeaponType.Daggers, 0);
            //Act
            var rogue = new Rogue("Rogue");
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(() => rogue.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidWeaponType_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Staffs, 0);
            //Act
            var rogue = new Rogue("Rogue");
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(() => rogue.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItems_ShouldEquipHeroWithCorrectArmor()
        {
            //Arrangement
            var armorSlot = Slot.Body;
            var expected = new Armor("Leather", 0, armorSlot, ArmorType.Leather, new HeroAttributes());
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(expected);
            var actual = rogue.Equipment[armorSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Leather", 3, Slot.Body, ArmorType.Cloth, new HeroAttributes());
            //Act
            var rogue = new Rogue("Rogue");
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => rogue.Equip(armorWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidArmorType_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Cloth", 0, Slot.Body, ArmorType.Cloth, new HeroAttributes());
            //Act
            var rogue = new Rogue("Rogue");
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => rogue.Equip(armorWithRequiredLevel));
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithNoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement            
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 6, Intelligence = 1 };
            //Act
            var rogue = new Rogue("Rogue");
            var actual = rogue.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithOneEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 2, Dexterity = 6, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 3, Dexterity = 7, Intelligence = 2 };
            var armor = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(armor);
            var actual = rogue.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithTwoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 2, Dexterity = 6, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 4, Dexterity = 8, Intelligence = 3 };
            var armor1 = new Armor("Leather", 0, Slot.Head, ArmorType.Leather, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Mail", 0, Slot.Body, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(armor1);
            rogue.Equip(armor2);
            var actual = rogue.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithReplacedEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 2, Dexterity = 6, Intelligence = 1 }
            var expected = new HeroAttributes() { Strength = 3, Dexterity = 7, Intelligence = 2 };
            var armor1 = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Mail", 0, Slot.Body, ArmorType.Mail, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(armor1);
            rogue.Equip(armor2);
            var actual = rogue.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithNoWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 2, Dexterity = 6, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalDexterity / 100))
            //If no weapon weaponDamge = 1
            var expected = 1;
            //Act
            var rogue = new Rogue("Rogue");
            var actual = rogue.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 2, Dexterity = 6, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalDexterity / 100))
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Daggers", 0, Slot.Weapon, WeaponType.Daggers, 2);
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(weapon);
            var actual = rogue.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithReplacedValidWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 2, Dexterity = 6, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalDexterity / 100))
            //If no weapon weaponDamge = 1
            var expected = 3;
            var weapon1 = new Weapon("Dagers", 0, Slot.Weapon, WeaponType.Daggers, 2);
            var weapon2 = new Weapon("Swords", 0, Slot.Weapon, WeaponType.Swords, 3);
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(weapon1);
            rogue.Equip(weapon2);
            var actual = rogue.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeaponAndArmor_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 2, Dexterity = 6, Intelligence = 1 }
            //Hero damage = WeaponDamage * (1 + (TotalDexterity / 100))
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Swords", 0, Slot.Weapon, WeaponType.Swords, 2);
            var armor = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes());
            //Act
            var rogue = new Rogue("Rogue");
            rogue.Equip(weapon);
            rogue.Equip(armor);

            var actual = rogue.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}