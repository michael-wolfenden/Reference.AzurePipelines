Param
(
    [String]$CakeVersion = "0.32.1",
    [String]$Target      = "Default",
    [String]$ToolPath    = [io.path]::combine($PSScriptRoot, "tools"),
    [String]$ToolExe     = [io.path]::combine($ToolPath, "dotnet-cake")
)

dotnet tool install --tool-path "$ToolPath" Cake.Tool --version $CakeVersion
& $ToolExe "--verbosity=verbose" "--target=$Target"
