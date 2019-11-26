namespace State
{
    public class CopyMachine
    {
        public int PricePerDocument { get; }
        public IState State { get; set; }
        public int MoneyCount { get; set; }
        public IDevice SelectedDevice { get; set; }
        public int SelectedDocument { get; set; }

        public CopyMachine(int pricePerDocument)
        {
            PricePerDocument = pricePerDocument;
            State = new IdleState();
            MoneyCount = 0;
        }

        public void AddMoney(int count) => State.AddMoney(this, count);

        public void SelectDevice(IDevice device) => State.SelectDevice(this, device);

        public void SelectDocument(int document) => State.SelectDocument(this, document);

        public void Print() => State.Print(this);

        public int GiveChange() => State.GiveChange(this);
    }
}
