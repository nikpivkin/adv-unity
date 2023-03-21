using UnityEngine;
using UnityEngine.InputSystem;

namespace Character.CarrierSystem
{
    public class HandheldItem : MonoBehaviour, IHandHeldObject
    {
        private CarrierSystem _carrierSystem;

        public void OnAction_00(InputAction.CallbackContext context)
        {
            Debug.Log("Action0");
        }

        public void OnAction_01(InputAction.CallbackContext context)
        {
            Debug.Log("Action1");
        }

        public void OnAttachedCarrier(CarrierSystem carrierSystem)
        {
            _carrierSystem = carrierSystem;
        }

        public void OnEquip()
        {
            Debug.Log("Equip");
        }

        public void OnUnequip()
        {
            Debug.Log("Unequip");
        }
    }
}
