using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
  public class InMemoryProductDal : IProductDal
  {
    List<Product> _products;

    public InMemoryProductDal()
    {
      _products = new List<Product> {
        new Product  {ProductId=1,CategoryId =1,ProductName ="Bardak", UnitsInStock =30, UnitPrice = 15},
        new Product  {ProductId=2,CategoryId =2,ProductName ="Kale", UnitsInStock =30, UnitPrice = 15},
        new Product  {ProductId=3,CategoryId =3,ProductName ="RAM", UnitsInStock =30, UnitPrice = 15},
        new Product  {ProductId=4,CategoryId =4,ProductName ="Kap", UnitsInStock =30, UnitPrice = 15},
        new Product  {ProductId=5,CategoryId =5,ProductName ="Matara", UnitsInStock =30, UnitPrice = 15}
    };
    }
    public void Add(Product product)
    {
      _products.Add(product);
    }

    public void Delete(Product product)
    {
      Product deleteToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
      _products.Remove(deleteToProduct);
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
      throw new NotImplementedException();
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
      return _products;
    }

    public List<Product> GetAllByCategory(int categoryId)
    {

      return _products.Where(x => x.CategoryId == categoryId).ToList();
    }

    public void Update(Product product)
    {
      Product updateToProduct = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
      updateToProduct.ProductId = product.ProductId;
      updateToProduct.CategoryId = product.CategoryId;
      updateToProduct.ProductName = product.ProductName;
      updateToProduct.UnitsInStock = product.UnitsInStock;
      updateToProduct.UnitPrice = product.UnitPrice;
    }
  }
}
