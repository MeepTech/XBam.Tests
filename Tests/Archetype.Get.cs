using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {
  public partial class Archetype {
    /// <summary>
    /// Getting archetypes from static sources
    /// </summary>
    [TestClass]
    public class Get {

      [TestMethod]
      public void GetByStaticId_Exists() {
        Assert.IsNotNull(Apple.Id.Archetype);
        Assert.IsNotNull(Sword.Id.Archetype);
      }

      [TestMethod]
      public void GetByStaticId_Success() {
        Assert.AreEqual(
          Apple.Id.Archetype.Id.Key,
          "Meep.Tech.XBam.Examples.ModelWithArchetypes.Item.Apple"
        );
        Assert.AreEqual(
          Sword.Id.Key,
          "Meep.Tech.XBam.Examples.ModelWithArchetypes.Item.Weapon.Sword"
        );
      }

      [TestMethod]
      public void GetFromSystemType_Success() {
        Assert.AreEqual(Apple.Id.Archetype, typeof(Apple).AsArchetype());
        Assert.AreEqual(Sword.Id.Archetype, typeof(Sword).AsArchetype());
      }

      [TestMethod]
      public void GetFromSystemTypeGenerics_Child_Success() {
        Assert.AreEqual(Apple.Id.Archetype, typeof(Apple).AsArchetype<Apple>());
      }

      [TestMethod]
      public void GetFromSystemTypeGenerics_Parent_Success() {
        Assert.AreEqual(Apple.Id.Archetype, typeof(Apple).AsArchetype<Item.Type>());
      }
    }
  }
}
