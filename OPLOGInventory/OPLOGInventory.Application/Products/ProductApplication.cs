using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DTO;
using OPLOGInventory.Infrastructure.UOW;
using OPLOGInventory.Repository.Product;
using OPLOGInventory.Repository.Rules;

namespace OPLOGInventory.Application.Products
{
    public class ProductApplication : IProductApplication
    {
        public ProductApplication(IUnitOfWork uow, IProductRepository productRepository, IMapper mapper)
        {
            _unitofwork = uow;
            _productRepository = productRepository;
            _mapper = mapper;

        }

        private IMapper _mapper { get; }
        private IUnitOfWork _unitofwork { get; }
        private IProductRepository _productRepository { get; }

        public IResult CreateProduct(ProductDto input)
        {
            try
            {
                var _entity = _productRepository.Insert(_mapper.Map<ProductDto, Product>(input));

                _unitofwork.SaveChanges();

                return Result.Success();
            }
            catch (BusinessRuleValidationException ex)
            {
                return Result.Error(ex.Details);
            }
        }

        public IResult DeleteProduct(string sku)
        {
            try
            {
                var _entity = _productRepository.readBySKU(sku);

                if (_entity != null)
                {
                    _entity = _productRepository.Remove(_entity);
                    _unitofwork.SaveChanges();
                    return Result.Success();
                }
                else
                {
                    return Result.Error("Product not found !");
                }

            }
            catch (BusinessRuleValidationException ex)
            {
                return Result.Error(ex.Details);
            }
        }
    }
}
