namespace TFLNotifications.API.Controllers.Payload;

public enum ActionType
{
    StationStatus
}

public record SlackAction(ActionType Action, string Parameter)
{

}
public record SlackCommandPayload(string UserId, string Username, string Text, string RequestUrl, SlackAction Action)
{

}