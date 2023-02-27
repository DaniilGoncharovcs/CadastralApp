namespace CadastralApplication.Documents.Queries.GetDocument;

public class GetDocumentQueryValidator : AbstractValidator<GetDocumentQuery>
{
    public GetDocumentQueryValidator()
        => RuleFor(document => document.Id).NotEqual(Guid.Empty);
}