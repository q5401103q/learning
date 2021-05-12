## 保留关键字 event
`event` 关键字用于声明事件。<br>

### 定义描述
.NET 类库中的所有事件均基于 `EventHandler` 委托，定义如下：
```csharp
public delegate void EventHandler(object sender, EventArgs e);
```
.NET Framework 2.0中引入了泛型版本的委托，定义如下：
```csharp
public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);
```

### 使用描述
下面的代码展示了如何使用符合.NET准则的事件。
```csharp 
using System;

namespace Liuzl.Tutorial.Samples
{
    public class Demo007
    {
        public delegate void OnDomClickedHandler(object sender, DomClickEventArgs e);
        public event OnDomClickedHandler OnDomClicked;

        public void Test()
        {
            OnDomClicked(this, new DomClickEventArgs() { Message = "dom clicked" });
        }
    }

    public class DomClickEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
```

### 调用示例
```csharp
//调用示例
Demo007 demo = new Demo007();
demo.OnDomClicked += Demo_OnDomClicked;
demo.Test();

void Demo_OnDomClicked(object sender, DomClickEventArgs e)
{
    var demo007 = sender as Demo007;
    Console.WriteLine("sender={0}", demo007.ToString());
    Console.WriteLine("message={0}", e.Message);
}

//输出结果:
// sender=Liuzl.Tutorial.Samples.Demo007
// message=dom clicked
```

### 补充说明
* 事件是一种特殊的多播委托，仅可以从声明事件的类或结构中对其进行调用。
* 如果其他类或结构订阅该事件，则在发布服务器类引发该事件时，将调用其事件处理程序方法。
* 可以将事件标记为 `public`、`private`、`protected`、`internal`、`protected internal` 或 `private protected`。 这些访问修饰符定义该类的用户访问该事件的方式。 有关详细信息，请参阅访问修饰符。