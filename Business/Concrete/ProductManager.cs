using Business.Abstract;
using Business.Constant;
using Core.DataAccess.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
  public class ProductManager : IProductService
  {
    IProductDal _productDal;

    public ProductManager(IProductDal productDal)
    {
      _productDal = productDal;
    }
    public IDataResult<List<Product>> GetAll()
    {
      return new DataResult(_productDal.GetAll());
    }
     
    public List<Product> GetAllByCategoryId(int id)
    {
      return _productDal.GetAll(p => p.CategoryId == id);
    }

    public List<Product> GetAllByUnitPrice(decimal min, decimal max)
    {
      return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
    }

    public Product GetById(int productId)
    {
      return _productDal.Get(p => p.ProductId == productId);
    }

    public List<ProductDetailDto> GetProductDetails()
    {
      return _productDal.GetProductDetails();
    }

    IResult IProductService.Add(Product product)
    {
      _productDal.Add(product);
      if(product.ProductName.Length < 2)
      {
        return new ErrorResult(Messages.ProductNameInvalid);
      }
      return new SuccessResult(Messages.ProductAdded);
    }
  }
}
