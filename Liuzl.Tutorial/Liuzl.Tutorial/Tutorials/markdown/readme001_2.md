### 示例2
假设我们要按照如下步骤制作早餐：
1. 倒一杯咖啡
2. 加热平底锅，然后煎两个鸡蛋
3. 煎三片培根
4. 烤两片面包
5. 在烤面包上加黄油和果酱
6. 倒一杯橙汁

通常的代码：
```csharp
//下面没有给出各个对象的定义，仅用作示例
static void Main(string[] args)
{
    Coffee cup = PourCoffee();
    Console.WriteLine("coffee is ready");

    Egg eggs = FryEggs(2);
    Console.WriteLine("eggs are ready");

    Bacon bacon = FryBacon(3);
    Console.WriteLine("bacon is ready");

    Toast toast = ToastBread(2);
    ApplyButter(toast);
    ApplyJam(toast);
    Console.WriteLine("toast is ready");

    Juice oj = PourOJ();
    Console.WriteLine("oj is ready");
    Console.WriteLine("Breakfast is ready!");
}
```

异步方法的代码：
```csharp
static async Task Main(string[] args)
{
    Coffee cup = PourCoffee();
    Console.WriteLine("coffee is ready");

    var eggsTask = FryEggsAsync(2);
    var baconTask = FryBaconAsync(3);
    var toastTask = MakeToastWithButterAndJamAsync(2);

    var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
    while (breakfastTasks.Count > 0)
    {
        //注意这里的Task.WhenAny
        Task finishedTask = await Task.WhenAny(breakfastTasks); 
        if (finishedTask == eggsTask)
        {
            Console.WriteLine("eggs are ready");
        }
        else if (finishedTask == baconTask)
        {
            Console.WriteLine("bacon is ready");
        }
        else if (finishedTask == toastTask)
        {
            Console.WriteLine("toast is ready");
        }
        breakfastTasks.Remove(finishedTask);
    }

    Juice oj = PourOJ();
    Console.WriteLine("oj is ready");
    Console.WriteLine("Breakfast is ready!");
}

static async Task<Toast> MakeToastWithButterAndJamAsync(int number) 
{
    var toast = await ToastBreadAsync(number);
    return toast;
}
```

### 补充说明
* 异步编程很重要，应用也非常广泛，应该熟练掌握！