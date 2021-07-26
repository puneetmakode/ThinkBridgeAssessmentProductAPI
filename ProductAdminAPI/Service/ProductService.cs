using AutoMapper;
using ProductAdminAPI.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductAdminAPI.Service
{
    public class ProductService : IProductService
    {
        private ProductRepository _repository;
        public ProductService(Repository.IProductRepository _repo)
        {
            _repository = new ProductRepository(_repo);
        }

        async Task<List<Models.Product>> IProductService.GetAllProducts()
        {
            try
            {
                List<Repository.Product> lsts = await _repository.GetAllProducts();
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<List<Repository.Product>, List<Models.Product>>()));
                List<Models.Product> modelProd = new List<Models.Product>();
                UserMapper.Map(lsts, modelProd);
                return modelProd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        async Task<List<Models.Product>> IProductService.GetProduct(int id)
        {
            try
            {
                List<Repository.Product> lsts = await _repository.GetProduct(id);
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<List<Repository.Product>, List<Models.Product>>()));
                List<Models.Product> modelProd = new List<Models.Product>();
                UserMapper.Map(lsts, modelProd);
                return modelProd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveProduct(Models.Product product)
        {
            try
            {
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Models.Product, Repository.Product>()));
                Repository.Product prod = new Product();
                UserMapper.Map(product, prod);
                return await _repository.SaveProduct(prod);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateProduct(Models.Product product)
        {
            try
            {
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Models.Product, Repository.Product>()));
                Repository.Product prod = new Product();
                UserMapper.Map(product, prod);
                return await _repository.SaveProduct(prod);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> DeleteProduct(int Id)
        {
            try
            {
                return await _repository.DeleteProduct(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}