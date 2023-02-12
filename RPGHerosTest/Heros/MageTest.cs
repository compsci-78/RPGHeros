using RPGHeros.Enums;
using RPGHeros.Exceptions;
using RPGHeros.Heros;
using RPGHeros.Items;

namespace RPGHerosTest.Heros
{
    public class MageTest
    {
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
        #endregion
    }
}