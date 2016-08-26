using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Reflection;

public class ExFile
{
    static string _scriptTempFilename;

    public static void RemoveShortcut(string shortCutName)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), shortCutName + ".lnk");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void RemoveStartUp(string shortCutName)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), shortCutName + ".lnk");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    /// <summary>
    /// Creates a shortcut at the specified path with the given target and
    /// arguments.
    /// </summary>
    /// <param name="path">The path where the shortcut will be created. This should
    ///     be a file with the LNK extension.</param>
    /// <param name="target">The target of the shortcut, e.g. the program or file
    ///     or folder which will be opened.</param>
    /// <param name="arguments">The additional command line arguments passed to the
    ///     target.</param>
    public static bool CreateShortcut(string shortCutName, string sourcePath, string arguments)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), shortCutName + ".lnk");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        // Check if link path ends with LNK or URL
        string extension = Path.GetExtension(path).ToUpper();
        if (extension != ".LNK" && extension != ".URL")
        {
            throw new ArgumentException("The path of the shortcut must have the extension .lnk or .url.");
        }

        // Get temporary file name with correct extension
        _scriptTempFilename = Path.GetTempFileName();
        File.Move(_scriptTempFilename, _scriptTempFilename += ".vbs");

        // Generate script and write it in the temporary file
        File.WriteAllText(_scriptTempFilename, String.Format(@"Dim WSHShell
Set WSHShell = WScript.CreateObject({0}WScript.Shell{0})
Dim Shortcut
Set Shortcut = WSHShell.CreateShortcut({0}{1}{0})
Shortcut.TargetPath = {0}{2}{0}
Shortcut.WorkingDirectory = {0}{3}{0}
Shortcut.Arguments = {0}{4}{0}
Shortcut.Save",
            "\"", path, sourcePath, Path.GetDirectoryName(sourcePath), arguments),
            Encoding.Unicode);

        // Run the script and delete it after it has finished
        Process process = new Process();
        process.StartInfo.FileName = _scriptTempFilename;
        process.Start();
        process.WaitForExit();
        File.Delete(_scriptTempFilename);
        return true;
    }

    public static bool CreateStartUp(string shortCutName, string sourcePath, string arguments)
    {
        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), shortCutName + ".lnk");
        if (File.Exists(path))
        {
            File.Delete(path);
        }
        // Check if link path ends with LNK or URL
        string extension = Path.GetExtension(path).ToUpper();
        if (extension != ".LNK" && extension != ".URL")
        {
            throw new ArgumentException("The path of the shortcut must have the extension .lnk or .url.");
        }

        // Get temporary file name with correct extension
        _scriptTempFilename = Path.GetTempFileName();
        File.Move(_scriptTempFilename, _scriptTempFilename += ".vbs");

        // Generate script and write it in the temporary file
        File.WriteAllText(_scriptTempFilename, String.Format(@"Dim WSHShell
Set WSHShell = WScript.CreateObject({0}WScript.Shell{0})
Dim Shortcut
Set Shortcut = WSHShell.CreateShortcut({0}{1}{0})
Shortcut.TargetPath = {0}{2}{0}
Shortcut.WorkingDirectory = {0}{3}{0}
Shortcut.Arguments = {0}{4}{0}
Shortcut.Save",
            "\"", path, sourcePath, Path.GetDirectoryName(sourcePath), arguments),
            Encoding.Unicode);

        // Run the script and delete it after it has finished
        Process process = new Process();
        process.StartInfo.FileName = _scriptTempFilename;
        process.Start();
        process.WaitForExit();
        File.Delete(_scriptTempFilename);
        return true;
    }

    public static void ExtractResourceToFile(byte[] resource, string filename)
    {
        if (File.Exists(filename) == false)
        {
            File.WriteAllBytes(filename, resource);
        }
    }
}