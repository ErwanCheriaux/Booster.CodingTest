# Booster Development Test

## Overview
This test is intended to allow a potential candidate to demonstrate their technical proficiency and approach to software development, while solving a relatively trival problem. 

## The challenge:
Write an application (console, web, forms or other .NET application type of your choosing) which will continually read and process text from a provided stream. 

Your application should process and output in real time (i.e. as you read it from the stream) the following information about the stream: 
* Total number of characters and words.
* The 5 largest words.
* The 5 smallest words.
* The 10 most frequently appearing words.
* A list of all characters appearing in the stream, the frequency with which the characters appear, in descending order of frequency. 

In order to read the stream you'll need to reference the provided class library (Booster.CodingTest.Library.dll, which in turn depends on NLipsum.Core.dll so grab both files), and create an instance of the WordStream class:

      var stream = new Booster.CodingTest.Library.WordStream();

You can then read from the stream as you would any other non-seekable `System.IO.Stream`. 

## Constraints:
1. Your solution should be built using .Net v5.x and C#.
2. All code and referenced assemblies (excluding nuget packages) must be submitted in one zip file. We should be able to unzip, build and run the solution from Visual Studio (or VS Code) without making any changes.
3. Write appropriate unit tests in any framework of your choosing. Ensure those tests pass.
4. Take as much or as little time as you feel is necessary, but as a guideline the test should only take a few hours. 

## What we are looking for:
The problem of processing the stream is intentionally trivial. What we're interested in seeing is your approach to problem solving, code structure, use of appropriate patterns, adherance to standards, consistency and overall code quality. 

Treat your solution as being code you are ready to submit for a PR i.e. production ready.

## Comments

Please find a console solution which analyzes and display the stream with all statistic information in real time.  
The display function and the stream analyzer run in 2 different threads.  
There is an NUnit test project for the static class SteamAnalizer.  
The solution can be run from visual studio 2019 as well as a command prompt. Note the console needs to be stretch to view all information.  

### Improvement

The next step would be to create a graphical interface to display the stream and all information in a Windows form.  

Thanks for reading.
