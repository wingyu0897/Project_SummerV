using UnityEngine;

public enum ItemCollectType 
{ 
    None, 
    Fix, 
    Dynamic 
}

[CreateAssetMenu(menuName = "SO/ToolData")]
public class ToolData : ScriptableObject
{
    public ItemCollectType collectType;
    public KeyCode useKey = KeyCode.Mouse0;
}
