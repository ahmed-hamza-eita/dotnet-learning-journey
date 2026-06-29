

namespace Shared.Models
{
    public class Wallet
    {
        public int Id { set; get; }
        public string? Holder { set; get; }
        public decimal? Balance { set; get; }

        public override string ToString()
        {
            return $"[{Id}] {Holder} {Balance:C}";
        }
    }
}
