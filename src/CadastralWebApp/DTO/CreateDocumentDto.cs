namespace CadastralWebApp.DTO;
public class CreateDocumentDto : IMapWith<CreateDocumentCommand>
{
    [Required]
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDocumentDto, CreateDocumentCommand>()
            .ForMember(documentCommand => documentCommand.Name,
                opt => opt.MapFrom(documentDto => documentDto.Name));
    }
}