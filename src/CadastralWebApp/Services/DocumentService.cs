namespace CadastralWebApp.Services;

public class DocumentService : IDocumentService
{
    private readonly HttpClient _httpClient;

    public DocumentService(HttpClient httpClient)
        => _httpClient = httpClient;

    public Guid CreateDocument(CreateDocumentDto dto)
    {
        throw new NotImplementedException();
    }

    public void DeleteDocument(Guid id)
    {
        throw new NotImplementedException();
    }

    public GetDocumentVm GetDocumentById(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<DocumentListVm> GetDocuments()
        => await _httpClient.GetFromJsonAsync<DocumentListVm>("api/1/document");

    public void UpdateDocument(UpdateDocumentDto dto)
    {
        throw new NotImplementedException();
    }
}