﻿using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using CleanArchMvc.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchMvc.Infra.Data.Repositories;

public class ProductRepository : IProductRepository
{
    private ApplicationDbContext _contextProduct;
    public ProductRepository(ApplicationDbContext context)
    {
        _contextProduct = context;
    }

    public async Task<Product> CreateAsync(Product product)
    {
        _contextProduct.Add(product);
        await _contextProduct.SaveChangesAsync();

        return product;
    }

    public async Task<Product> GetByIdAsync(int? id)
    {
        return await _contextProduct.Products.Include(c => c.Category).SingleOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Product>> GetProductsAsync()
    {
        return await _contextProduct.Products.ToListAsync();
    }

    public async Task<Product> RemoveAsync(Product product)
    {
        _contextProduct.Remove(product);
        await _contextProduct.SaveChangesAsync();

        return product;
    }

    public async Task<Product> UpdateAsync(Product product)
    {
        _contextProduct.Update(product);
        await _contextProduct.SaveChangesAsync();

        return product;
    }
}
