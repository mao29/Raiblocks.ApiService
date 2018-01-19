﻿using Lykke.Service.RaiblocksApi.Core.Repositories;
using Lykke.Service.RaiblocksApi.Core.Repositories.Balances;
using Lykke.Service.RaiblocksApi.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lykke.Service.RaiblocksApi.Services
{
    public class BlockchainService : IBlockchainService
    {
        private readonly IBalanceObservationRepository _balanceObservationRepository;

        public BlockchainService(IBalanceObservationRepository balanceObservationRepository)
        {
            this._balanceObservationRepository = balanceObservationRepository;
        }
        public async Task<bool> AddBalanceObservation(string address)
        {
            return await _balanceObservationRepository.CreateIfNotExistsAsync(address);
        }

        public async Task<bool> RemoveBalanceObservation(string address)
        {
            return await _balanceObservationRepository.DeleteIfExistAsync(address);
        }

        public async Task<bool> IsBalanceObserved(string address)
        {
            return await _balanceObservationRepository.IsExistAsync(address);
        }
    }
}