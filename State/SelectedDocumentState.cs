using System;

namespace State
{
    public class SelectedDocumentState : BaseState
    {
        public override void SelectDocument(CopyMachine copyMachine, int document)
        {
            if (document < 0 || copyMachine.SelectedDevice.DocumentCount <= document)
                throw new IndexOutOfRangeException("Invalid document");
            copyMachine.SelectedDocument = document;
        }

        public override void Print(CopyMachine copyMachine)
        {
            if (copyMachine.MoneyCount < copyMachine.PricePerDocument)
            {
                throw new Exception("Not enough money");
            }

            copyMachine.MoneyCount -= copyMachine.PricePerDocument;
            Console.Write(copyMachine.SelectedDevice.GetDocument(copyMachine.SelectedDocument));
            copyMachine.State = new SelectedDeviceState();
        }
    }
}
