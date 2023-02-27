namespace CadastralApplication.Documents.Commands.CreateDocument;

public class CreateDocumentCommand : IRequest<Guid>
{
    public string Name { get; set; }
}