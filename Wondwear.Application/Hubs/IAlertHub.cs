

namespace Wondwear.Application.Hubs;
public interface IAlertHub
{
    Task SendAlertAsync(int caseId,int BewohnerId,string BewohnerName,int ZimmerNummer);
    Task SendAlertDoneAsync(int caseId, int BewohnerId,string PflegerName);
}
