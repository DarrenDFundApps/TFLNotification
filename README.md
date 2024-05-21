# TFLNotification
A API Endpoint that get station tube station status

## Run the application
1. Spin up Docker. Run `docker compose up -d`
2. Create the table `dotnet ef database update`
3. Run the PullDown project to pull data
4. Run the API project

## Run the controller locally for SlackBot
1. `ngrok http https://localhost:7072`
2. Update the link in https://api.slack.com/apps/A0740NQTYKA/slash-commands?saved=1