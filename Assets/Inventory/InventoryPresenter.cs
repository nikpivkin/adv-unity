using Inventory.UI;
using UnityEngine;

namespace Inventory
{
    public class InventoryPresenter : MonoBehaviour
    {
        [SerializeField] private InventoryUI inventoryUI;
        [SerializeField] private Inventory inventory;

        private void Start() =>  Render();

        private void OnEnable()
        {
            inventory.onItemAdded += OnItemAdded;
            inventory.onItemRemoved += OnItemRemoved;
        }

        private void OnDisable()
        {
            inventory.onItemAdded -= OnItemAdded;
            inventory.onItemRemoved -= OnItemRemoved;
        }

        private void Render() => inventoryUI.Render(inventory.Items);
        private void OnItemAdded() => Render();
        private void OnItemRemoved() => Render();
    }
}