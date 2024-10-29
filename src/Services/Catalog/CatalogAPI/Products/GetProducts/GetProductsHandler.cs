using System;
using Marten.Pagination;

namespace CatalogAPI.Products.GetProducts;

public record GetProductsQuery(int? PageNumer = 1, int? PageSize = 10) : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);

internal class GetProductsQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToPagedListAsync(request.PageNumer ?? 1, request.PageSize ?? 1, cancellationToken);

        return new GetProductsResult(products);
    }
}
