using AutoMapper;
using CleaArchMVC.Application.DTOs;
using CleaArchMVC.Application.Interfaces;
using CleaArchMVC.Domain.Entities;
using CleaArchMVC.Domain.Interfaces;

namespace CleaArchMVC.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _producRepository;
        private readonly IMapper _mapper;
        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _producRepository = productRepository ??
                throw new ArgumentNullException(nameof(productRepository));
            
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntities = await _producRepository.GetProductAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntities);
        }

        public async Task<ProductDTO> GetById(int id)
        {
            var productsEntity = await _producRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productsEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _producRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task Add(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _producRepository.CreateAsync(productEntity);
        }

        public async Task Update(ProductDTO productDto)
        {
            var productEntity = _mapper.Map<Product>(productDto);
            await _producRepository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _producRepository.GetByIdAsync(id).Result;
            await _producRepository.RemoveAsync(productEntity);
        }
    }
}
