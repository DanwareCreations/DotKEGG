# Steps to Take During a DotKEGG Release

These steps are only meant to be conducted by an administrator on a Release branch. 
In keeping with the [GitFlow](http://nvie.com/posts/a-successful-git-branching-model/) branching model, release branches 
should only be branched off of dev when all issues/features intended for that release have been completed and merged in. 

Each of the following steps should be completed in a separate commit.  Any additional tweaks or last minute bug-fixes should 
also be performed in their own commits.

**THIS WILL ALL BE SCRIPTED EVENTUALLY**

1. Build/run all unit tests and make sure they pass.  Any required fixes to the tests or to DotKEGG itself should be done here, 
in their own commits.
2. Move all issues that are fixed in this release to the "In RC" column.
3. Update the DotKEGG assembly version and informational version in `AssemblyInfo.cs`, and increment the _minor_ version of the AssemblyFileVersion.  The informational version is the one used 
by the .nuspec file, so any pre-release information (such as `-alpha` or `-beta`) should be appended to _that_ version number.
4. Any other updates to `AssemblyInfo.cs` should be matched with a bump to the _major_ version of the AssemblyFileVersion.
5. Update release notes in the .nuspec file.  The only changes listed here should be things that the _end user_ sees, i.e. API and documentation changes, not changes in the GitHub repository or the infrastructure hosting the websites.
6. Update any other information in the .nuspec file (such as description or tags) as necessary.
7. Update the copyright version number in the NuGet package readme.txt.
8. Add a topic for the new version to the documentation project, including release notes.  This topic must be visible in the 
Table of Contents, and linked to in the main Version History topic page.  In both lists, versions should be ordered with the latest 
at the top.  Release notes should match those in the .nuspec (but possibly formatted more pretty).  Be sure to provide a link to complete release notes on the GitHub release page.
9. Update the documentation's copyright message to show the latest version.
10. Build the documentation and upload it to the hosting S3 bucket, using the AWS Toolkit for Visual Studio.  All files should be placed in a root folder named after the release, e.g., "v0.4.0-alpha".  This step won't have a commit, obviously.
11. Update the WebsiteOriginPath parameter for the documentation website's CloudFormation stack to point to this new folder.
12. Pack the NuGet package and upload it to the [Danware Packages Feed](https://danwarecreations.visualstudio.com/BarrelRoll/_packaging?feed=DanwarePackages&_a=feed) for staging.  Make sure that the package can be installed in a project, and that it displays the correct readme.txt file.
13. Repack the NuGet package (to make sure it has the correct name!), and upload the package to [nuget.org](https://www.nuget.org/packages/manage/upload).
14. Merge the release branch into master (no fast-forward) and tag that commit on master.  Also merge the release branch into dev.
15. In the GitHub release page for the new tag, add detailed release notes.  There should be a bullet for every issue fixed in the release, optionally grouped by their effect on the end user like in the .nuspec and Version History release notes.
16. Move all issues that are fixed in this release to the "Live" column.
