using UnityEngine;
using UnityEngine.UI;

namespace Inventory.UI
{
    public class InventorySlotUI : MonoBehaviour
    {
        [SerializeField] private Text nameField;
        [SerializeField] private Image iconField;
        
        public void Render(IInventoryItem item)
        {
            nameField.text = item.Name;
            iconField.sprite = item.Icon;
        }
    }
}