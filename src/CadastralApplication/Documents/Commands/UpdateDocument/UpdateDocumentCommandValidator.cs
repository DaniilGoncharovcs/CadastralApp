namespace CadastralApplication.Documents.Commands.UpdateDocument;

public class UpdateDocumentCommandValidator : AbstractValidator<UpdateDocumentCommand>
{
    public UpdateDocumentCommandValidator()
    {
        RuleFor(command =>
            command.Id).NotEqual(Guid.Empty);
        RuleFor(command =>
            command.Name).NotEmpty().MaximumLength(100);
    }
}