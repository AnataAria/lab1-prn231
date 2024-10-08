﻿using System.Reflection;
using Models.Entities;

namespace Services;

public interface IProductService
{
    public abstract List<Product> GetProducts ();
    public abstract Product GetProductById (int prodId);
    public abstract void SaveProduct(Product p);
    public abstract void UpdateProduct(Product p);
    public abstract void RemoveProduct (Product p);
}
