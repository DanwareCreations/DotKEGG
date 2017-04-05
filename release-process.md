# Steps to Take During a DotKEGG Release

These steps are only meant to be conducted by an administrator on a Release branch. 
In keeping with the [GitFlow](http://nvie.com/posts/a-successful-git-branching-model/) branching model, releases branches 
should only be branched off of dev when all issues/features intended for that release have been completed and merged in. 
Once the following steps have been completed in the release branch, then that branch is ready to be merged into master and tagged 
as a new release (and merged back into dev).

Each of the following steps should be completed in a separate commit.  Any additional tweaks or last minute bug-fixes should 
also be performed in their own commits.

**THIS WILL ALL BE SCRIPTED EVENTUALLY**

1. Build/run all unit tests and make sure they pass.  Any required fixes to the tests or to DotKEGG itself should be done here, 
in their own commits.
2. Update the DotKEGG assembly version and informational version in `AssemblyInfo.cs`.  The informational version is the one used 
by the .nuspec file, so any pre-release information (such as `-alpha` or `-beta`) should be appended to _that_ version number.
3. Update release notes in the .nuspec file.
4. Update any other information in the .nuspec file (such as description or tags) as necessary.
5. Update the copyright message and release notes in the NuGet package readme.txt (release notes should match those in the .nuspec).
4. Add a topic for the new version to the documentation project, including release notes.  This topic must be visible in the 
Table of Contents, and linked to in the main Version History topic page.  In both lists, versions should be ordered with the latest 
at the top.  Release notes should match those in the .nuspec (but possibly formatted more pretty).
5. Update the documentation copyright message to show the latest version.
6. Build the documentation and upload it to the hosting S3 bucket, using the AWS Toolkit for Visual Studio 
(this step won't have a commit, obviously).
7. Create the NuGet package and upload it to [nuget.org](https://www.nuget.org/packages/manage/upload) 
(this step won't have a commit either).
