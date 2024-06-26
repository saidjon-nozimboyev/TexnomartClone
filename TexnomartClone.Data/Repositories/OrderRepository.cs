﻿using TexnomartClone.Data.DbContexts;
using TexnomartClone.Data.Interfaces;
using TexnomartClone.Domain.Entities;

namespace TexnomartClone.Data.Repositories;

public class OrderRepository(AppDbContext dbContext) 
    : GenericRepository<Order>(dbContext), IOrderRepository
{
}
