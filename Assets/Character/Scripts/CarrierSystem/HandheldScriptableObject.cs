using Inventory;
using UnityEngine;

namespace Character.CarrierSystem
{
    [CreateAssetMenu(fileName="Handheld", menuName="HandHeld", order=1)]
    public class HandheldScriptableObject : ScriptableObject, IHandheldInventoryItem
    {
        [SerializeField] private GameObject _handHeldPrefab;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;

        public string Name => _name;
        public Sprite Icon => _icon;
        public GameObject HandHeldPrefab => _handHeldPrefab;
    }
}
