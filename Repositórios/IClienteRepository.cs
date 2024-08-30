﻿using GestaoEstoque.Models;

namespace GestaoEstoque.Repositórios
    {
    public interface IClienteRepository
        {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente> GetByIdAsync(int id);
        Task<Cliente> AddAsync(Cliente cliente);
        Task<Cliente> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(int id);
        }
    }
