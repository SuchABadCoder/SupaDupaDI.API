using System;
using SupaDupaDI.API.Interfaces;

namespace SupaDupaDI.API.Services
{
    public class SupaService : ISupaService
    {
        private readonly IDupaService _dupaService;

        public SupaService(IDupaService dupaService)
        {
            _dupaService = dupaService;
        }

        public void PrintSomeDupa() => Console.WriteLine(_dupaService.DupaGuid);
    }
}
