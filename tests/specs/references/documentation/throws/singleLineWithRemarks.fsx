module rec Glutinum

open Fable.Core
open Fable.Core.JsInterop
open System

[<Erase>]
type Exports =
    /// <remarks>
    /// This is a remarks section.
    /// 
    /// Throws:
    /// -------
    /// 
    /// Thrown if the ISBN number is valid, but no such book exists in the catalog.
    /// </remarks>
    [<Import("fetchBookByIsbn", "REPLACE_ME_WITH_MODULE_NAME")>]
    static member fetchBookByIsbn () : unit = nativeOnly

(***)
#r "nuget: Fable.Core"
(***)
