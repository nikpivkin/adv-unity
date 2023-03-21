using UnityEngine;

namespace Inventory
{
    public interface IInventoryItem
    {
        string Name { get; }
        Sprite Icon { get; }
    }
}