#r @"FAKE\tools\FakeLib.dll"
open Fake
open Fake.AssemblyInfoFile

RestorePackages()

let sourceDir = @".\source"
let targetDir = @".\target"

Target "Clean" (fun _ -> CleanDirs [targetDir])

Target "CopyTxtOnly" (fun _ ->
    !! (sourceDir @@ "**/*.*")
      -- "*.xml"
    |> CopyFiles targetDir
)

"Clean"
    ==> "CopyTxtOnly"

RunTargetOrDefault "CopyTxtOnly"
