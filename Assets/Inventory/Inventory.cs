using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class Inventory : MonoBehaviour
    {
        public bool IsFull => Items.Count == Capacity;
        public int Capacity => capacity;
        public List<IInventoryItem> Items { get; } = new();

        
        [SerializeField] private List<ScriptableObject> initialItems;
        [SerializeField] private int capacity;
        
        public Action onItemAdded;
        public Action onItemRemoved;

        private void Start()
        {
            initialItems?.ForEach(o =>
            {
                if (o is IInventoryItem item) AddItem(item);
            });
        }

        public bool AddItem(IInventoryItem item)
        {
            if (IsFull) return false;
            Items.Add(item);
            onItemAdded?.Invoke();
            return true;
        }

        public void RemoveByIndex(int idx)
        {
            if(Items == null || idx < 0 || idx >= Items.Count)  return;

            Items.RemoveAt(idx);
            onItemRemoved?.Invoke();
          
        }

        public bool TryGetItemByIndex(int idx, out IInventoryItem element)
        {

            if(Items == null || idx < 0 || idx >= Items.Count)
            {
                element = default;
                return false;
            }

            element = Items[idx];
            return true;
        }
    }
}