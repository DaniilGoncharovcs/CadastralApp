namespace CadastralApplication.Documents.Queries.GetDocument;

public class GetDocumentQuery : IRequest<GetDocumentVm>
{
    public Guid Id { get; set; }
}