using System;
using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    [SerializeField]private int id;
    [SerializeField]private string entityName;

    [SerializeField]private float speed;
    [SerializeField]private int damage;
    [SerializeField]private int popularity;

    [SerializeField]private Sprite sprite;

    [SerializeField]private Material material;

    public int ID => id;
    public string Name => entityName;
    public float Speed => speed;
    public Sprite Sprite => sprite;
    public Material Material => material;
    public int Damage => damage;
    public int Popularity => popularity;

}
