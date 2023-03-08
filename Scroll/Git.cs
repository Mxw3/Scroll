using System.Diagnostics;

namespace Scroll;

public class Git
{
    public void Process(ILogger<WindowsBackgroundService> logger)
    {
        if (DateCheck(logger))
        {
            var patternData = new PatternData();
            if (PatternCheck(logger, patternData))
            {
                PerformOperations(logger);
            }
        }
        File.WriteAllText("GitDate.txt", DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss.ffff"));
    }
    internal bool DateCheck(ILogger<WindowsBackgroundService> logger)
    {
        logger.LogInformation(@"Changing current directory to D:\source\repos\Scroll");
        Directory.SetCurrentDirectory(@"D:\source\repos\Scroll");
        if (File.Exists("GitDate.txt"))
        {
            DateTime dateTime;
            if (DateTime.TryParse(File.ReadAllText("GitDate.txt"), out dateTime))
            {
                if (dateTime.Date != DateTime.UtcNow)
                    return true;
            }
        }
        return false;
    }
    internal bool PatternCheck(ILogger<WindowsBackgroundService> logger, PatternData patternData)
    {
        double start = new DateTime(2023, 02, 26).ToOADate();
        double today = DateTime.UtcNow.Date.ToOADate();
        int length = patternData.Pattern.Length;
        int i = (int)(today - start) % length;
        logger.LogInformation("{i} = ({today} - {start}) % {length}", i, today, start, length);
        return patternData.Pattern[i];
    }
    internal void PerformOperations(ILogger<WindowsBackgroundService> logger)
    {
        logger.LogWarning(@"Performing operations");
        for (int i = 0; i < 30; i++)
        {
            File.WriteAllText("GitDate.txt", DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss.ffff"));
            ExecuteProcess(logger, "add -u");
            ExecuteProcess(logger, $"commit -m \"Commit {DateTime.UtcNow}\"");
            ExecuteProcess(logger, "push");
        }
    }
    internal void ExecuteProcess(ILogger<WindowsBackgroundService> logger, string arguments)
    {
        ProcessStartInfo procStartInfo = new ProcessStartInfo("git", arguments);
        procStartInfo.RedirectStandardOutput = true;
        procStartInfo.UseShellExecute = false;
        procStartInfo.CreateNoWindow = true;
        Process process = new Process();
        process.StartInfo = procStartInfo;
        process.Start();
        process.WaitForExit();
        string result = process.StandardOutput.ReadToEnd();
        if (process.ExitCode != 0)
            logger.LogError("{argument} {result}", arguments, result);
        else
            logger.LogInformation("{argument} {result}", arguments, result);
        Console.WriteLine(result);
    }
}
