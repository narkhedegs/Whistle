[![Build status](https://ci.appveyor.com/api/projects/status/31asokfdl671fi7q?svg=true)](https://ci.appveyor.com/project/narkhedegs/whistle)
[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/narkhedegs/Whistle?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge)
# Whistle
Whistle is a helper C# library to start external executable from within a .NET process and return any output produced by the executable.

# Installation
Whistle is available at [Nuget](https://www.nuget.org/packages/Whistle/) and can be installed as a package using VisualStudio NuGet package manager or via the NuGet command line:
> Install-Package Whistle

# Quick Start
```cs
var whistleOptions = new WhistleOptions { 
    ExecutableName = "executable.exe"
};

var whistle = new Whistle(whistleOptions);

var result = whistle.Blow("argument1", "argument2", "argument3").Result;
```

# Whistle Options
| Tables        | Type | Description | Default Value |
|:------------- |:------------|:-------------|:-------------| 
| ExecutableName | string | Gets or sets the executable to start. The ExecutableName could be simply a name like executable.exe or it could be a path, absolute or relative. For example /path/to/your/executable.exe or C:\path\to\your\executable.exe | Required |
| Arguments | IEnumerable<string> | Gets or sets the set of command-line arguments to use when starting the executable. Arguments specified here will be merged with the arguments accepted by the Blow method of Whistle. | Empty Array |
| WorkingDirectory | string | Gets or sets the working directory for the executable to be started. If nothing is specified then the default value for WorkingDirectory is the Current Directory. | Current Directory |
| ExitTimeout | int? | ExitTimeout is time in milliseconds for which Whistle will wait for the external executable to exit. If the external executable exceeds the ExitTimeout then Whistle will terminate the executable and raise TimeoutException. If ExitTimeout is null or is not specified then the default value for ExitTimeout is infinity System.Threading.Timeout.Infinite. | infinity |
| EnvironmentVariables | Dictionary<string,string> | A string dictionary that provides environment variables that apply to the executable and child processes. | Empty |