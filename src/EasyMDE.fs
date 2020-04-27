// ts2fable 0.7.1
module rec Fable.EasyMDE

open Fable.Core
open Browser.Types


type Array<'T> = System.Collections.Generic.IList<'T>

type ReadonlyArray<'T> = System.Collections.Generic.IReadOnlyList<'T>

[<ImportDefault("easymde")>]
let easyMDE: EasyMDEStatic = jsNative


[<AllowNullLiteral>]
type ArrayOneOrMore<'T> =
  inherit Array<'T>
  abstract ``0``: 'T with get, set

[<StringEnum>]
[<RequireQualifiedAccess>]
type ToolbarButton =
  | Bold
  | Italic
  | Quote
  | [<CompiledName "unordered-list">] UnorderedList
  | [<CompiledName "ordered-list">] OrderedList
  | Link
  | Image
  | Strikethrough
  | Code
  | Table
  | Redo
  | Heading
  | Undo
  | [<CompiledName "heading-bigger">] HeadingBigger
  | [<CompiledName "heading-smaller">] HeadingSmaller
  | [<CompiledName "heading-1">] Heading1
  | [<CompiledName "heading-2">] Heading2
  | [<CompiledName "heading-3">] Heading3
  | [<CompiledName "clean-block">] CleanBlock
  | [<CompiledName "horizontal-rule">] HorizontalRule
  | Preview
  | [<CompiledName "side-by-side">] SideBySide
  | Fullscreen
  | Guide

module EasyMDE =

  [<AllowNullLiteral>]
  type TimeFormatOptions =
    abstract locale: U2<string, ResizeArray<string>> option with get, set
    abstract format: obj option with get, set

  [<AllowNullLiteral>]
  type AutoSaveOptions =
    abstract enabled: bool option with get, set
    abstract delay: float option with get, set
    abstract submit_delay: float option with get, set
    abstract uniqueId: string with get, set
    abstract timeFormat: TimeFormatOptions option with get, set
    abstract text: string option with get, set

  [<AllowNullLiteral>]
  type BlockStyleOptions =
    abstract bold: string option with get, set
    abstract code: string option with get, set
    abstract italic: string option with get, set

  [<AllowNullLiteral>]
  type InsertTextOptions =
    abstract horizontalRule: ReadonlyArray<string> option with get, set
    abstract image: ReadonlyArray<string> option with get, set
    abstract link: ReadonlyArray<string> option with get, set
    abstract table: ReadonlyArray<string> option with get, set

  [<AllowNullLiteral>]
  type ParsingOptions =
    abstract allowAtxHeaderWithoutSpace: bool option with get, set
    abstract strikethrough: bool option with get, set
    abstract underscoresBreakWords: bool option with get, set

  [<AllowNullLiteral>]
  type PromptTexts =
    abstract image: string option with get, set
    abstract link: string option with get, set

  [<AllowNullLiteral>]
  type RenderingOptions =
    abstract codeSyntaxHighlighting: bool option with get, set
    abstract hljs: obj option with get, set
    abstract markedOptions: obj option with get, set
    abstract sanitizerFunction: (string -> string) option with get, set
    abstract singleLineBreaks: bool option with get, set

  [<AllowNullLiteral>]
  type Shortcuts =

    [<Emit "$0[$1]{{=$2}}">]
    abstract Item: action:string -> string option with get, set

    abstract toggleBlockquote: string option with get, set
    abstract toggleBold: string option with get, set
    abstract cleanBlock: string option with get, set
    abstract toggleHeadingSmaller: string option with get, set
    abstract toggleItalic: string option with get, set
    abstract drawLink: string option with get, set
    abstract toggleUnorderedList: string option with get, set
    abstract togglePreview: string option with get, set
    abstract toggleCodeBlock: string option with get, set
    abstract drawImage: string option with get, set
    abstract toggleOrderedList: string option with get, set
    abstract toggleHeadingBigger: string option with get, set
    abstract toggleSideBySide: string option with get, set
    abstract toggleFullScreen: string option with get, set

  [<AllowNullLiteral>]
  type StatusBarItem =
    abstract className: string with get, set
    abstract defaultValue: (HTMLElement -> unit) with get, set
    abstract onUpdate: (HTMLElement -> unit) with get, set

  [<AllowNullLiteral>]
  type ToolbarDropdownIcon =
    abstract name: string with get, set
    abstract children: ArrayOneOrMore<U2<ToolbarIcon, ToolbarButton>> with get, set
    abstract className: string with get, set
    abstract title: string with get, set
    abstract noDisable: bool option with get, set
    abstract noMobile: bool option with get, set

  [<AllowNullLiteral>]
  type ToolbarIcon =
    abstract name: string with get, set
    abstract action: U2<string, EasyMDE -> unit> with get, set
    abstract className: string with get, set
    abstract title: string with get, set
    abstract noDisable: bool option with get, set
    abstract noMobile: bool option with get, set

  [<AllowNullLiteral>]
  type ImageTextsOptions =
    abstract sbInit: string option with get, set
    abstract sbOnDragEnter: string option with get, set
    abstract sbOnDrop: string option with get, set
    abstract sbProgress: string option with get, set
    abstract sbOnUploaded: string option with get, set
    abstract sizeUnits: string option with get, set

  [<AllowNullLiteral>]
  type ImageErrorTextsOptions =
    abstract noFileGiven: string option with get, set
    abstract typeNotAllowed: string option with get, set
    abstract fileTooLarge: string option with get, set
    abstract importError: string option with get, set

  [<AllowNullLiteral>]
  type Options =
    abstract autoDownloadFontAwesome: bool option with get, set
    abstract autofocus: bool option with get, set
    abstract autosave: AutoSaveOptions option with get, set
    abstract blockStyles: BlockStyleOptions option with get, set
    abstract element: HTMLElement option with get, set
    abstract forceSync: bool option with get, set
    abstract hideIcons: ReadonlyArray<string> option with get, set
    abstract indentWithTabs: bool option with get, set
    abstract initialValue: string option with get, set
    abstract insertTexts: InsertTextOptions option with get, set
    abstract lineWrapping: bool option with get, set
    abstract minHeight: string option with get, set
    abstract parsingConfig: ParsingOptions option with get, set
    abstract placeholder: string option with get, set
    abstract previewClass: U2<string, ReadonlyArray<string>> option with get, set
    abstract previewRender: (string -> HTMLElement -> string) option with get, set
    abstract promptURLs: bool option with get, set
    abstract renderingConfig: RenderingOptions option with get, set
    abstract shortcuts: Shortcuts option with get, set
    abstract showIcons: ReadonlyArray<ToolbarButton> option with get, set
    abstract spellChecker: bool option with get, set
    abstract inputStyle: OptionsInputStyle option with get, set
    abstract nativeSpellcheck: bool option with get, set
    abstract status: U2<bool, ReadonlyArray<U2<string, StatusBarItem>>> option with get, set
    abstract styleSelectedText: bool option with get, set
    abstract tabSize: float option with get, set
    abstract toolbar: U2<bool, ReadonlyArray<U4<ToolbarButton, ToolbarIcon, ToolbarDropdownIcon, string>>> option with get, set
    abstract toolbarTips: bool option with get, set
    abstract onToggleFullScreen: (bool -> unit) option with get, set
    abstract theme: string option with get, set
    abstract uploadImage: bool option with get, set
    abstract imageMaxSize: float option with get, set
    abstract imageAccept: string option with get, set
    abstract imageUploadFunction: (File -> (string -> unit) -> (string -> unit) -> unit) option with get, set
    abstract imageUploadEndpoint: string option with get, set
    abstract imageCSRFToken: string option with get, set
    abstract imageTexts: ImageTextsOptions option with get, set
    abstract errorMessages: ImageErrorTextsOptions option with get, set
    abstract errorCallback: (string -> unit) option with get, set
    abstract promptTexts: PromptTexts option with get, set
    abstract syncSideBySidePreviewScroll: bool option with get, set

  [<StringEnum>]
  [<RequireQualifiedAccess>]
  type OptionsInputStyle =
    | Textarea
    | Contenteditable

