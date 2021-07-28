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

        async Task<List<Models.ProductModel>> IProductService.GetAllProducts()
        {
            try
            {
                List<Repository.Product> lsts = await _repository.GetAllProducts();
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Repository.Product, Models.ProductModel>()));
                List<Models.ProductModel> modelProd = new List<Models.ProductModel>();
                UserMapper.Map(lsts, modelProd);
                return modelProd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        async Task<List<Models.ProductModel>> IProductService.GetProduct(int id)
        {
            try
            {
                List<Repository.Product> lsts = await _repository.GetProduct(id);
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Repository.Product, Models.ProductModel>()));
                List<Models.ProductModel> modelProd = new List<Models.ProductModel>();
                UserMapper.Map(lsts, modelProd);
                return modelProd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> SaveProduct(Models.ProductModel product)
        {
            try
            {
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Models.ProductModel, Repository.Product>()));
                Repository.Product prod = new Product();
                product.CreatedDate = DateTime.Now;
                product.ModifiedDate = DateTime.Now;
                UserMapper.Map(product, prod);
                return await _repository.SaveProduct(prod);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> UpdateProduct(Models.ProductModel product)
        {
            try
            {
                Mapper UserMapper = new Mapper(new MapperConfiguration(cfg => cfg.CreateMap<Models.ProductModel, Repository.Product>()));
                Repository.Product prod = new Product();
                product.ModifiedDate = DateTime.Now;
                UserMapper.Map(product, prod);
                prod.ModifiedBy = "Admin";
                prod.ModifiedDate = DateTime.Now;
                return await _repository.UpdateProduct(prod);
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