namespace Wondwear.Application.Features.Pflegers.DTOs;

public record PflegerGetDTO(int Id,  string? UserName, string email, string telefonnummber, DateTime geburtsdatum, string name, string nachName);
