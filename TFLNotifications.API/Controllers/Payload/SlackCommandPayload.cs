namespace TFLNotifications.API.Controllers.Payload;

public record SlackCommandPayload(string UserId, string Username, string Text, string RequestUrl)
{

}