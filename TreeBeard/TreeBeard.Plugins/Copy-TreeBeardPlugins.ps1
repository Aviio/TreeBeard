Param([string]$source, [string]$destination)

Function Copy-TreeBeardScripts($source, $destination, $type) 
{
	$sourceDirectory = $source + "\Scripts\" + $type + "s"
	$destinationDirectory = $destination + "\Scripts\" + $type + "s\"
	New-Item -ItemType Directory -Force -Path $destinationDirectory | Out-Null
	$files = gci $sourceDirectory
	foreach ($file in $files) 
	{
		$regex = "^(\w+)" + $type + "\.cs"
		if ($file.name -match $regex) 
		{
			$destination = $destinationDirectory + $matches[1] + ".csx"
			Copy-Item -Path $file.fullname -Destination $destination
		}
	}
}

Function Copy-TreeBeardPlugins($source, $destination)
{
	$sourceDlls = $source + "\Lib\*.dll"
	Copy-Item -Path $sourceDlls -Destination $destination
	Copy-TreeBeardScripts $source $destination "Input"
	Copy-TreeBeardScripts $source $destination "Filter"
	Copy-TreeBeardScripts $source $destination "Output"
}

Copy-TreeBeardPlugins $source $destination