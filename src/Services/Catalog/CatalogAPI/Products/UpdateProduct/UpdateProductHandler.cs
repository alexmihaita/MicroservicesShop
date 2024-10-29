using System;
using CatalogAPI.Exceptions;
using Marten.Linq.SoftDeletes;

namespace CatalogAPI.Products.UpdateProduct;
public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, decimal Price, string ImageFile) 
    : ICommand<UpdateProductResult>;
public record UpdateProductResult(bool IsSuccess);
internal class UpdateProductHandler(IDocumentSession session) : ICommandHandler<UpdateProductCommand, UpdateProductResult>
{
    public async Task<UpdateProductResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var result = await session.LoadAsync<Product>(request.Id, cancellationToken);
        if (result is null) 
        {
            throw new ProductNotFoundException(request.Id);
        }

        result.Name = request.Name;
        result.Category = request.Category;
        result.Description = request.Description;
        result.Price = request.Price;
        result.ImageFile = request.ImageFile;

        session.Update(result);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductResult(true);
    }
}
