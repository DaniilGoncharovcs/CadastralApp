namespace CadastralApplication.Documents.Queries.GetDocument;

public class GetDocumentVm : IMapWith<Document>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Document, GetDocumentVm>()
            .ForMember(documentVm => documentVm.Id,
                opt => opt.MapFrom(document => document.Id))
            .ForMember(documentVm => documentVm.Name,
                opt => opt.MapFrom(document => document.Name));
    }
}