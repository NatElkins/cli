module Glutinum.Ava

open Fable.Core
open System


type [<AllowNullLiteral>] LogFn =
    /// Log one or more values.
    [<Emit("$0($1...)")>]
    abstract Invoke: [<ParamArray>] values: obj option[] -> unit
    /// Skip logging.
    abstract skip: [<ParamArray>] values: obj option[] -> unit

type [<AllowNullLiteral>] PlanFn =
    /// <summary>
    /// Plan how many assertion there are in the test. The test will fail if the actual assertion count doesn't match the
    /// number of planned assertions. See <see href="https://github.com/avajs/ava#assertion-planning">assertion planning</see>.
    /// </summary>
    [<Emit("$0($1...)")>]
    abstract Invoke: count: float -> unit
    /// Don't plan assertions.
    abstract skip: count: float -> unit


type [<AllowNullLiteral>] AssertAssertion =
    /// <summary>
    /// Assert that <c>actual</c> is <see href="https://developer.mozilla.org/en-US/docs/Glossary/Truthy">truthy</see>, returning a boolean
    /// indicating whether the assertion passed.
    /// </summary>
    [<Emit("$0($1...)")>] abstract Invoke: actual: obj option * ?message: string -> bool
    /// Skip this assertion.
    abstract skip: actual: obj option * ?message: string -> unit


type [<AllowNullLiteral>] DeepEqualAssertion =
    /// <summary>
    /// Assert that <c>actual</c> is <see href="https://github.com/concordancejs/concordance#comparison-details">deeply equal</see> to
    /// <c>expected</c>, returning a boolean indicating whether the assertion passed.
    /// </summary>
    [<Emit("$0($1...)")>] abstract Invoke: actual: 'Type * expected: 'Type * ?message: string -> bool

    /// <summary>
    /// Assert that <c>actual</c> is <see href="https://github.com/concordancejs/concordance#comparison-details">deeply equal</see> to
    /// <c>expected</c>, returning a boolean indicating whether the assertion passed.
    /// </summary>
    [<Emit("$0($1...)")>] abstract Invoke: actual: 'Actual * expected: 'Expected * ?message: string -> bool

    [<Emit("$0($1...)")>] abstract Invoke: actual: 'Actual * expected: 'Expected -> bool

    /// Skip this assertion.
    abstract skip: actual: obj option * expected: obj option * ?message: string -> unit

[<AllowNullLiteral>]
type Assertions =
    abstract ``assert`` : AssertAssertion
    /// <summary>
    /// Assert that <c>actual</c> is <see href="https://github.com/concordancejs/concordance#comparison-details">deeply equal</see> to
    /// <c>expected</c>, returning a boolean indicating whether the assertion passed.
    /// </summary>
    abstract deepEqual: DeepEqualAssertion with get, set

type ExecutionContext<'Context> =
    inherit Assertions
    abstract Context : 'Context
    abstract title : string
    abstract passed : bool
    abstract log : LogFn
    abstract plan : PlanFn


[<Erase>]
type test<'Context> =

    [<ImportDefault("ava")>]
    static member test (title : string, t : ExecutionContext<'Context> -> unit) =
        nativeOnly

    [<ImportDefault("ava")>]
    static member test (title : string, t : ExecutionContext<'Context> -> JS.Promise<unit>) =
        nativeOnly