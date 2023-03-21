using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Item")]
    public class InventoryItem : ScriptableObject, IInventoryItem
    {
        public string Name => _name;
        public Sprite Icon => _icon;

        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
    }
}