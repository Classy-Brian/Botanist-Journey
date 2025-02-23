using UnityEngine;

// Attribute to create a menu item for creating Tool assets
[CreateAssetMenu(fileName = "Tool", menuName = "BotanistJourney/Tool")]
public class Tool: ScriptableObject
{
    // Name of the Tool (overrides the default 'name' property)
    public new string name;

    // Description of the Tool
    public string desc;

    // Durability of the Tool Rust(Patina- good Tarnish - mid Rust- Bad )
    public string durability; 
}
