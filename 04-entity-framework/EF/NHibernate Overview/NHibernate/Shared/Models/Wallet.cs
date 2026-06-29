using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class Wallet
    {
        public virtual int Id { set; get; }
        public virtual string Holder { set; get; } = null!;
        public virtual decimal? Balance { set; get; }

        public override string ToString()
        {
            return $"[{Id}] {Holder} {Balance:C}";
        }
    }
}