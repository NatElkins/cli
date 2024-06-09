module rec Glutinum

open Fable.Core
open Fable.Core.JsInterop
open System

[<Erase>]
type Exports =
    [<Import("Logger", "REPLACE_ME_WITH_MODULE_NAME"); EmitConstructor>]
    static member Logger () : Logger = nativeOnly
    [<Import("Logger", "REPLACE_ME_WITH_MODULE_NAME"); EmitConstructor>]
    static member Logger (prefix: string) : Logger = nativeOnly

[<AllowNullLiteral>]
[<Interface>]
type Logger =
    interface end

(***)
#r "nuget: Fable.Core"
(***)
