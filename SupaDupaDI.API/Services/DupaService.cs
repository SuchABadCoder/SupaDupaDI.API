using System;
using SupaDupaDI.API.Interfaces;

namespace SupaDupaDI.API.Services
{
    public class DupaService : IDupaService
    {
        public Guid DupaGuid { get; } = Guid.NewGuid();
    }
}
