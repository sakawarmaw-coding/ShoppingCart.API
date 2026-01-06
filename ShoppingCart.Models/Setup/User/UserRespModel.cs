namespace ShoppingCart.Models.Setup.User;

public class UserRespModel
{
    public string LoginName { get; set; } = string.Empty;
    public string AccessToken { get; set; } = string.Empty;
    public int ExpireSecond { get; set; }
}
