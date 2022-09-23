using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RegionsMaster
{
    public static void CreateRegions()
    {
        List<string> names = new List<string> { "Astora", "Nothuard", "Steelwally", "Straitfort", "Dora" };
        List<UnitType> unitTypes = new List<UnitType> { UnitType.Archers, UnitType.Military, UnitType.Mount };
        List<ItemBase> items = new List<ItemBase> { new ItemChaseTroops(), new Dagon(), new Dagon(), new Dagon(),
            new ManaBooster(), new ManaBooster(), new ManaBooster(), new ManaBooster(), new ManaBooster(), new ManaBooster() };

        int itemsListCount = items.Count;
        for (int i = 0; i < 3; i++)
        {
            RegionBase regionBase = new RegionBase();
            regionBase.shopItems = new List<ItemBase> { };
            regionBase.number = i;
            regionBase.rich = Random.Range(1, 10);

            int randomValue = Random.Range(0, unitTypes.Count - 1);
            int nameRandomValue = Random.Range(0, names.Count - 1);

            PutItems(items, itemsListCount, regionBase, 3);

            regionBase.name = names[nameRandomValue];
            regionBase.unitType = unitTypes[randomValue];
            names.Remove(names[nameRandomValue]);
            unitTypes.Remove(unitTypes[randomValue]);
            regionBase.SaveRegion();
        }
        
    }
    private static void PutItems(List<ItemBase> items, int itemsListCount, RegionBase regionBase, int count)
    {
        
        int itemsCount = itemsListCount / count;
        for (int i = 0; i < itemsCount; i++)
        {
            int rndValue = Random.Range(0, items.Count);
            regionBase.shopItems.Add(items[rndValue].Copy());
            items.Remove(items[rndValue]);
        }
        
    }
}
