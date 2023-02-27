namespace CadastralApplication.Documents.Queries.GetDocumentList;

public class DocumentDto : IMapWith<Document>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Document, DocumentDto>();
    }
}