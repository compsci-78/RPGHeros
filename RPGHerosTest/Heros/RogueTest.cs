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
        #endregion
    }
}