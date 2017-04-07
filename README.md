![KEGG Logo](https://kegg.wustl.edu/images/KEGG_database_logo.gif)

# DotKEGG

Grab the latest version off NuGet!  
Latest stable release: **N/A** (we're still in alpha, yo!)<br/>
Latest pre-release: [v0.2.0-alpha](https://www.nuget.org/packages/DotKEGG/)

## About
DotKEGG is a light-weight, user-friendly .NET wrapper for the Kyoto Encyclopedia of Genes and Genomes (KEGG) API.  This library 
allows developers to make calls to the KEGG API with simple method calls, rather than building their own HTTP clients and request URIs, 
and return results as strongly typed lists, rather than having to parse raw text.  Here at Danware, we originally developed DotKEGG as a data layer for our game, [_Cell_](http://www.danwarecreations.com/products/cell/).  However, we quickly realized that the library would also be useful to those (proud few!) bioinformatics/genomics researchers who build processing tools targeting the .NET Framework, so we made it free and open source!

## Documentation
Documentation for DotKEGG, including full API Reference, is availabe at [https://docs.dotkegg.com](https://docs.dotkegg.com).  If you can't find the answer you're looking for there, please fill out an [issue](https://github.com/DanwareCreations/DotKEGG/issues/new?title=Write%20Better%20Docs!!!%20%20(Please%20give%20us%20a%20more%20informative%20title%20than%20that...)&body=%0DTODO%20(optional)%3A%20Describe%20a%20specific%20example%20or%20explanation%20that%20you%20would%20like%20to%20see%20added%20to%20our%20documentation.) so we can help future users better understand this tool.  For questions or comments specific to your use case, you can also contact [Danware support](mailto:support@danwarecreations.com?Subject=DotKEGG%20Support%20Needed&body=TODO:%20Tell%20us%20what%20you%20need%20help%20with!%0D%0DYour%20e-mail%20address%20will%20not%20be%20disclosed%20to%20any%20other%20parties,%20and%20will%20be%20disposed%20of%20after%20your%20query%20has%20been%20resolved.%20%20While%20working%20to%20resolve%20your%20query,%20we%20may%20contact%20you%20at%20this%20e-mail%20to%20get%20further%20details%20or%20clarification.).

## Issue Reporting
We're not perfect; bugs happen.  If you experience any issues with DotKEGG, please report them on this repository's [Issue Tracker](https://github.com/DanwareCreations/DotKEGG/issues).

## Building
We'll assume you know how to clone this repository and open the solution in Visual Studio.  Here are some additional requirements/suggestions:
- Visual Studio 2017 or later is required.
- The solution has Debug, Release, and Test build configurations.
  - The unit-test project (DotKEGG.Test) is only built in the Test configuration.  We rely on the NUnit library for unit testing.  You _must_ run these tests and make sure they all pass before submitting a pull request.  Otherwise, if you don't care about running the tests, you should build in Debug or just delete this project from your solution.
  - The examples project (DotKEGG.Examples) is only built in the Release configuration.  It simply makes sure that all examples referenced in the documentation will actually compile.  If you don't care about building the Examples, you should build in Debug or just delete this project from your solution.
  - The documentation project (DotKEGG.Docs) is only built in the Release configuration.  If you want to build the documentation project, make sure that you install the SandCastle Help File Builder (latest release available [here](https://github.com/EWSoftware/SHFB/releases)).  If not, you should build in Debug or just delete this project from your solution so that Visual Studio doesn't complain about the .shfbproj project type.
  - The NuGet package (.nupkg) is only built in the Release configuration.  You will need to install the latest [NuGet](https://dist.nuget.org/index.html) command-line client and add it to your path for this build step to succeed.  If you don't care about building the NuGet package, you should build in Debug or just delete this build step from DotKEGG.csproj.
- To view or modify the YAML CloudFormation template for the documentation website, you can use a basic editor like Notepad++, or install the [YAML Editor](https://marketplace.visualstudio.com/items?itemName=aaubry.YAMLEditor) VS extension.

## License
DotKEGG is distributed under the terms of the [MIT License](https://opensource.org/licenses/MIT).  That means you can do pretty much anything you want with it, as long as you give Danware some credit and don't blame us when you fork the repo and break everything!