[<AllowNullLiteral>]
type EasyMDE =
  abstract value: unit -> string
  abstract value: ``val``:string -> unit
  abstract codemirror: obj with get, set
  abstract toTextArea: unit -> unit
  abstract isPreviewActive: unit -> bool
  abstract isSideBySideActive: unit -> bool
  abstract isFullscreenActive: unit -> bool
  abstract clearAutosavedValue: unit -> unit

[<AllowNullLiteral>]
type EasyMDEStatic =

  [<Emit "new $0($1...)">]
  abstract Create: ?options:EasyMDE.Options -> EasyMDE

  abstract toggleBold: (EasyMDE -> unit) with get, set
  abstract toggleItalic: (EasyMDE -> unit) with get, set
  abstract toggleStrikethrough: (EasyMDE -> unit) with get, set
  abstract toggleHeadingSmaller: (EasyMDE -> unit) with get, set
  abstract toggleHeadingBigger: (EasyMDE -> unit) with get, set
  abstract toggleHeading1: (EasyMDE -> unit) with get, set
  abstract toggleHeading2: (EasyMDE -> unit) with get, set
  abstract toggleHeading3: (EasyMDE -> unit) with get, set
  abstract toggleCodeBlock: (EasyMDE -> unit) with get, set
  abstract toggleBlockquote: (EasyMDE -> unit) with get, set
  abstract toggleUnorderedList: (EasyMDE -> unit) with get, set
  abstract toggleOrderedList: (EasyMDE -> unit) with get, set
  abstract cleanBlock: (EasyMDE -> unit) with get, set
  abstract drawLink: (EasyMDE -> unit) with get, set
  abstract drawImage: (EasyMDE -> unit) with get, set
  abstract drawTable: (EasyMDE -> unit) with get, set
  abstract drawHorizontalRule: (EasyMDE -> unit) with get, set
  abstract togglePreview: (EasyMDE -> unit) with get, set
  abstract toggleSideBySide: (EasyMDE -> unit) with get, set
  abstract toggleFullScreen: (EasyMDE -> unit) with get, set
  abstract undo: (EasyMDE -> unit) with get, set
  abstract redo: (EasyMDE -> unit) with get, set
