using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constant;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.DataAccess.Utilities.Results;
using Core.Utilities.Business;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
  public class ProductManager : IProductService
  {
    IProductDal _productDal;
    ICategoryService _categoryService;

    public ProductManager(IProductDal productDal, ICategoryService categoryService)
    {
      _productDal = productDal;
      _categoryService = categoryService;
    }

    [SecuredOperation("product.add,admin")]
    [ValidationAspect(typeof(ProductValidator))]   
    public IResult Add(Product product)
    {
      IResult result = BusinessRules.Run(CheckIfProductCountOfCategorCorrect(product.CategoryId),
         CheckIfProductNameExists(product.ProductName), CheckCategoryCount());
      if (result != null)
      {
        return result;
      }
      _productDal.Add(product);
      return new SuccessResult(Messages.ProductAdded);
    }

    public IDataResult<List<Product>> GetAll()
    {
      if (DateTime.Now.Hour == 11)
      {
        return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
      }
      return new DataResult<List<Product>>(_productDal.GetAll(), true, Messages.ProductListed);
    }

    public IDataResult<List<Product>> GetAllByCategoryId(int id)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
    }

    public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
    {
      return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
    }

    public IDataResult<Product> GetById(int productId)
    {
      return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public IDataResult<List<ProductDetailDto>> GetProductDetails()
    {
      if (DateTime.Now.Hour == 22)
      {
        return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
      }
      return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
    }

    [ValidationAspect(typeof(ProductValidator))]
    public IResult Update(Product product)
    {
      if (CheckIfProductCountOfCategorCorrect(product.CategoryId).Success)
      {
        _productDal.Add(product);
        return new SuccessResult(Messages.ProductAdded);
      }

      return new ErrorResult();
    }

    IDataResult<List<Product>> IProductService.GetById(int productId)
    {
      throw new NotImplementedException();
    }

    private IResult CheckIfProductCountOfCategorCorrect(int categoryId)
    {
      var result = _productDal.GetAll(p => p.CategoryId == categoryId);
      if (result.Count >= 10)
      {
        return new ErrorResult(Messages.ProductCountCategoryError);
      }
      return new SuccessResult();
    }

    private IResult CheckIfProductNameExists(string productName)
    {
      var result = _productDal.GetAll(p => p.ProductName == productName).Any();
      if (result)
      {
        return new ErrorResult(Messages.ProductNameCategoryAlreadyExists);
      }
      return new SuccessResult();
    }

    private IResult CheckCategoryCount()
    {
      var result = _categoryService.GetAll().Data.Count();

      if (result > 15)
      {
        return new ErrorResult(Messages.CategoryCount);
      }
      return new SuccessResult();
    }
  }
}
