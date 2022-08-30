using System.Diagnostics;

List<string> list = new List<string>
        {
            "https://medium.com/",
            "https://medium.com/serious-scrum/scrum-has-failed-the-developers-547dfe09cc53",
            "https://github.com/josephguluzada/PYP-ClasstaskAndHomeWorks-24-08-2022-/blob/main/TaskPYP2/TaskPYP2/Program.cs",
            "https://www.wikihow.com/Turn-on-the-Keyboard-Light-on-a-Dell",
            "https://techcrunch.com/2022/08/29/facebook-cambridge-analytica-lawsuit-settlement-proposal/"
        };

HttpClient client = new();
Stopwatch stopwatch = new Stopwatch();

#region Example 1
//birinci numune 
//bir-bir requestler gonderilir ve prosesin zamani hesablanir
foreach (string item in list)
{
    stopwatch.Start();
    var getHtml = await client.GetStringAsync(item);
    Console.WriteLine($"ELEMENT COUNT: {getHtml.ToString().Length}   TIME: {stopwatch.ElapsedMilliseconds} millisecond");
    stopwatch.Stop();
    stopwatch.Reset();
}
#endregion

Console.WriteLine(new String('-', 100));

#region Example 2

//request-ler foreach iterasiyasi istifade olunaraq taskList adli liste elave olunur 
List<Task<string>> taskList = new List<Task<string>>();
foreach (var item in list)
{
    taskList.Add(client.GetStringAsync(item));
}

//asinxron geden prosesin davam etme muddeti hesablanir
stopwatch.Start();
await Task.WhenAll(taskList);
stopwatch.Stop();

//ve netice console ekranina yazilir
foreach (var getHtml in taskList)
{
    Console.WriteLine($"ELEMENT COUNT : {getHtml.Result.Length}   TIME: {stopwatch.ElapsedMilliseconds} millisecond");
}

#endregion

















