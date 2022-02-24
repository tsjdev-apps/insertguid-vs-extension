using System.Linq;

namespace InsertGuid
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            var documentView = await VS.Documents.GetActiveDocumentViewAsync();
            var selection = documentView.TextView.Selection.SelectedSpans.FirstOrDefault();

            if (selection != null)
                documentView.TextBuffer.Replace(selection, Guid.NewGuid().ToString());
            else
                documentView.TextBuffer.Insert(documentView.TextView.Caret.Position.BufferPosition,
                    Guid.NewGuid().ToString());
        }
    }
}
