using System.Collections.Generic;
using GameJam2022.JekyllHyde.Controller.State.Interface;

namespace GameJam2022.JekyllHyde.Controller.State
{
    public class StateMachineManager : IStateMachineManager
    {
        private Stack<IState> Stack { get; }

        public IState CurrentState => Stack.Count > 0 ? Stack.Peek() : null;

        public StateMachineManager()
        {
            Stack = new Stack<IState>();
        }
        
        public void PushState(IState newState)
        {
            Stack.Push(newState);
            CurrentState.Initialize(this);
        }

        public void PopState()
        {
            Stack.Pop();
        }

        public void SwapState(IState newState)
        {
            PopState();
            PushState(newState);
        }
    }
}