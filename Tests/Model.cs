using Meep.Tech.XBam.Examples.ModelWithComponents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Meep.Tech.XBam.Tests {

  [TestClass]
  public partial class Model {

    [TestMethod]
    public void ConstructionWithoutNeededParameter_Failure() {
      Assert.ThrowsException<IModel.IBuilder.Param.MissingException>(() => {
        Device.Types.Get<ModularFluxCapacitor.Type>()
          .Make();
      });
    }
  }
}
