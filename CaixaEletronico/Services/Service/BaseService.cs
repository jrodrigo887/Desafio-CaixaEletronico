using CaixaEletronico.Domain.Interfaces;
using CaixaEletronico.Domain.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Services.Service
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repos)
        {
            _repository = repos;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator 
            : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _repository.Insert(obj);
            return obj;
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public IList<TEntity> Get()
        {
            return _repository.Select();
        }

        public TEntity GetById(long id)
        {
            return _repository.Select(id);
        }

        public TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());
            _repository.Update(obj);
            return obj;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não encontrado!");

            validator.ValidateAndThrow(obj);
        }
    }
}
