using System;
using UnityEngine;

using static PlantType;
using static ToolType;

[System.Serializable] // Make the class visible in the Inspector

public class Item
{
    public string itemName;
    public string itemDescription;
    public PlantType plantType = PlantType.None;
    public ToolType toolType = ToolType.None;
}
