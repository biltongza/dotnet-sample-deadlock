var _lock1 = new object();
var _lock2 = new object();

var t1 = Task.Run(() =>
{
    lock (_lock1)
    {
        //Thread.Sleep(1);
        lock (_lock2)
        {
            Console.WriteLine("Hello from task 1!");
        }
    }
});

var t2 = Task.Run(() =>
{
    lock (_lock2)
    {
        //Thread.Sleep(1);
        lock (_lock1)
        {
            Console.WriteLine("Hello from task 2!");
        }
    }
});

await Task.WhenAll(t1, t2);