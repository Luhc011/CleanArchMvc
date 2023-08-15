using CleanArchMvc.Application.ProductsCQRS.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.ProductsCQRS.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.Id);

            if (product == null)
                throw new ApplicationException($"Error couldn't be found");

            else
            {
                product.UpdateProduct(request.Name, request.Description, request.Price, request.Stock,
                                      request.Image, request.CategoryId);

                return await _productRepository.Update(product);
            }
        }
    }
}
