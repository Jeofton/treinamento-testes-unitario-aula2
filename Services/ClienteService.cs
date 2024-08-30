﻿using GestaoEstoque.Models;
using GestaoEstoque.Repositórios;
using GestaoEstoque.Services;


namespace Gestao.Services
    {
    public class ClienteService : IClienteService
        {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
            {
            _clienteRepository = clienteRepository;
            }

        public async Task<IEnumerable<Cliente>> GetAllClientesAsync()
            {
            return await _clienteRepository.GetAllAsync();
            }

        public async Task<Cliente> GetClienteByIdAsync(int id)
            {
            return await _clienteRepository.GetByIdAsync(id);
            }

        public async Task<Cliente> CreateClienteAsync(Cliente cliente)
            {
            return await _clienteRepository.AddAsync(cliente);
            }

        public async Task<Cliente> UpdateClienteAsync(Cliente cliente)
            {
            return await _clienteRepository.UpdateAsync(cliente);
            }

        public async Task<bool> DeleteClienteAsync(int id)
            {
            return await _clienteRepository.DeleteAsync(id);
            }
        }
    }
