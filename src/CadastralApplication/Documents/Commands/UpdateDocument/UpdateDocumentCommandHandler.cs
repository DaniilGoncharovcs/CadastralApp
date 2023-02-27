namespace CadastralApplication.Documents.Commands.UpdateDocument;

public class UpdateDocumentCommandHandler
    : IRequestHandler<UpdateDocumentCommand>
{
    private readonly IAppDbContext _dbContext;

    public UpdateDocumentCommandHandler(IAppDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<Unit> Handle(UpdateDocumentCommand command,
        CancellationToken cancellationToken)
    {
        var document = await _dbContext.Documents
                             .FirstOrDefaultAsync(document => document.Id == command.Id,
                             cancellationToken);

        if (document is null)
            throw new NotFoundException(nameof(Document), command.Id);

        document.Name = command.Name;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}