
namespace Domain.Entities
{
    public class User
    {
        public Guid Id { get; protected set; }
        
        public string Login { get; protected set; } = string.Empty;
        public string Password { get; protected set; } = string.Empty;
        public string Description { get; protected set; } = string.Empty;

        public int Status { get; protected set; }
        public DateTime Created { get; protected set; }


        public UserCustomer? UserCustomer { get; protected set; }

        public void SetStatus(int status)
            => this.Status = status;

        public static User Create()
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Login = "admin",
                Password = "123456",
                Description = "suporte sistemas",
                Status = 1,
                Created = DateTime.UtcNow
            };
        }
    }
}

