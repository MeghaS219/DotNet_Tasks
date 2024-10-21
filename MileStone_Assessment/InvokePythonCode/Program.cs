using System;
using System.Diagnostics;

namespace InvokePythonCode
{
    class Program
    {
        static void Main(string[] args)
        {
            // Numbers to sum
            int num1 = 5;
            int num2 = 10;

            try
            {
                // Specify the path to the Python script and the arguments
                string pythonScriptPath = @"C:\DotNetProjectsMS\Git\DotNet_Tasks\MileStone_Assessment\PDFManupulation\input\sum_script.py"; // Adjust path as needed
                string pythonExePath = @"C:\Users\Administrator\AppData\Local\Microsoft\WindowsApps\python.exe"; // Path to python executable

                // Set up the process to execute the Python script
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    FileName = pythonExePath,
                    Arguments = $"\"{pythonScriptPath}\" {num1} {num2}",  // Pass arguments to the script
                    RedirectStandardOutput = true,  // Capture the output

                    RedirectStandardError = true,
                    UseShellExecute = false,  // Don't use the shell
                    CreateNoWindow = true       // Hide the command window
                };

                // Execute the process and get the output
                using (Process process = Process.Start(startInfo))
                {
                    using (var reader = process.StandardOutput)
                    {
                        string result = reader.ReadToEnd();  // Read the script output
                        Console.WriteLine("The sum is: " + result.Trim());  // Display the result
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
