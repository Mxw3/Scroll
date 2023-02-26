using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Scroll;

internal class Git
{
    public void Process()
    {
        if (DateCheck())
        {
            var patternData = new PatternData();
            if (PatternCheck(patternData))
            {
                PerformOperations();
            }
        }
        File.WriteAllText("GitDate.txt", DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss.ffff"));
    }
    public bool DateCheck()
    {
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
    public bool PatternCheck(PatternData patternData)
    {
        double start = new DateTime(2023, 02, 26).ToOADate();
        double today = DateTime.UtcNow.Date.ToOADate();
        int i = (int)(today - start) % patternData.Pattern.Length;
        return patternData.Pattern[i];
    }
    public void PerformOperations()
    {
        for (int i = 0; i < 30; i++)
        {
            File.WriteAllText("GitDate.txt", DateTime.UtcNow.ToString("yyyy-MM-dd hh:mm:ss.ffff"));
            ExecuteProcess("add -u");
            ExecuteProcess($"commit -m \"Commit {DateTime.UtcNow}\"");
            ExecuteProcess("push");
        }
    }
    internal void ExecuteProcess(string arguments)
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
        Console.WriteLine(result);
    }
}
