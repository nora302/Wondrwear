namespace Wondwear.Application.Features.Bewohners.DTOs;

public record BewohnerGetDTO(int Id,  
                             string? UserName,
                             int ZimmerNummer,
                             string name,
                             string nachName,
                             DateTime geburtsdatum,
                             DateTime einzugsdatum,
                             string? telefonnummer
    ):IRequest<Result>;
