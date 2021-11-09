using AutoMapper;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Model;
using OPLOGInventory.Data.UOW;
using OPLOGInventory.Repository.Container;
using OPLOGInventory.Repository.InventoryItem;
using OPLOGInventory.Repository.Product;
using OPLOGInventory.Repository.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.InventoryItems
{
    public class InventoryItemApplication : IInventoryItemApplication
    {
        public InventoryItemApplication(IUnitOfWork uow, IInventoryItemRepository inventoryItemRepository, IMapper mapper, IProductRepository productRepository,
            IContainerRepository containerRepository)
        {
            _unitofwork = uow;
            _inventoryItemRepository = inventoryItemRepository;
            _mapper = mapper;
            _productRepository = productRepository;
            _containerRepository = containerRepository;
        }

        private IMapper _mapper { get; }
        private IUnitOfWork _unitofwork { get; }
        private IInventoryItemRepository _inventoryItemRepository { get; }

        private IProductRepository _productRepository { get; }

        private IContainerRepository _containerRepository { get; }


        public IResult CreateProduct(InventoryItemDto input)
        {
            try
            {
                var product = _productRepository.readBySKU(input.SKU);
                if (product == null)
                    return Result.Error("Product SKU it is not fount !");

                var container = _containerRepository.ReadByLabel(input.Label);
                if (container == null)
                    return Result.Error("Container Label it is not fount !");

                input.ContainerId = container.ID;
                input.ProductId = product.ID;

                var _entity = _inventoryItemRepository.Insert(_mapper.Map<InventoryItemDto, InventoryItem>(input));

                _unitofwork.SaveChanges();

                return Result.Success();
            }
            catch (BusinessRuleValidationException ex)
            {
                return Result.Error(ex.Details);
            }
        }
    }
}
