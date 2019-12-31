# fable-easymde
Fable - F# bindings for Easy Markdown Editor (https://easymde.tk/). These bindings are generated with `ts2fable` using the TypeScript definition files provided by EasyMDE. 

The bindings are generated from `EasyMDE v2.10`, so it should be largely compatible with 2.x series.

# Installation

First install the `easymde` NPM package 

    npm install easymde --save

and install  `fable-easymde` from NuGet

    dotnet add package Fable.EasyMDE


# Usage 

#### Create instance of EasyMDE

    open Fable.EasyMDE

    // create markdown editor in the first textarea element in the document.
    let mdeInstance: EasyMDE = easyMDE.Create()


#### Custom Element

    open Fable.Core.JsInterop
    open Fable.EasyMDE

    let options: Options =
      !!{| element = Browser.Dom.document.getElementById("myTextArea") |}
    let mdeInstance: EasyMDE = easyMDE.Create options

#### Customize Toolbar

    open Fable.Core.JsInterop
    open Fable.EasyMDE

     let customToolbar: ToolbarButton array =
        [| ToolbarButton.Bold
           ToolbarButton.Italic
           ToolbarButton.Link
           ToolbarButton.Preview |]

    let options: Options =
      !!{| element = Browser.Dom.document.getElementById("myTextArea")
           toolbar = customToolbar |}

    let mdeInstance: EasyMDE = easyMDE.Create options

#### Get Value

    let mdeInstance: EasyMDE = easyMDE.Create()
    let value: string = mdeInstance.value

#### OnChange event

> Note: Currently there's no bindings provided for Code Mirror which is used by EasyMDE. So you have to typecast `mdeInstance.codemirror` as dynamic object to access it's members.

    mdeInstance.codemirror?on ("change", fun () -> Console.WriteLine(mdeInstance.value())))

#### Dispose EasyMDE instance

    let mutable mdeInstance: EasyMDE =
      easyMDE.Create !!{| element = Browser.Dom.document.getElementById("myTextArea") |}

    // ...

    mdeInstance.toTextArea()
    mdeInstance <- null


#### Make a React Component

    module MyApp

    open System
    
    open Browser.Types
    open Fable.Core.JsInterop
    open Fable.React
    open Fable.React.Props
    open Fable.EasyMDE
    
    type MarkdownEditorProps =
      { OnChange: string -> unit }
    
    let MarkdownEditor =
      FunctionComponent.Of
        ((fun (props: MarkdownEditorProps) ->
          let textAreaRef = Hooks.useRef None
          Hooks.useEffectDisposable (fun () ->
            let mutable mde = easyMDE.Create !!{| element = textAreaRef.current; |}
            mde.codemirror?on ("change", (fun () -> props.OnChange(mde.value())))
            { new IDisposable with
                member __.Dispose() =
                  mde.toTextArea()
                  mde <- null })
          div []
            [ textarea
                [ RefValue textAreaRef
                  Class "form-control" ] [] ]), memoizeWith = equalsButFunctions) // Memoize to prevent unnecessary rerender

