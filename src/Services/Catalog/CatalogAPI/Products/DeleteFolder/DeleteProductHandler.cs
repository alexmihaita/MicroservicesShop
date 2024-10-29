using System;
using CatalogAPI.Exceptions;

namespace CatalogAPI.Products.DeleteFolder;

public record DeleteProductCommand(Guid Id) 
    : ICommand<DeleteProductResult>;
public record DeleteProductResult(bool IsSuccess);

internal class DeleteProductHandler(IDocumentSession session) : ICommandHandler<DeleteProductCommand, DeleteProductResult>
{
    public async Task<DeleteProductResult> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        session.Delete<Product>(request.Id);
        await session.SaveChangesAsync();

        return new DeleteProductResult(true);
    }
}
