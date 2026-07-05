
using System.ComponentModel.DataAnnotations.Schema;


namespace Sahred.Entities
{

    //exclude way 1

    [NotMapped]
   public class Snapshot
    {
        public DateTime LoadedAt => DateTime.UtcNow;
        public string Version => Guid.NewGuid().ToString().Substring(0, 6);
    }
}
