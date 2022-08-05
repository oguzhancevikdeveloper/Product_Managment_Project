using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
  public class EfProductDal : IProductDal
  {

    List<Product> _products;

    public EfProductDal()
    {
      _products = new List<Product> {
        new Product  {ProductId=1,CategoryId =1,ProductName ="FERRAI", },
        new Product  {ProductId=2,CategoryId =2,ProductName ="LAMBO" }

    };
    }
    public void Add(Product product)
    {
      throw new NotImplementedException();
    }

    public void Delete(Product product)
    {
      throw new NotImplementedException();
    }

    public List<Product> GetAll()
    {
      return _products; 
    }

    public List<Product> GetAllByCategory(int categoryId)
    {
      throw new NotImplementedException();
    }

    public void Update(Product product)
    {
      throw new NotImplementedException();
    }
  }
}
