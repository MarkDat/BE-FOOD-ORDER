using System.Threading.Tasks;
using FoodOrder.Application.SeedWorks;
using FoodOrder.Application.Services.Interfaces;
using FoodOrder.Entity.Entities.Payment;
using FoodOrder.Infrastructure.SeedWorks;

namespace FoodOrder.Application.Services
{
    public class PaymentService : BaseService, IPaymentService
    {
        private readonly IRepository<BankPayment> _bankPaymentRepository;
        private readonly IRepository<EWalletPayment> _eWalletPaymentRepository;
        
        public PaymentService(IUnitOfWork unitOfWork, IRepository<BankPayment> bankPaymentRepository, IRepository<EWalletPayment> eWalletPaymentRepository) : base(unitOfWork)
        {
            _bankPaymentRepository = bankPaymentRepository;
            _eWalletPaymentRepository = eWalletPaymentRepository;
        }

        public async Task PayWithBankAccount(BankPayment payment, int amount)
        {
            // Handle logic
        }

        public async Task PayWithEWalletAccount(EWalletPayment payment, int amount)
        {
            // Handle logic
        }
    }
}