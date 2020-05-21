using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Attribute")]
public class AttributeSpell : ScriptableObject
{
    [Header("Description")]
    public string Name;
    public List<Sprite> sprites;

    [Header("Attribute")]
    public int couldown;

}
