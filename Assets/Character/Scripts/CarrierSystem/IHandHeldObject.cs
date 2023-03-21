namespace Character.CarrierSystem
{
    public interface IHandHeldObject : IHandHeldActions
    {
        void OnAttachedCarrier(CarrierSystem carrierSystem);
        void OnEquip();
        void OnUnequip();
    }
}