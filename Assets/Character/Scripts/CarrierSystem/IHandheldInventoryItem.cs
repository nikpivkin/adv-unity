using Inventory;
using UnityEngine;

namespace Character.CarrierSystem
{
    public interface IHandheldInventoryItem : IInventoryItem
    {
        
        GameObject HandHeldPrefab { get; }
        
    }
}