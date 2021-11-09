using OPLOGInventory.Application.ResultModel;
using OPLOGInventory.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OPLOGInventory.Application.Products
{
    public interface IProductApplication
    {
        IResult CreateProduct(ProductDto input);
        IResult DeleteProduct(string sku);
    }
}
