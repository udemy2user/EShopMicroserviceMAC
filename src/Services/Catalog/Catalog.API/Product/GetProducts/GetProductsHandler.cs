
namespace Catalog.API.Product.GetProducts;

public record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsResult>;

public record GetProductsResult(IEnumerable<Models.Product> Products);

internal class GetProductsQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        // logger.LogInformation("Products query");
        var products = await session.Query<Models.Product>()
            .ToListAsync(cancellationToken);
        return new GetProductsResult(products);
    }
}

