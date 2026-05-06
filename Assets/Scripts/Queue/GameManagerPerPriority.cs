using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public enum PriorityType
{
    Speed,
    ID,
    Attack,
    Popularity,
}

public class GameManagerPerPriority : MonoBehaviour
{
    public static GameManagerPerPriority Instance;

    public PriorityQueue<Entity> priorityQueue =
        new((a, b) => a.Speed > b.Speed);

    private PriorityType currentPriority;
    public List<Entity> entities = new();

    private bool changePriority;

    public Action OnApplyPositions;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //AplicarLista();
    }

    [Button]
    public void AplicarLista()
    {
        for (int i = 0; i < entities.Count; i++)
        {
            // Ordenar por prioridad
            Enqueue(entities[i]);
        }

        AplicarPosiciones();
    }

    [Button]
    public void ChangePriority(PriorityType newPriorityType)
    {
        Clear();
        currentPriority = newPriorityType;

        switch (currentPriority)
        {
            case PriorityType.Speed:
                priorityQueue = new((a, b) => a.Speed > b.Speed);
                break;

            case PriorityType.ID:
                priorityQueue = new((a, b) => a.ID < b.ID);
                break;

            case PriorityType.Attack:
                priorityQueue = new((a, b) => a.Damage > b.Damage);
                break;

            case PriorityType.Popularity:
                priorityQueue = new((a, b) => a.Popularity < b.Popularity);
                break;
        }

        AplicarLista();
    }

    [Button]
    public void Enqueue(Entity entityStats)
    {
        priorityQueue.Enqueue(entityStats);
        AplicarPosiciones();
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

    public void AplicarPosiciones()
    {
        float spacing = 5f;
        float originZ = 0f;

        priorityQueue.ApplyPositions((entity, index) =>
        {
            float newPosZ = originZ - (index * spacing);

            entity.transform.position = new Vector3(
                entity.transform.position.x,
                entity.transform.position.y,
                newPosZ
            );

            entity.PriorityIndex = index;
        });

        OnApplyPositions?.Invoke();
    }
}