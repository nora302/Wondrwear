

namespace Wondwear.Application.Features.Bewohners.Commands.Create;

public record BewohnerCreateRequest(string userName, 
                                    int zimmerNummer , 
                                    string name, 
                                    string nachName,
                                    DateTime geburtsdatum,
                                    DateTime einzugsdatum, 
                                    string telefonnummer, 
                                    string password
    ):IRequest<Result>;
