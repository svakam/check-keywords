// See https://aka.ms/new-console-template for more information

using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

// welcome
Console.WriteLine("Welcome to Resume keyword checker! This app will provide you statistics on how your resume or cover letter matches, and a rating on job description fitness.");
Thread.Sleep(1000);
Console.WriteLine("Input the absolute file path of your resume or cover letter: ");

// input file path of resume or letter
string? inputPath = GetInputPath(5);
if (inputPath == null)
{
    Console.WriteLine("Input path was not entered or invalid. Please try again later.");
    Environment.Exit(0);
}

// input keywords: manually or LinkedIn search
Console.WriteLine("Enter the necessary keywords to fulfill from the job description: ");
Console.ReadLine();

// trie for word search and absolute matches

// provide no fit, poor fit, fair fit, good fit, great fit, excellent fit rating
Console.WriteLine("Based on your input file and keyword requirements, your file is a __ fit.");



// ------- helpers -------- // 
string? GetInputPath(int tryAttempts)
{
    if (tryAttempts == 0) return null;

    Console.WriteLine("Input path was not entered or invalid. Please try again: ");
    string? inputPath = Console.ReadLine();
    if (inputPath == null || inputPath.Length == 0 || !IsValidInputPath(inputPath))
    {
        return GetInputPath(tryAttempts--);
    } else
    {
        return inputPath;
    }
}

bool IsValidInputPath(string inputPath)
{
    Regex r = new("^([A-za-z])?\\:(\\\\?\\w+)+((\\\\|\\.)\\w+)*$/g", RegexOptions.IgnoreCase);
    return r.IsMatch(inputPath) && File.Exists(inputPath);
}
