namespace ThreadAffinity;

public class Defer
{
    private readonly Action _callback;
    private readonly ExecutionContext? _context;

    public Defer(Action callback)
    {
        _callback = callback;
        _context = ExecutionContext.Capture()!;
    }

    public void Run()
    {
        if (_context is null) { _callback(); return; }
        // When ExecutionContext.Run invokes the lambda we supply as the 2nd
        // argument, it passes that lambda the value we supplied as the 3rd
        // argument to Run. Here we're passing _callback, so the lambda has
        // access to the Action we want to invoke. It would have been simpler
        // to write "_ => _callback()" but the lambda would then need to
        // capture 'this' to be able to access _callback, and that capture
        // would cause an additional allocation.
        ExecutionContext.Run(_context, (cb) => ((Action)cb!)(), _callback);
    }
}
