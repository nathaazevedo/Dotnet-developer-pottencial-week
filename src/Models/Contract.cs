namespace src.Models;

public class Contract
{
    public Contract()
    {
        this.CreateDate = DateTime.Now;
        this.TokenId = "000000";
        this.Value = 0;
        this.Paid = false;
    }

    public Contract(string TokenId, double Value)
    {
        this.CreateDate = DateTime.Now;
        this.TokenId = TokenId;
        this.Value = Value;
        this.Paid = false;
    }

    // Id
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public string TokenId { get; set; }

    public double Value { get; set; }

    public bool Paid { get; set; }

    public int PersonId { get; set; }
}