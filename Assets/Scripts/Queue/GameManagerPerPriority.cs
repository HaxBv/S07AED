using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerPerPriority : MonoBehaviour
{
    public static GameManagerPerPriority Instance;

    public PriorityQueue<Entity> priorityQueue =
        new((a, b) => a.Speed > b.Speed);


    public List<Entity> entities = new();

    private bool changePriority;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {

    }
    [Button]
   
    /*[Button]
    public void OrderListPerID()
    {
        priorityQueue = new((a, b) => a.ID < b.ID);
    }

    [Button]
    public void OrderListPerSpeed()
    {
        Clear();
        priorityQueue = new((a, b) => a.Speed > b.Speed);
    }*/


    public void ChangePriority()
    {
        Clear();
        if (!changePriority)
        {
            priorityQueue = new((a, b) => a.ID < b.ID);
            changePriority = true;
        }
        else
        {
            priorityQueue = new((a, b) => a.Speed > b.Speed);
            changePriority = false;
        }
    }

    [Button]
    public void Enqueue(Entity entityStats)
    {
        priorityQueue.Enqueue(entityStats);
    }
    [Button]
    public void Dequeue()
    {
        Debug.Log("Pase a ser atendido : " + priorityQueue.Dequeue());
    }
    [Button]
    public void Peek()
    {
        Debug.Log("El siguiente en ser atendido sera ... " + priorityQueue.Peek());
    }

    [Button]
    public void Clear()
    {
        priorityQueue.Clear();
    }

    [Button]
    public void Count()
    {
        Debug.Log(priorityQueue.Count);
    }
}
