namespace CadastralApplication.Documents.Commands.CreateDocument;

public class CreateDocumentCommandHandler
    : IRequestHandler<CreateDocumentCommand, Guid>
{
    private readonly IAppDbContext _dbContext;

    public CreateDocumentCommandHandler(IAppDbContext dbContext)
        => _dbContext = dbContext;

    public async Task<Guid> Handle(CreateDocumentCommand command,
        CancellationToken cancellationToken)
    {
        var document = new Document
        {
            Id = Guid.NewGuid(),
            Name = command.Name,
        };

        await _dbContext.Documents.AddAsync(document, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return document.Id;
    }
}