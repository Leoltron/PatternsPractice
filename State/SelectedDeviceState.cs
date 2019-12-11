using System;

namespace State
{
    public class SelectedDeviceState : BaseState
    {
        public override void Print(CopyMachine copyMachine)
        {
            throw new Exception("Document not selected");
        }

        public override void SelectDocument(CopyMachine copyMachine, int document)
        {
            if (document < 0 || copyMachine.SelectedDevice.DocumentCount <= document)
                throw new IndexOutOfRangeException("Invalid document");
            copyMachine.SelectedDocument = document;
            copyMachine.State = new SelectedDocumentState();
        }
    }
}
