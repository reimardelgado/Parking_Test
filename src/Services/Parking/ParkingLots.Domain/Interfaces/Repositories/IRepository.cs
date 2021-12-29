using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Specification;
using ParkingLots.Domain.Entities;

namespace ParkingLots.Domain.Interfaces.Repositories
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T>(Guid id) where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>() where T : BaseEntity, IAggregateRoot;
        Task<List<T>> ListAsync<T>(ISpecification<T> spec) where T : BaseEntity, IAggregateRoot;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task UpdateAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task DeleteAsync<T>(T entity) where T : BaseEntity, IAggregateRoot;
        Task<int> CountAsync<T>(ISpecification<T> specification) where T : BaseEntity, IAggregateRoot;
        Task<int> CountAsync<T>() where T : BaseEntity, IAggregateRoot;
    }
}

