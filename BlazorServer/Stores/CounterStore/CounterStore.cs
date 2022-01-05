using System;

namespace BlazorServer.Stores.CounterStore
{

    public class CounterState
    {
        public int Count { get; }

        public CounterState(int count)
        {
            Count = count;
        }
    }

    public class CounterStore
    {
        private CounterState _state;

        public CounterState GetState()
        {
            return _state;
        }

        private void HandleActions(IAction action)
        {
            switch (action.Name)
            {
                case IncrementAction.INCREMENT:
                    IncremetCount();
                    break;
                case DecrementAction.DECREMENT:
                    DecremetCount();
                    break;
                default:
                    break;
            }
        }
        public CounterStore(IActionDispatcher actionDispatcher)
        {   
            
            _state = new CounterState(0);
            this.actionDispatcher = actionDispatcher;
            this.actionDispatcher.Subscript(HandleActions);
        }

        ~CounterStore()
        {
            this.actionDispatcher.Unsubscript(HandleActions);
        }
        private void IncremetCount()
        {
            var count = this._state.Count;
            count++;
            this._state = new CounterState(count);
            BroadCastChange();
        }

        private void DecremetCount()
        {
            var count = this._state.Count;
            count--;
            this._state = new CounterState(count);
            BroadCastChange();
        }
        #region observer pattern

        ////////////////////'

        private Action _listeners;
        private readonly IActionDispatcher actionDispatcher;

        public void AddStateChanger(Action listener)
        {
            _listeners += listener;
        }       
        public void RemoveStateChanger(Action listener)
        {
            _listeners -= listener;
        }

        private void BroadCastChange()
        {
            _listeners.Invoke();
        }
        
        #endregion
    }
}