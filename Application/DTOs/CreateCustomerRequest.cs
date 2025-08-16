
namespace Application.DTOs;

public class CreateCustomerRequest
{
    public string TypeCustomer { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Document { get; set; } = string.Empty;
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}