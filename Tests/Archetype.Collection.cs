using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Meep.Tech.XBam.Examples.StructOnlyModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {
  public partial class Archetype {
    [TestClass]
    public partial class Collection {

      [TestMethod]
      public void DefaultTypesCollectionForBaseModel_TypeIsCorrect() {
        Assert.IsInstanceOfType(
          Item.Types,
          typeof(Archetype<Item, Item.Type>.Collection)
        );
      }

      [TestMethod]
      public void StaticCollectionForBaseModel_TypeIsCorrect() {
        Assert.IsInstanceOfType(
          Archetypes.DefaultUniverse.Archetypes.GetCollection(typeof(Item.Type)),
          typeof(Archetype<Item, Item.Type>.Collection)
        );
      }

      [TestMethod]
      public void StaticCollectionForChildModel_TypeIsCorrect() {
        Assert.IsInstanceOfType(
          Archetypes.GetCollection(Archetypes<Apple>._),
          typeof(Archetype<Item, Item.Type>.Collection)
        );
      }

      [TestMethod]
      public void DefaultCollectionForBaseArchetype_TypeIsCorrect() {
        Assert.IsInstanceOfType(
          Item.Types,
          typeof(Archetype<Item, Item.Type>.Collection)
        );
      }

      public void DefaultCollectionForInterfaceBasedModelArchetype_FromBaseArchetypeType_TypeIsCorrect() {
        Assert.IsInstanceOfType(
          Archetypes<Tile.Type>.Collection,
          typeof(Archetype<Tile, Tile.Type>.Collection)
        );
      }

      public void DefaultCollectionForInterfaceBasedModelArchetype_FromModelType_TypeIsCorrect() {
        Assert.IsInstanceOfType(
          Models.FromInterface<Tile>.Types,
          typeof(Archetype<Tile, Tile.Type>.Collection)
        );
      }
    }
  }
}
