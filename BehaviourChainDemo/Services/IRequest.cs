namespace BehaviourChainDemo.Services
{
    public interface IRequest
    {
        void AppendToOutput(string message);
        string Output { get; set; }
    }
}