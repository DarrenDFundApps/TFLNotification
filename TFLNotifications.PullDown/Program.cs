using TFLNotifications.PullDown;

var tubeInformation = new TubeInformation();
var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));

while (await timer.WaitForNextTickAsync())  {
    await tubeInformation.GetAsync();
}