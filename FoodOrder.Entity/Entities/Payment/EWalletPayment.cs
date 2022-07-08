using FoodOrder.Entity.Entities.Payment.Interfaces;

namespace FoodOrder.Entity.Entities.Payment
{
    public class EWalletPayment: IEWalletPayment
    {
        public void Pay(int amount)
        {
             //... detail
        }

        public void ScanQRCode()
        {
             //... detail
        }

        public void LinkToBank(string bankAddress)
        {
             //... detail
        }

        public void TopUp(int amount)
        {
             //... detail
        }
    }
}