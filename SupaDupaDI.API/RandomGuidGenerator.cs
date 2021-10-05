using System;

namespace SupaDupaDI.API
{
    public class RandomGuidGenerator
    {
        public Guid RandomGuid { get; set; } = Guid.NewGuid();
    }
}
