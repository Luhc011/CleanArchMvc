﻿using CleanArchMvc.Domain.Entities;
using MediatR;

namespace CleanArchMvc.Application.ProductsCQRS.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
