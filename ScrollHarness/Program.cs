﻿// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

var logger = new ScrollHarness.Logger();
var git = new Scroll.Git();
try
{
    git.Process(logger);
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}