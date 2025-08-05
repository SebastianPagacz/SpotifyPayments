namespace SpotifyPayment.Domain.Models;

public class ClientModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
}
