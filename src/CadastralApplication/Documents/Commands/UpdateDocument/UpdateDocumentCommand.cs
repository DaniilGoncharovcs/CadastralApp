namespace CadastralApplication.Documents.Commands.UpdateDocument;

public class UpdateDocumentCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}