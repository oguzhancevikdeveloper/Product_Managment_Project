using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constant
{
  public static class Messages
  {
    public static string ProductAdded = "Ürün Eklendi.";
    public static string ProductNameInvalid = "Ürün ismi Geçersiz!";
    public static string MaintenanceTime = "Sistem bakımda";
    public static string ProductListed = "Ürünler Listelendi!";
    public static string ProductCountCategoryError="Bir kategoride en fazla 10 ürün olabilir";
    public static string ProductNameCategoryAlreadyExists="Bu ürün zaten mevcut";
    public static string CategoryCount ="Category sayısı 15'i geçemez";
  }
}
