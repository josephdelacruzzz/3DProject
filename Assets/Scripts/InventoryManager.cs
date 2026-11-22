using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private readonly HashSet<ItemId> collectedItems =
        new HashSet<ItemId>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void AddItem(ItemId item)
    {
        collectedItems.Add(item);
    }

    public bool HasItem(ItemId item)
    {
        return collectedItems.Contains(item);
    }
}