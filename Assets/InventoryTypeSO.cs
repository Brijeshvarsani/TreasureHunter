using UnityEngine;

[CreateAssetMenu()]
public class InventoryTypeSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    public ResourceTypeSO RequiredResourceType;
    public int RequiredResourceAmount;
}


