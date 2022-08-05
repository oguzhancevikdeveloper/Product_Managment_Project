using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
  public class InMemoryProductDal : IProductDal
  {
    List<Product> _products;

    public InMemoryProductDal()
    {
      _products = new List<Product> { 
        new Product  {ProductId=1,CategoryId =1,ProductName ="Bardak", UnıtInStock =30, UnıtPrice = 15},
        new Product  {ProductId=2,CategoryId =2,ProductName ="Kale", UnıtInStock =30, UnıtPrice = 15},
        new Product  {ProductId=3,CategoryId =3,ProductName ="RAM", UnıtInStock =30, UnıtPrice = 15},
        new Product  {ProductId=4,CategoryId =4,ProductName ="Kap", UnıtInStock =30, UnıtPrice = 15},
        new Product  {ProductId=5,CategoryId =5,ProductName ="Matara", UnıtInStock =30, UnıtPrice = 15}
    };
  }
  public void Add(Product product)
  {
      _products.Add(product);
  }

  public void Delete(Product product)
  {
      Product deleteToProduct = _products.SingleOrDefault(p=>p.ProductId == product.ProductId);
      _products.Remove(deleteToProduct);
  }

  public List<Product> GetAll()
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
      updateToProduct.UnıtInStock = product.UnıtInStock;
      updateToProduct.UnıtPrice = product.UnıtPrice;
    }
}
}
