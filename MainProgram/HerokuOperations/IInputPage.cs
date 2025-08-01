namespace HerokuOperations
{
    public interface IInputPage
    {
        void GotoPage();                      // Open the inputs page
        void EnterNumber(string number);      // Type number into input
        void IncreaseValue(int steps);        // Press arrow up N times
        void DecreaseValue(int steps);        // Press arrow down N times
        string GetInputValue();               // Get current value in input box
    }
}
