namespace CadastralApplication.Documents.Queries.GetDocumentList;

public class GetDocumentListQueryHandler
    : IRequestHandler<GetDocumentsListQuery, DocumentListVm>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDocumentListQueryHandler(IAppDbContext dbContext, IMapper mapper)
        => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<DocumentListVm> Handle(GetDocumentsListQuery query,
        CancellationToken cancellationToken)
    {
        var documentQuery = _dbContext.Documents
                                  .AsNoTracking();

        if (query.Name is not null)
            documentQuery = documentQuery.Where(document => document.Name == query.Name);

        documentQuery = documentQuery.Select(document => document);

        var result = _mapper.Map<List<DocumentDto>>(await documentQuery.ToListAsync(cancellationToken));

        return new DocumentListVm { Documents = result };
    }
}