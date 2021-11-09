using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Data.Entity;
using OPLOGInventory.Model.Output;
using OPLOGInventory.Data.UOW;
using OPLOGInventory.Repository.Container;
using OPLOGInventory.Repository.InventoryItem;

namespace OPLOGInventory.Application.QueryApplications
{
    public class QueryApplication : IQueryApplication
    {
        public QueryApplication(IUnitOfWork uow, IContainerRepository containerRepository, IInventoryItemRepository inventoryItemRepository)
        {
            _unitofwork = uow;
            _containerRepository = containerRepository;
            _inventoryItemRepository = inventoryItemRepository;
        }

        private IUnitOfWork _unitofwork { get; }

        private IContainerRepository _containerRepository { get; }

        private IInventoryItemRepository _inventoryItemRepository { get; }

        public IDataResult<List<CurrentStockPerProductDto>> CurrentStockInStock()
        {
            var _inventoryItemList = _inventoryItemRepository.GetAll();

            var result = _inventoryItemList
                .Where(x => x.Type == Model.InventoryItemType.Stock)
                .GroupBy(x => new { x.Product.Name, x.Product.SKU })
                .Select(x => new CurrentStockPerProductDto()
                {
                    SKU = x.Key.SKU,
                    Name = x.Key.Name,
                    Total = (uint)x.Count(),


                }).ToList();


            return DataResult<List<CurrentStockPerProductDto>>.Success(result);
        }

        public IDataResult<List<QueryContainerListDto>> CurrentStockPerContainer()
        {
            try
            {
                var _inventoryItemList = _inventoryItemRepository.GetAll();

                var result = _inventoryItemList.Where(x => x.LineItem.SalesOrder.IsShipped != true)
                    .GroupBy(x => new
                    {
                        x.Product.Name,
                        x.Product.SKU,
                        x.Container.Label
                    }).Select(x => new QueryContainerListDto()
                    {
                        Label = x.Key.Label,
                        Total = (uint)x.Count(),
                        Inventory = new ContainerShortListDto()
                        {
                            SKU = x.Key.SKU,
                            Name = x.Key.Name,
                        },

                    }).OrderBy(x => x.Label).ToList();


                //Yapmak istediğim aşağıdaki sorguydu ama nedense hata veriyor
                //Github ISSUE https://github.com/dotnet/efcore/issues/15279

                //var _containerList = _containerRepository.GetAll();
                //var query2 = _containerList.Select(x => new QueryContainerListDto()
                //{
                //    Label = x.Label,
                //    Inventory = x.Contents.GroupBy(y => new { y.Product.Name, y.Product.SKU }).Select(y => new ContainerShortListDto()
                //    {
                //        Name = y.Key.Name,
                //        SKU = y.Key.SKU,
                //        Total = (uint)y.Count(),
                //    }).ToList()
                //}).ToList();


                return DataResult<List<QueryContainerListDto>>.Success(result);
            }
            catch (Exception ex)
            {
                return DataResult<List<QueryContainerListDto>>.Error(ex.Message);
                throw;
            }

        }

        public IDataResult<List<CurrentStockPerProductDto>> CurrentStockPerProduct()
        {
            var _inventoryItemList = _inventoryItemRepository.GetAll();

            var result = _inventoryItemList
                .Where(x => x.LineItem.SalesOrder.IsShipped != true)
                .GroupBy(x => new { x.Product.Name, x.Product.SKU })
                .Select(x => new CurrentStockPerProductDto()
                {
                    SKU = x.Key.SKU,
                    Name = x.Key.Name,
                    Total = (uint)x.Count(),


                }).ToList();


            return DataResult<List<CurrentStockPerProductDto>>.Success(result);

        }
    }
}
