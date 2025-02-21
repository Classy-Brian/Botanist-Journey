using UnityEngine;

// Attribute to create a menu item for creating Plant assets
[CreateAssetMenu(fileName = "Plant", menuName = "BotanistJourney/Plant")]
public class Plant: ScriptableObject
{
    // Name of the plant (overrides the default 'name' property)
    public new string name;

    // Description of the plant
    public string desc;
}
