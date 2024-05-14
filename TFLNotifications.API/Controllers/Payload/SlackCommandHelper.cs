using System.Text;
using System.Text.RegularExpressions;

namespace TFLNotifications.API.Controllers.Payload;

public static class SlackCommandHelper
{
    public static async Task<string> GetRawBodyAsync(
        this HttpRequest request,
        Encoding encoding = null)
    {
        if (!request.Body.CanSeek)
        {
            // We only do this if the stream isn't *already* seekable,
            // as EnableBuffering will create a new stream instance
            // each time it's called
            request.EnableBuffering();
        }

        request.Body.Position = 0;

        var reader = new StreamReader(request.Body, encoding ?? Encoding.UTF8);

        var body = await reader.ReadToEndAsync().ConfigureAwait(false);

        request.Body.Position = 0;

        return body;
    }

    public static SlackCommandPayload ExtractData(string rawBody)
    {
        var expression = new Regex(@"&user_id=(?<UserId>[\w]*)&user_name=(?<Username>[\w]*)&command=(?<Command>[%\w]*)&text=(?<Text>[\w]*)&api_app_id=([\w]*)&is_enterprise_install=([\w]*)&response_url=(?<responseUrl>[%\W\w]*)&trigger_id");
        var results = expression.Matches(rawBody);
        var match = results.First();
        var requestUrl = match.Groups["responseUrl"].Value.Replace("%2F", "/").Replace("%3A", ":");
        return new SlackCommandPayload(match.Groups["UserId"].Value, match.Groups["Username"].Value,
            match.Groups["Text"].Value, requestUrl);
    }
}