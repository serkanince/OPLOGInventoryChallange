using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Model;
using OPLOGInventory.Model.Output;
using OPLOGInventory.Data.UOW;
using OPLOGInventory.Repository.InventoryItem;
using OPLOGInventory.Repository.Product;
using OPLOGInventory.Repository.Rules;
using OPLOGInventory.Repository.SalesOrder;

namespace OPLOGInventory.Application.SalesOrders
{
    public class SalesOrderApplication : ISalesOrderApplication
    {
        public SalesOrderApplication(IUnitOfWork uow, ISalesOrderRepository salesorderRepository, IProductRepository productRepository, IInventoryItemRepository inventoryRepository, IMapper mapper)
        {
            _unitofwork = uow;
            _salesorderRepository = salesorderRepository;
            _productRepository = productRepository;
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        private IMapper _mapper { get; }
        private IUnitOfWork _unitofwork { get; }
        private ISalesOrderRepository _salesorderRepository { get; }

        private IInventoryItemRepository _inventoryRepository { get; }

        private IProductRepository _productRepository { get; }

        public IResult CancelSalesOrder(string referenceNo)
        {
            try
            {
                var salesOrder = _salesorderRepository.readByReferenceNo(referenceNo);
                _salesorderRepository.updateCancelStatus(salesOrder);

                var lineItems = salesOrder.LineItems.ToList();

                foreach (var lineItem in lineItems)
                {
                    foreach (var inventoryItem in lineItem.InventoryItem)
                    {
                        inventoryItem.Type = Model.InventoryItemType.Stock;
                        inventoryItem.LineItemId = null;
                        _inventoryRepository.Update(inventoryItem);
                    }
                }

                _unitofwork.SaveChanges();

                return Result.Success();
            }
            catch (BusinessRuleValidationException ex)
            {
                return Result.Error(ex.Details);
            }
        }

        public IResult CreateSalesOrder(SalesOrderDto input)
        {
            try
            {
                for (int i = 0; i < input.LineItems.Count; i++)
                {
                    var product = _productRepository.readBySKU(input.LineItems[i].ProductSKU);
                    if (product == null)
                        return Result.Error("Line Items must be products already defined in the system.");
                    input.LineItems[i].ProductId = product.ID;
                }

                var _entity = _salesorderRepository.Insert(_mapper.Map<SalesOrderDto, SalesOrder>(input));

                foreach (var lineItemEntity in _entity.LineItems)
                {
                    IQueryable<InventoryItem> foundInventoryItems = _inventoryRepository
                        .FindBy(x => x.ProductId == lineItemEntity.ProductId && x.Type == Model.InventoryItemType.Stock)
                        .OrderBy(x => x.Container.Location.x)
                        .ThenBy(x => x.Container.Location.y)
                        .ThenBy(x => x.Container.Location.z).Take((int)lineItemEntity.Quantity);

                    foreach (var inventoryItem in foundInventoryItems)
                    {
                        inventoryItem.LineItemId = lineItemEntity.ID;
                        inventoryItem.Type = Model.InventoryItemType.Reserved;

                        _inventoryRepository.Update(inventoryItem);
                    }
                }

                _unitofwork.SaveChanges();

                return Result.Success();
            }
            catch (BusinessRuleValidationException ex)
            {
                return Result.Error(ex.Details);
            }
        }

        public IDataResult<List<SalesOrderListDto>> ListSalesOrder()
        {
            try
            {
                var salesOrders = _salesorderRepository.GetAll();

                var _salesOrders = salesOrders.Select(x => new SalesOrderListDto()
                {
                    ReceiverName = x.ReceiverName,
                    ReceiverAddress = x.ReceiverAddress,
                    ReferanceNo = x.ReferanceNo,
                    CancelledDate = x.CancelledDate,
                    IsShipped = x.IsShipped,
                    ShippedDate = x.ShippedDate,
                    LineItems = x.LineItems.Select(y => new LineItemListDto()
                    {
                        InventoryItems = y.InventoryItem.Select(inventory => new InventoryItemListDto()
                        {
                            Product = new ProductListDto()
                            {
                                Name = inventory.Product.Name,
                                ImageUrl = inventory.Product.ImageUrl,
                                SKU = inventory.Product.SKU,
                                Dimension = new DimensionListDto()
                                {
                                    Height = inventory.Product.Dimension.Height,
                                    Length = inventory.Product.Dimension.Length,
                                    Weight = inventory.Product.Dimension.Weight,
                                    Width = inventory.Product.Dimension.Width,
                                },
                                Barcodes = inventory.Product.Barcodes.Select(barcodes => new BarcodeListDto()
                                {
                                    Label = barcodes.Label
                                }).ToList(),
                            },
                            Container = new ContainerListDto()
                            {
                                Label = inventory.Container.Label,
                                Location = new LocationListDto()
                                {
                                    x = inventory.Container.Location.x,
                                    y = inventory.Container.Location.y,
                                    z = inventory.Container.Location.z,
                                }
                            },
                            Type = inventory.Type,
                        }).ToList(),
                        Quantity = y.Quantity,
                    }).ToList(),
                }).ToList();

                return DataResult<List<SalesOrderListDto>>.Success(_salesOrders);
            }
            catch (BusinessRuleValidationException ex)
            {
                return DataResult<List<SalesOrderListDto>>.Error(ex.Details);
            }
        }

        public IResult ShipSalesOrder(string referenceNo)
        {
            try
            {
                var salesOrder = _salesorderRepository.readByReferenceNo(referenceNo);
                _salesorderRepository.updateShippedStatus(salesOrder);



                return Result.Success();
            }
            catch (BusinessRuleValidationException ex)
            {
                return Result.Error(ex.Details);
            }
        }
    }
}
