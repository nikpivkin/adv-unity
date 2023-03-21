using System.Collections.Generic;
using UnityEngine;

namespace Inventory.UI
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI _slotTemplate;
        [SerializeField] private Transform _container;
        public void Render(List<IInventoryItem> items)
        {
            Clear();
            foreach (var inventoryItem in items)
            {
                var slot = Instantiate(_slotTemplate, _container);
                slot.Render(inventoryItem);
            }
        }

        private void Clear()
        {
            foreach (Transform child in _container)
            {
                Destroy(child.gameObject);
            }
        }
    }
}