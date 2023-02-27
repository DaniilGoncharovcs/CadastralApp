namespace CadastralApplication.Documents.Commands.DeleteDocument;

public class DeleteDocumentCommandValidator : AbstractValidator<DeleteDocumentCommand>
{
    public DeleteDocumentCommandValidator()
        => RuleFor(command => command.Id).NotEqual(Guid.Empty);
}