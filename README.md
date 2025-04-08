# NoStrCmpLogicalToggler
*Because a checkbox in the Explorer interface would be too hard.*  

## Installation and Running  
Check the Releases tab on the right and download it.  
The program must be run with administrator privileges.  
The program will toggle the state of the NoStrCmpLogical key and then restart Windows Explorer.  

## Building  
This repository contains the CSProj file and the SLN file.  
When I built it, I had to publish it through VS's "Publish" feature.  
I'm not too familiar with the Visual Studio .NET workflow, but that worked for me.  

## Motivation  
Oftentimes, when unpacking programs, the resource files will have semi-random hexadecimal names.  
Despite these names, neighboring files can sometimes be related, so it becomes important to browse them this way.  
By default, Windows Explorer picks out numbers from file names and sorts them as such, meaning hexadecimal file names can be sorted improperly.  
Instead of having a checkbox in the properties or the view menu of Explorer, the option to change this behavior is hidden in the registry.  
This program toggles this setting and restarts the explorer process.
