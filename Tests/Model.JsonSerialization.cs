using Meep.Tech.XBam.Examples.ModelWithArchetypes;
using Meep.Tech.XBam.Examples.ModelWithComponents;
using Meep.Tech.XBam.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace Meep.Tech.XBam.Tests {
  public partial class Model {
    [TestClass]
    public class JsonSerialization {

      [TestMethod]
      public void SerializeSimpleItem_Success() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Item deserializedItem = (Item)Deserialize.ToModel(itemJson);

        Assert.AreEqual(((IUnique)item).Id, ((IUnique)deserializedItem).Id);
      }

      [TestMethod]
      public void SerializeUniqueId_Success() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Assert.AreEqual(((IUnique)item).Id, itemJson.Value<string>("id"));
      }

      [TestMethod]
      public void SerializeSimpleItemDeserialization_Success() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Item deserializedItem = Archetypes<Sword>.Instance.MakeFromJson(itemJson);

        Assert.AreEqual(item, deserializedItem);
      }

      [TestMethod]
      public void SerializedUniqueIdDeserialization_Success() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Item deserializedItem = Archetypes<Sword>.Instance.MakeFromJson(itemJson);

        Assert.AreEqual(((IUnique)item).Id, ((IUnique)deserializedItem).Id);
      }

      [TestMethod]
      public void SerializeSimpleItemDeserializationFromAbstractBaseGeneric_Failure() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Assert.ThrowsException<KeyNotFoundException>(() => {
          Archetypes<Item.Type>.Instance.MakeFromJson(itemJson);
        });
      }

      [TestMethod]
      public void SerializeSimpleItemDeserializationGeneric_Success() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Item deserializedItem = Deserialize.ToModel<Item>(itemJson);

        Assert.AreEqual(item, deserializedItem);
      }

      [TestMethod]
      public void SerializeSimpleItemDeserializationGenericConvert_ParentCannotHandleChildDeserialization_Failure() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Assert.ThrowsException<JsonException>(() => {
          Deserialize.ToModel<Item>(itemJson, typeof(Item));
        });
      }

      [TestMethod]
      public void SerializeSimpleItemDeserializationSpecificType_Success() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Item deserializedItem = (Item)Deserialize.ToModel(itemJson, typeof(Weapon));

        Assert.AreEqual(item, deserializedItem);
      }

      [TestMethod]
      public void SimpleItemReserialization_Success() {
        Item item = Item.Types.Get<Sword>().Make<Weapon>();
        JObject itemJson = item.ToJson();

        Item deserializedItem = Deserialize.ToModel<Item>(itemJson);

        Assert.AreEqual(item.ToJson().ToString(), deserializedItem.ToJson().ToString());
      }

      [TestMethod]
      public void ItemWithComponentsReserialization_Success() {
        ModularFluxCapacitor device = Device.Types.Get<ModularFluxCapacitor.Type>()
          .GetDefaultBuilders()
            .Make<ModularFluxCapacitor>(("FluxLevel", 1));
        device.AddNewComponent<ManufacturerDetails>(
          (nameof(ManufacturerDetails.ManufacturerName), "test")
        );

        JObject itemJson = device.ToJson();

        Device deserializedItem = (Device)Deserialize.ToModel(itemJson);

        Assert.AreEqual(device.ToJson().ToString(), deserializedItem.ToJson().ToString());
      }
    }
  }
}
