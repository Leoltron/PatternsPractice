namespace State
{
    public abstract class BaseState : IState
    {
        public void AddMoney(CopyMachine copyMachine, int count)
        {
            copyMachine.MoneyCount += count;
        }

        public void SelectDevice(CopyMachine copyMachine, IDevice device)
        {
            copyMachine.SelectedDevice = device;
            copyMachine.State = new SelectedDeviceState();
        }

        public abstract void Print(CopyMachine copyMachine);
        public abstract void SelectDocument(CopyMachine copyMachine, int document);

        public int GiveChange(CopyMachine copyMachine)
        {
            var change = copyMachine.MoneyCount;
            copyMachine.MoneyCount = 0;
            return change;
        }
    }
}