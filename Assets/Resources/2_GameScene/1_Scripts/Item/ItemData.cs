using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public bool Kind;
    public bool Beneficial;                     // 이로운 효과인지
}
