namespace ShoppingCart.Models.Setup.User;

public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
}

