using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.CarrierSystem
{
    public class CarrierSystem : MonoBehaviour
    {
        [SerializeField] private Transform rigSocket;
        [SerializeField] private Animator rigAnimator;
        [SerializeField] private Inventory.Inventory _inventory;

        [SerializeField] private HandheldScriptableObject testItem;

        private IHandheldInventoryItem _currentHandheldScriptableObject;
        private GameObject _currentHandheldGameObject;
        private IHandHeldObject _currentHandHeld;
        private int _currentHandheldIndex;
        
        private void Awake()
        {
            SelectHandheldByIndex(0);
        }

        public Animator GetAnimator()
        {
            return rigAnimator;
        }

        private void SwitchHandheld(IHandheldInventoryItem handheld)
        {
            if (handheld == null || _currentHandheldScriptableObject == handheld) return;
            
            Destroy(_currentHandheldGameObject);
            _currentHandheldScriptableObject = handheld;
            _currentHandheldGameObject = Instantiate(_currentHandheldScriptableObject.HandHeldPrefab, 
                rigSocket, true);
            _currentHandheldGameObject.transform.localPosition = Vector3.zero;
            _currentHandheldGameObject.transform.localRotation = Quaternion.identity;

            _currentHandHeld = _currentHandheldGameObject.GetComponentInChildren<IHandHeldObject>();
            if (_currentHandHeld != null)
            {
                _currentHandHeld.OnAttachedCarrier(this);
                _currentHandHeld.OnEquip();
                
                // TODO
                // rigAnimator.runtimeAnimatorController = handheld.animatorController;
            }
            else
            {
                UnequipHandHeld();
            }
        }

        private void UnequipHandHeld()
        {
            DestroyImmediate(_currentHandheldGameObject);
            _currentHandheldScriptableObject = null;
            _currentHandheldGameObject = null;
            _currentHandHeld = null;
        }

        public void OnAction_00(InputAction.CallbackContext context) {
            if (!context.performed) return;
            _currentHandHeld?.OnAction_00(context);
        }
        
        public void OnAction_01(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            _currentHandHeld?.OnAction_01(context);
        }

        public void OnAction_10(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            SelectHandheldByIndex(0);
        }

        public void OnAction_11(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            SelectHandheldByIndex(1);
        }

        private void SelectHandheldByIndex(int idx)
        {
            _currentHandheldIndex = idx;
            if (!_inventory.TryGetItemByIndex(idx, out var item))
            {
                UnequipHandHeld();
                return;
            };
            if (item is IHandheldInventoryItem handheld) SwitchHandheld(handheld);
        }

        public void OnThrowItem(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            UnequipHandHeld();
            _inventory.RemoveByIndex(_currentHandheldIndex);
        }

        public void OnTakeItem(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            _inventory.AddItem(testItem);
        }
    }
}