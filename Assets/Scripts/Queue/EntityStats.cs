using UnityEngine;

[CreateAssetMenu(fileName = "EntityStats", menuName = "Scriptable Objects/EntityStats")]
public class EntityStats : ScriptableObject
{
    [SerializeField]private int id;
    [SerializeField]private string entityName;

    [SerializeField]private float speed;

    public int ID => id;
    public string Name => entityName;
    public float Speed => speed;

}
