namespace CadastralApplication.Documents.Queries.GetDocument;
public class GetDocumentQueryHandler
    : IRequestHandler<GetDocumentQuery, GetDocumentVm>
{
    private readonly IAppDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDocumentQueryHandler(IAppDbContext context, IMapper mapper)
        => (_dbContext, _mapper) = (context, mapper);

    public async Task<GetDocumentVm> Handle(GetDocumentQuery request,
        CancellationToken cancellationToken)
    {
        var document = await _dbContext.Documents
            .FirstOrDefaultAsync(document => document.Id == request.Id, cancellationToken);

        if (document == null)
            throw new NotFoundException(nameof(Document), request.Id);

        return _mapper.Map<GetDocumentVm>(document);
    }
}