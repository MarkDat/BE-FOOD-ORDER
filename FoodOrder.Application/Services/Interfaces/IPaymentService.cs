using System.Threading.Tasks;
using FoodOrder.Entity.Entities;
using FoodOrder.Entity.Entities.Payment;

namespace FoodOrder.Application.Services.Interfaces
{
    public interface IPaymentService
    {
        public Task PayWithBankAccount(BankPayment payment, int amount);
        public Task PayWithEWalletAccount(EWalletPayment payment, int amount);
    }
}