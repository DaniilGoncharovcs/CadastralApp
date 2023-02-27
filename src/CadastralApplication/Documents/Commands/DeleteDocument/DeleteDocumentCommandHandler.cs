namespace CadastralApplication.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommandHandler
    : IRequestHandler<DeleteDocumentCommand>
{
    private readonly IAppDbContext _dbContext;

    public DeleteDocumentCommandHandler(IAppDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteDocumentCommand command,
        CancellationToken cancellationToken)
    {
        var document = await _dbContext.Documents
                             .FirstOrDefaultAsync(document => document.Id == command.Id,
                             cancellationToken);

        if(document is null)
            throw new NotFoundException(nameof(Document),command.Id);

        _dbContext.Documents .Remove(document);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}