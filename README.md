[![Build status](https://ci.appveyor.com/api/projects/status/31asokfdl671fi7q?svg=true)](https://ci.appveyor.com/project/narkhedegs/whistle)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/narkhedegs/Whistle?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
# Whistle
Whistle is a helper C# library to start external executable from within a .NET process and return any output produced by the executable.

# Installation
Whistle is available at [Nuget](https://www.nuget.org/packages/Whistle/) and can be installed as a package using VisualStudio NuGet package manager or via the NuGet command line:
> Install-Package Whistle

# Quick Start
Add an using statement for Narkhedegs.
```cs
using Narkhedegs;
```
Create an instance of Whistle class with desired WhistleOptions and call Blow method to start an external executable. Blow method accepts params string[] arguments which are supplied to the external executable. The Blow method return a Task<WhistleResponse> which can be awaited using await keyword or by accessing .Result property.
```cs
var whistleOptions = new WhistleOptions { 
    ExecutableName = "executable.exe"
};

var whistle = new Whistle(whistleOptions);

var response = whistle.Blow("argument1", "argument2", "argument3").Result;
```
The WhistleResponse contains Standard Output and Standard Error from the external executable.
```cs
if(!response.HasError)
{
    Console.WriteLine(response.StandardOutput);
}
else
{
    Console.WriteLine(response.StandardError);
}
```

# Advance Usage
We can change the behaviour of Whistle object by tweaking the properties of WhistleOptions object.

# Whistle Options
| Tables        | Type | Description | Default Value |
|:------------- |:------------|:-------------|:-------------| 
| ExecutableName | string | Gets or sets the executable to start. The ExecutableName could be simply a name like executable.exe or it could be a path, absolute or relative. For example /path/to/your/executable.exe or C:\path\to\your\executable.exe | Required |
| Arguments | IEnumerable<string> | Gets or sets the set of command-line arguments to use when starting the executable. Arguments specified here will be merged with the arguments accepted by the Blow method of Whistle. | Empty Array |
| WorkingDirectory | string | Gets or sets the working directory for the executable to be started. If nothing is specified then the default value for WorkingDirectory is the Current Directory. | Current Directory |
| ExitTimeout | int? | ExitTimeout is time in milliseconds for which Whistle will wait for the external executable to exit. If the external executable exceeds the ExitTimeout then Whistle will terminate the executable and raise TimeoutException. If ExitTimeout is null or is not specified then the default value for ExitTimeout is infinity System.Threading.Timeout.Infinite. | infinity |
| EnvironmentVariables | Dictionary<string,string> | A string dictionary that provides environment variables that apply to the executable and child processes. | Empty |

# To Do
 - Add support for setting standard output encoding for external executable
 - Add support for setting standard error encoding for external executable
 - Add support for starting the external executable as a Windows Active Directory user (Integrated Windows Authentication)