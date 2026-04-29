using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStats Data;

    public int ID;
    public string Name;
    public float Speed;
    void Start()
    {
        ID = Data.ID;
        Name = Data.Name;
        Speed = Data.Speed;


        gameObject.name = Name + "  " + "SDP: " + Speed + "  " + "ID: " + ID;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
