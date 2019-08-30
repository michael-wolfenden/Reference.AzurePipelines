Param
(
    [String]$CakeVersion    = "0.34.1",
    [String]$Target         = "Default",
    [String]$VersionNUmber  = "0.0.0",
    [String]$ToolPath       = [io.path]::combine($PSScriptRoot, "tools"),
    [String]$ToolExe        = [io.path]::combine($ToolPath, "dotnet-cake")
)

dotnet tool install --tool-path "$ToolPath" Cake.Tool --version $CakeVersion
& $ToolExe "--verbosity=verbose" "--target=$Target" "--versionNumber=$VersionNUmber"
