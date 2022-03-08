using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    public string m_id;
    public string m_displayName;
    public Sprite m_icon;
    public GameObject m_prefab;
}
