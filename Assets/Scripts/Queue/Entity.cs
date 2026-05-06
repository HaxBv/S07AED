using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStats Data;

    public int ID;
    public string Name;
    public float Speed;
    public int Damage;
    public int Popularity;

    public Sprite Sprite;
    public MeshRenderer Renderer;

    public int PriorityIndex;

    private void Awake()
    {
        Renderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {;

        ID = Data.ID;
        Name = Data.Name;
        Speed = Data.Speed;
        Damage = Data.Damage;
        Popularity = Data.Popularity;

        Sprite = Data.Sprite;

        if (Renderer != null)
            Renderer.material = Data.Material;


        //gameObject.name = Name + "  " + "SDP: " + Speed + "  " + "ID: " + ID;
        gameObject.name = Name;
    }
   

    // Update is called once per frame
    void Update()
    {

    }
}
   
