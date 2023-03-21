using UnityEngine.InputSystem;

namespace Character.CarrierSystem
{
    public interface IHandHeldActions
    {
        void OnAction_00(InputAction.CallbackContext context);

        void OnAction_01(InputAction.CallbackContext context);
    }
}