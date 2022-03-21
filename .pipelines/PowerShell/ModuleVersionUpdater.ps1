param(
[string]$major,
[string]$minor,
[string]$patch,
[string]$modXMLPath
)

#Write-Output $path
#Write-Output $a

# Read the existing file
[xml]$xmlDoc = Get-Content $modXMLPath;

# If it was one specific element you can just do like so:
$xmlDoc.Module.Version.value = "v$major.$minor.$patch";
# however this wont work since there are multiple elements
    
# Then you can save that back to the xml file
$xmlDoc.Save("$modXMLPath");
Write-Output "Updated mod xml version to v$major.$minor.$patch."