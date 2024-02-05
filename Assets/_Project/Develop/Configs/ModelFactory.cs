using System.Collections.Generic;
using System.Linq;

public class ModelFactory
{
    public static UnitModel CreateUnitModel(UnitData unitData, List<AbilityData> abilitiesData, List<ItemData> itemsData)
    {
        var abilityModels = CreateAbilityModels(unitData, abilitiesData);
        var itemModels = CreateItemModels(unitData, itemsData);
        var unitModel = new UnitModel(unitData, abilityModels,itemModels);
        return unitModel;
    }

    private static List<AbilityModel> CreateAbilityModels(UnitData unitData, List<AbilityData> abilitiesData)
    {
        var abilityModels = new List<AbilityModel>();
        foreach (var unitAbility in unitData.UnitAbilities)
        {
            var abilityData = abilitiesData.FirstOrDefault(x => x.Id == unitAbility.AbilityID);
            var abilityModel = new AbilityModel(abilityData, unitAbility.CurrentQuantity, unitAbility.MaxQuantity);
            abilityModels.Add(abilityModel);
        }
        return abilityModels;
    }

     private static List<ItemModel> CreateItemModels(UnitData unitData, List<ItemData> itemsData)
     {
        var itemModels = new List<ItemModel>();
        foreach (var unitItem in unitData.UnitItems)
        {
            var itemData = itemsData.FirstOrDefault(x => x.Id == unitItem.ItemId);
            var itemModel = new ItemModel(itemData, unitItem.CurrentQuantity);
            itemModels.Add(itemModel);
        }
        return itemModels;
     }
}