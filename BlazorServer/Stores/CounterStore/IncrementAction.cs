namespace BlazorServer.Stores.CounterStore
{
    public class IncrementAction:IAction
    {
        public const string INCREMENT = "INCREMENT";
        public string Name => INCREMENT;
        public int Count { get; set; }
    }
}