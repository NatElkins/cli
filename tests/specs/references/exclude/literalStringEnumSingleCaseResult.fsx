module rec Glutinum

open Fable.Core
open Fable.Core.JsInterop
open System

[<RequireQualifiedAccess>]
[<StringEnum(CaseRules.None)>]
type PrimitiveResult =
    | b

(***)
#r "nuget: Fable.Core"
#r "nuget: Glutinum.Types"
(***)
