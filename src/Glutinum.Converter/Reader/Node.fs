module Glutinum.Converter.Reader.Node

open Glutinum.Converter.GlueAST
open Glutinum.Converter.Reader.Types
open TypeScript

let readNode (reader: TypeScriptReader) (node: Ts.Node) : GlueType =
    match node.kind with
    | Ts.SyntaxKind.EnumDeclaration ->
        reader.ReadEnumDeclaration(node :?> Ts.EnumDeclaration)

    | Ts.SyntaxKind.TypeAliasDeclaration ->
        reader.ReadTypeAliasDeclaration(node :?> Ts.TypeAliasDeclaration)

    | Ts.SyntaxKind.InterfaceDeclaration ->
        reader.ReadInterfaceDeclaration(node :?> Ts.InterfaceDeclaration)

    | Ts.SyntaxKind.VariableStatement ->
        reader.ReadVariableStatement(node :?> Ts.VariableStatement)

    | Ts.SyntaxKind.FunctionDeclaration ->
        reader.ReadFunctionDeclaration(node :?> Ts.FunctionDeclaration)

    | Ts.SyntaxKind.ModuleDeclaration ->
        reader.ReadModuleDeclaration(node :?> Ts.ModuleDeclaration)

    | Ts.SyntaxKind.ClassDeclaration ->
        reader.ReadClassDeclaration(node :?> Ts.ClassDeclaration)

    | unsupported ->
        printfn $"readNode: Unsupported kind {unsupported}"
        GlueType.Discard
