using CadastralWebApp.DTO;
using Microsoft.AspNetCore.Authorization;

namespace CadastralWebApp.Controllers;

[ApiVersion("1.0")]
[Produces("application/json")]
[Route("api/{version:apiVersion}/document")]
[Authorize(Roles = "admin")]
public class DocumentApiController : BaseController
{
    private readonly IMapper _mapper;

    public DocumentApiController(IMapper mapper)
        => _mapper = mapper;

    /// <summary>
    /// Get the list of documents
    /// </summary>
    /// <remarks>
    /// Sample request: <br/>
    /// GET /document
    /// </remarks>
    /// <param name="name">Optional filter for name of document</param>
    /// <returns>Returnes DocumentListVm</returns>
    /// <response code="200">Success</response>
    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<DocumentListVm>> GetAll(string name = null)
    {
        var query = new GetDocumentsListQuery
        {
            Name = name
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Gets the document by id
    /// </summary>
    /// <remarks>
    /// Sample request: <br/>
    /// GET /document/D34D349E-43B8-429E-BCA4-793C932FD580
    /// </remarks>
    /// <param name="id">Document id (guid)</param>
    /// <returns>Returnes GetDocumentVm</returns>
    /// <response code="200">Success</response>
    [AllowAnonymous]
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<GetDocumentVm>> Get(Guid id)
    {
        var query = new GetDocumentQuery
        {
            Id = id
        };

        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    /// <summary>
    /// Creates the document
    /// </summary>
    /// <remarks>
    /// Sample request: <br/>
    /// POST /document <br/>
    /// {
    ///     name: "document name"
    /// }
    /// </remarks>
    /// <param name="createDocumentDto">CreateDocumentDto object</param>
    /// <returns>Returnes id (guid)</returns>
    /// <response code="201">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDocumentDto createDocumentDto)
    {
        var command = _mapper.Map<CreateDocumentCommand>(createDocumentDto);

        var documentId = await Mediator.Send(command);

        return CreatedAtAction(nameof(Get), new { id = documentId }, documentId);
    }

    /// <summary>
    /// Updates the document
    /// </summary>
    /// <remarks>
    /// Sample request: <br/>
    /// PUT /document <br/>
    /// {
    ///     name: "updated document name"
    /// }
    /// </remarks>
    /// <param name="updateDocumentDto">UpdateDocumentDto object</param>
    /// <returns>Returnes NoContent</returns>
    /// <response code="204">Success</response>
    /// <response code="401">If the user is unauthorized</response>
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update([FromBody] UpdateDocumentDto updateDocumentDto)
    {
        var command = _mapper.Map<UpdateDocumentCommand>(updateDocumentDto);

        await Mediator.Send(command);
        return NoContent();
    }

    /// <summary>
    /// Deletes the document by id
    /// </summary>
    /// <remarks>
    /// Sample request: <br/>
    /// DELETE /document/88DEB432-062F-43DE-8DCD-8B6EF79073D3
    /// </remarks>
    /// <param name="id">Id of the document (guid)</param>
    /// <returns>Returnes NoContent</returns>
    /// <responce code="204">Success</responce>
    /// <responce code="401">If the user is unauthorized</responce>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteDocumentCommand
        {
            Id = id,
        };

        await Mediator.Send(command);
        return NoContent();
    }

}