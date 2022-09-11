using Meep.Tech.XBam.Examples.ModelWithComponents;
using Meep.Tech.XBam.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;

namespace Meep.Tech.XBam.Tests {
  [TestClass]
  public partial class Components {

    [TestMethod]
    public void SerializeArchetypeComponent() {
      Capacitor capacitor = Components<Capacitor>.Factory.Make(
        (nameof(Capacitor.DefaultCapacityValue), 103)  
      );

      JObject json = capacitor.ToJson();
      Assert.AreEqual(103, json.TryGetValue<int>(nameof(Capacitor.DefaultCapacityValue)));
    }

    [TestMethod]
    public void SerializeModelComponent() {
      CapacitorData capacitor = new CapacitorData(103);

      JObject json = capacitor.ToJson();
      Assert.AreEqual(103, json.TryGetValue<int>(nameof(CapacitorData.Value)));
    }

    [TestMethod]
    public void DeSerializeModelComponent() {
      CapacitorData capacitor = new CapacitorData(103);

      JObject json = capacitor.ToJson();

      var deserialized = json.ToComponent<CapacitorData>();
      Assert.AreEqual(103, deserialized.Value);
    }

    [TestMethod]
    public void DeSerializeComponentOntoParentModel() {
      CapacitorData capacitor = new CapacitorData(103);

      JObject json = capacitor.ToJson();

      var machine = Device.Types.Get<DangerousModularDevice.Type>()
        .GetDefaultBuilders().Make<DangerousModularDevice>();

      json.ToComponent<CapacitorData>(ontoParent: machine);
      Assert.AreEqual(103, machine.GetComponent<CapacitorData>().Value);
    }

    [TestMethod]
    public void IDoOnAdd_AfterTrue_Success() {
      var machine = Device.Types.Get<DangerousModularDevice.Type>()
        .GetDefaultBuilders().Make<DangerousModularDevice>();

      DisplayComponent component = Components<DisplayComponent>.Factory.Make();
      machine.AddComponent(component);

      Assert.IsTrue(component.WasInitialized);
    }

    [TestMethod]
    public void IDoOnAdd_BeforeFalse_Success() {
      var machine = Device.Types.Get<DangerousModularDevice.Type>()
        .GetDefaultBuilders().Make<DangerousModularDevice>();

      DisplayComponent component = Components<DisplayComponent>.Factory.Make();

      Assert.IsFalse(component.WasInitialized);
    }
  }
}
