using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only Gameplay")]
    public TileBase tile;
    public Itemtype type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    public CraftPlace craftPlace;
    public List<CraftingIngredient> ingredients;

    [Header("Only UI")]
    public int stackableCount;

    [Header("Both")]
    public Sprite image;
}
[Serializable]
public class CraftingIngredient
{
    public Item itemID;
    public int amount;
}
public enum Itemtype
{
    Resources = 1,
    Tools = 2,
    Crafted_objects = 3,
    Seeds = 4
}
public enum ActionType
{
    equipable = 1,
    usable = 2,
    placeable = 3
}
public enum CraftPlace
{
    None = 0,
    Everywhere = 1,
    CraftingTable = 2,
    Fernence = 3
}



