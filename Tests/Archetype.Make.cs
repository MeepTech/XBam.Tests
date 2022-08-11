using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {
  public partial class Archetype {
    [TestClass]
    public class Make {


      [TestMethod]
      public void MakeDefaultBasic_Success() {
        Item made = Archetypes<Apple>._.Make();
        Assert.AreEqual(
          made.Archetype.Id,
          Apple.Id
        );
      }
    }
  }
}
