
using Spinners;


var allSpinners = new List<TextSpinner>();
var spinnerTasks = new List<Task>();
var cts = new CancellationTokenSource();
var ct = cts.Token;
var col = 0;

Console.Clear();
Console.WriteLine("Hello, Spinners!");

var livePos = Console.GetCursorPosition();
foreach (var ss in Enum.GetValues<TextSpinner.SpinnerStyle>()){

    var newSpinner = new TextSpinner(ss);
    newSpinner.SetPosition (col, livePos.Top);
    newSpinner.SetSpinnerSpeed(TextSpinner.SpinnerSpeed.Running);
    newSpinner.SetSpinnerColour(ConsoleColor.DarkRed);
    allSpinners.Add(newSpinner);
    col += 10;
}


foreach (var allSp in allSpinners)
{
    var t = allSp.Start(ct);
    spinnerTasks.Add(t);
}
Console.WriteLine("\nPress Any Key");

var centreSpinner = new TextSpinner(TextSpinner.SpinnerStyle.Rolling);
centreSpinner.SetPreLabel("Working ");
centreSpinner.SetPostLabel("");
centreSpinner.SetPosition(TextSpinner.SpinnerJustification.Centre, 10);
centreSpinner.SetSpinnerColour(ConsoleColor.DarkGreen);
centreSpinner.SetSpinnerSpeed(150);

var cs = centreSpinner.Start(ct);

spinnerTasks.Add(cs);

Task.WaitAll(spinnerTasks.ToArray(), 500);

Console.ReadLine();

Console.WriteLine("Cancelling Spinners");
cts.Cancel();

Task.WaitAll(spinnerTasks.ToArray(), 500);