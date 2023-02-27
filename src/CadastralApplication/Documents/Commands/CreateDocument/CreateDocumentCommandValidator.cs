namespace CadastralApplication.Documents.Commands.CreateDocument;

public class CreateDocumentCommandValidator : AbstractValidator<CreateDocumentCommand>
{
    public CreateDocumentCommandValidator()
        => RuleFor(command => command.Name).NotEmpty().MaximumLength(100);
}