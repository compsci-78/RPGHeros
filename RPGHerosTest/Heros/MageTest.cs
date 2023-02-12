using RPGHeros.Enums;
using RPGHeros.Exceptions;
using RPGHeros.Heros;
using RPGHeros.Items;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace RPGHerosTest.Heros
{
    public class MageTest
    {
        private readonly ITestOutputHelper output;
        public MageTest(ITestOutputHelper output)
        {
            this.output = output;
        }
        #region Creation
        [Fact]
        public void Mage_CreatesMageInstance_ShouldCreateMageWithCorrectName()
        {
            //Arrangement
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
            //Arrangement
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
            //Arrangement
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
            //Arrangement
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

            //Arrangement
            var name = "Mage";
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 2 ,Intelligence=13 };
            //Act
            var mage = new Mage(name);
            mage.LevelUp();
            var actual = mage.LevelAttributes;
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
            var expected = new Weapon("Staffs",0,weaponSlot,WeaponType.Staffs,0);            
            //Act
            var mage = new Mage("Mage");
            mage.Equip(expected);
            var actual = mage.Equipment[weaponSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Staffs", 3, Slot.Weapon, WeaponType.Staffs, 0);
            //Act
            var mage = new Mage("Mage");                        
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(()=> mage.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidWeaponType_ShouldThorwInvalidWeaponException()
        {
            //Arrangement            
            var weaponWithRequiredLevel = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Bows, 0);
            //Act
            var mage = new Mage("Mage");
            //Assertion
            Assert.Throws<InvalidWeaponTypeException>(() => mage.Equip(weaponWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItems_ShouldEquipHeroWithCorrectArmor()
        {
            //Arrangement
            var armorSlot = Slot.Body;
            var expected = new Armor("Cloth", 0, armorSlot, ArmorType.Cloth,new HeroAttributes());
            //Act
            var mage = new Mage("Mage");
            mage.Equip(expected);
            var actual = mage.Equipment[armorSlot];
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithRequiredLevel_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Cloth", 3, Slot.Body, ArmorType.Cloth, new HeroAttributes());
            //Act
            var mage = new Mage("Mage");            
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => mage.Equip(armorWithRequiredLevel));
        }
        [Fact]
        public void Equip_EquippingHeroWithItemWithInvalidArmorType_ShouldThrowInvalidArmorException()
        {
            //Arrangement            
            var armorWithRequiredLevel = new Armor("Leather", 0, Slot.Body, ArmorType.Leather, new HeroAttributes());
            //Act
            var mage = new Mage("Mage");
            //Assertion
            Assert.Throws<InvalidArmorTypeException>(() => mage.Equip(armorWithRequiredLevel));
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithNoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement            
            var expected = new HeroAttributes() {Strength=1,Dexterity=1,Intelligence=8 };
            //Act
            var mage = new Mage("Mage");
            var actual=mage.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithOneEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 1, Dexterity = 1, Intelligence = 8 }
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 2, Intelligence = 9 };
            var armor = new  Armor("Cloth",0,Slot.Body,ArmorType.Cloth, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var mage = new Mage("Mage");
            mage.Equip(armor);
            var actual = mage.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithTwoEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 1, Dexterity = 1, Intelligence = 8 }
            var expected = new HeroAttributes() { Strength = 3, Dexterity = 3, Intelligence = 10 };
            var armor1 = new Armor("Cloth", 0, Slot.Body, ArmorType.Cloth, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Cloth", 0, Slot.Head, ArmorType.Cloth, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var mage = new Mage("Mage");
            mage.Equip(armor1);
            mage.Equip(armor2);
            var actual = mage.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void TotalAttributes_CalculatingHerosTotalAttributesWithReplacedEquipment_ShouldReturnCorrectHeroAttributes()
        {
            //Arrangement                        
            // Initial values { Strength = 1, Dexterity = 1, Intelligence = 8 }
            var expected = new HeroAttributes() { Strength = 2, Dexterity = 2, Intelligence = 9 };
            var armor1 = new Armor("Cloth", 0, Slot.Body, ArmorType.Cloth, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            var armor2 = new Armor("Cloth", 0, Slot.Body, ArmorType.Cloth, new HeroAttributes() { Strength = 1, Dexterity = 1, Intelligence = 1 });
            //Act
            var mage = new Mage("Mage");
            mage.Equip(armor1);
            mage.Equip(armor2);
            var actual = mage.TotalAttributes();
            //Assertion
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Damage_CalculatingHerosDamageWithNoWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 1, Dexterity = 1, Intelligence = 8 }
            //Hero damage = WeaponDamage * (1 + totalIntelligence / 100)
            //If no weapon weaponDamge = 1
            var expected = 1;                    
            //Act
            var mage = new Mage("Mage");                    
            var actual = mage.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 1, Dexterity = 1, Intelligence = 8 }
            //Hero damage = WeaponDamage * (1 + totalIntelligence / 100)
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Staffs, 2);            
            //Act
            var mage = new Mage("Mage");
            mage.Equip(weapon);
            var actual = mage.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithReplacedValidWeapon_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 1, Dexterity = 1, Intelligence = 8 }
            //Hero damage = WeaponDamage * (1 + totalIntelligence / 100)
            //If no weapon weaponDamge = 1
            var expected = 3;
            var weapon1 = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Staffs, 2);
            var weapon2 = new Weapon("Wands", 0, Slot.Weapon, WeaponType.Wands, 3);
            //Act
            var mage = new Mage("Mage");
            mage.Equip(weapon1);
            mage.Equip(weapon2);
            var actual = mage.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Damage_CalculatingHerosDamageWithValidWeaponAndArmor_ShouldReturnCorrectDamage()
        {
            //Arrangement                        
            //Initial values { Strength = 1, Dexterity = 1, Intelligence = 8 }
            //Hero damage = WeaponDamage * (1 + totalIntelligence / 100)
            //If no weapon weaponDamge = 1
            var expected = 2;
            var weapon = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Staffs, 2);
            var armor = new Armor("Cloth", 0, Slot.Body,ArmorType.Cloth,new HeroAttributes());
            //Act
            var mage = new Mage("Mage");
            mage.Equip(weapon);
            mage.Equip(armor);

            var actual = mage.Damage();
            //Assertion
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Display_DisplayingHeroStatus_ShouldReturnCorrectStatus()
        {
            //Arrangement                                    
            var weapon = new Weapon("Staffs", 0, Slot.Weapon, WeaponType.Staffs, 2);
            var armor = new Armor("Cloth", 0, Slot.Body, ArmorType.Cloth, new HeroAttributes() {Strength=1,Dexterity=1,Intelligence=1 });
            //Act
            var mage = new Mage("Mage");
            mage.Equip(weapon);
            mage.Equip(armor);
            mage.LevelUp();

            var actual = mage.Display();
            //Assertion
           output.WriteLine(actual.ToString());
        }

        #endregion
    }
}