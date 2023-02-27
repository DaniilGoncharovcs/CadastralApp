namespace CadastralWebApp.Services;

public interface IDocumentService
{
    Task<DocumentListVm> GetDocuments();
    GetDocumentVm GetDocumentById(Guid id);
    Guid CreateDocument(CreateDocumentDto dto);
    void UpdateDocument(UpdateDocumentDto dto);
    void DeleteDocument(Guid id);
}