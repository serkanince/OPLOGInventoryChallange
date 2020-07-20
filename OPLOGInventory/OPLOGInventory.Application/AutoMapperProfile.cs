using AutoMapper;
using OPLOGInventory.Domain.Entity;
using OPLOGInventory.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<Barcode, BarcodeDto>();
            CreateMap<BarcodeDto, Barcode>();
            CreateMap<SalesOrderDto, SalesOrder>();
            CreateMap<SalesOrder, SalesOrderDto>();
            CreateMap<LineItemDto, LineItem>();
            CreateMap<LineItem, LineItemDto>();
            CreateMap<ApiUser, ApiUserDto>();
            CreateMap<ApiUserDto, ApiUser>();
            CreateMap<InventoryItemDto, InventoryItem>();
            CreateMap<InventoryItem, InventoryItemDto>();
            CreateMap<Container, ContainerDto>();
            CreateMap<ContainerDto, Container>();
            CreateMap<Location, LocationDto>();
            CreateMap<LocationDto, Location>();
        }
    }
}
