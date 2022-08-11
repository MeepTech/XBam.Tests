using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Meep.Tech.XBam.Examples.StructOnlyModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {
  public partial class Model {
    [TestClass]
    public partial class Builder {

      [TestMethod]
      public void MakesModelWithCorrectArchetype_DoubleGeneric_ClassBased() {
        var apple = Archetypes<Apple>._.Make();
        Assert.AreEqual(Archetypes<Apple>._, apple.Archetype);
      }

      [TestMethod]
      public void MakesModelWithCorrectArchetype_DoubleGeneric_FromInterface() {
        var grassTile = Tile.Types.Get<Grass>().Make();
        Assert.AreEqual(Archetypes<Grass>._, grassTile.Archetype);
      }
    }
  }
}
