
namespace Domain.Entities
{
    public class UserCustomer
    {
        public UserCustomer() { }

        public UserCustomer(Guid userGuid, Guid customerGuid)
        {
            UserId = userGuid;
            CustomerId = customerGuid;
        }
        public Guid Id { get; set; }

        public Guid UserId { get; protected set; }
        public User User { get; protected set; }

        public Guid CustomerId { get; protected set; }
        public Customer Customer { get; protected set; }
    }
}

