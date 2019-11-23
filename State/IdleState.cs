using System;

namespace State
{
    public class IdleState : BaseState
    {
        public override void Print(CopyMachine copyMachine)
        {
            throw new Exception("Device not selected");
        }

        public override void SelectDocument(CopyMachine copyMachine, int document)
        {
            throw new Exception("Device not selected");
        }
    }
}
