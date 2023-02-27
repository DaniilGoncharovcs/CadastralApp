namespace CadastralWebApp.Controllers;

public class DocumentController : Controller
{
    private readonly IDocumentService _documentService;

    public DocumentController(IDocumentService documentService)
        => _documentService = documentService;

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var vm = await _documentService.GetDocuments();
        return View(vm);
    }
}