module rec Glutinum

open Fable.Core
open Fable.Core.JsInterop
open System

[<Erase>]
type Exports =
    [<ImportDefault("REPLACE_ME_WITH_MODULE_NAME")>]
    static member inline chalk: ChalkInstance = nativeOnly


[<AllowNullLiteral>]
[<Interface>]
type ChalkInstance =
    interface end

(***)
#r "nuget: Fable.Core"
(***)
