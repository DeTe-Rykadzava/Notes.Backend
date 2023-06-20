using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NSwag;
using NSwag.CodeGeneration.TypeScript;

namespace Notes.WebAPI.Controllers;

[Route("api/client")]
[ApiController]
[AllowAnonymous]
public class ClientController : Controller
{
    private string _jsonHardData = "{\"openapi\":\"3.0.1\",\"info\":{\"title\":\"Notes API 1.0\",\"description\":\"A simple example ASP NER Core Web API. Professional way\",\"version\":\"1.0\"},\"paths\":{\"/api/client/typescript/angular\":{\"get\":{\"tags\":[\"Client\"],\"operationId\":\"Get\",\"parameters\":[{\"name\":\"api-version\",\"in\":\"query\",\"required\":true,\"style\":\"form\",\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"text/plain\":{\"schema\":{\"type\":\"string\"}},\"application/json\":{\"schema\":{\"type\":\"string\"}},\"text/json\":{\"schema\":{\"type\":\"string\"}}}}}}},\"/api/{version}/Note\":{\"get\":{\"tags\":[\"Note\"],\"operationId\":\"GetAll\",\"parameters\":[{\"name\":\"version\",\"in\":\"path\",\"required\":true,\"style\":\"simple\",\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/NoteListVm\"}}}},\"401\":{\"description\":\"Unauthorized\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}}}},\"post\":{\"tags\":[\"Note\"],\"operationId\":\"CreateNote\",\"parameters\":[{\"name\":\"version\",\"in\":\"path\",\"required\":true,\"style\":\"simple\",\"schema\":{\"type\":\"string\"}}],\"requestBody\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateNoteDto\"}},\"text/json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateNoteDto\"}},\"application/*+json\":{\"schema\":{\"$ref\":\"#/components/schemas/CreateNoteDto\"}}}},\"responses\":{\"201\":{\"description\":\"Created\",\"content\":{\"application/json\":{\"schema\":{\"type\":\"string\",\"format\":\"uuid\"}}}},\"401\":{\"description\":\"Unauthorized\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}}}},\"put\":{\"tags\":[\"Note\"],\"operationId\":\"UpdateNote\",\"parameters\":[{\"name\":\"version\",\"in\":\"path\",\"required\":true,\"style\":\"simple\",\"schema\":{\"type\":\"string\"}}],\"requestBody\":{\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/UpdateNoteDto\"}},\"text/json\":{\"schema\":{\"$ref\":\"#/components/schemas/UpdateNoteDto\"}},\"application/*+json\":{\"schema\":{\"$ref\":\"#/components/schemas/UpdateNoteDto\"}}}},\"responses\":{\"204\":{\"description\":\"No Content\"},\"401\":{\"description\":\"Unauthorized\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}}}}},\"/api/{version}/Note/{id}\":{\"get\":{\"tags\":[\"Note\"],\"operationId\":\"Get\",\"parameters\":[{\"name\":\"id\",\"in\":\"path\",\"required\":true,\"style\":\"simple\",\"schema\":{\"type\":\"string\",\"format\":\"uuid\"}},{\"name\":\"version\",\"in\":\"path\",\"required\":true,\"style\":\"simple\",\"schema\":{\"type\":\"string\"}}],\"responses\":{\"200\":{\"description\":\"Success\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/NoteDetailsVm\"}}}},\"401\":{\"description\":\"Unauthorized\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}}}},\"delete\":{\"tags\":[\"Note\"],\"operationId\":\"UpdateNote\",\"parameters\":[{\"name\":\"id\",\"in\":\"path\",\"required\":true,\"style\":\"simple\",\"schema\":{\"type\":\"string\",\"format\":\"uuid\"}},{\"name\":\"version\",\"in\":\"path\",\"required\":true,\"style\":\"simple\",\"schema\":{\"type\":\"string\"}}],\"responses\":{\"204\":{\"description\":\"No Content\"},\"401\":{\"description\":\"Unauthorized\",\"content\":{\"application/json\":{\"schema\":{\"$ref\":\"#/components/schemas/ProblemDetails\"}}}}}}}},\"components\":{\"schemas\":{\"CreateNoteDto\":{\"required\":[\"title\"],\"type\":\"object\",\"properties\":{\"title\":{\"minLength\":1,\"type\":\"string\"},\"details\":{\"type\":\"string\",\"nullable\":true}},\"additionalProperties\":false},\"NoteDetailsVm\":{\"type\":\"object\",\"properties\":{\"id\":{\"type\":\"string\",\"format\":\"uuid\"},\"title\":{\"type\":\"string\",\"nullable\":true},\"details\":{\"type\":\"string\",\"nullable\":true},\"creationDate\":{\"type\":\"string\",\"format\":\"date-time\"},\"editDate\":{\"type\":\"string\",\"format\":\"date-time\",\"nullable\":true}},\"additionalProperties\":false},\"NoteListVm\":{\"type\":\"object\",\"properties\":{\"notes\":{\"type\":\"array\",\"items\":{\"$ref\":\"#/components/schemas/NoteLookupDto\"},\"nullable\":true}},\"additionalProperties\":false},\"NoteLookupDto\":{\"type\":\"object\",\"properties\":{\"id\":{\"type\":\"string\",\"format\":\"uuid\"},\"title\":{\"type\":\"string\",\"nullable\":true}},\"additionalProperties\":false},\"ProblemDetails\":{\"type\":\"object\",\"properties\":{\"type\":{\"type\":\"string\",\"nullable\":true},\"title\":{\"type\":\"string\",\"nullable\":true},\"status\":{\"type\":\"integer\",\"format\":\"int32\",\"nullable\":true},\"detail\":{\"type\":\"string\",\"nullable\":true},\"instance\":{\"type\":\"string\",\"nullable\":true}},\"additionalProperties\":{}},\"UpdateNoteDto\":{\"type\":\"object\",\"properties\":{\"id\":{\"type\":\"string\",\"format\":\"uuid\"},\"title\":{\"type\":\"string\",\"nullable\":true},\"details\":{\"type\":\"string\",\"nullable\":true}},\"additionalProperties\":false}},\"securitySchemes\":{\"AuthToken 1.0\":{\"type\":\"http\",\"description\":\"Authorization token\",\"scheme\":\"bearer\",\"bearerFormat\":\"JWT\"},\"AuthToken 2.0\":{\"type\":\"http\",\"description\":\"Authorization token\",\"scheme\":\"bearer\",\"bearerFormat\":\"JWT\"}}},\"security\":[{\"AuthToken 1.0\":[]},{\"AuthToken 2.0\":[]}]}";
    
    [HttpGet]
    [Route("typescript/angular")]
    public async Task<ActionResult<string>> Get()
    {
        string baseUrl = $"{this.Request.Scheme}://{this.Request.Host.Value.ToString()}{this.Request.PathBase.Value.ToString()}";
        OpenApiDocument document = await OpenApiDocument.FromJsonAsync(_jsonHardData);

        TypeScriptClientGeneratorSettings settings = new TypeScriptClientGeneratorSettings
        {
            ClientBaseClass = "AuthorizedApiBase",
            ClassName = "ClientName",
            Template = TypeScriptTemplate.Angular,
            PromiseType = PromiseType.Promise,
            HttpClass = HttpClass.HttpClient,
            InjectionTokenType = InjectionTokenType.InjectionToken,
            ConfigurationClass ="ApiClientConfig"
        };

        TypeScriptClientGenerator generator = new TypeScriptClientGenerator(document, settings);
        string generatedCode = generator.GenerateFile();
        return Ok(generatedCode);
    }
}