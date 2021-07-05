```java
public enum Singleton {

    INSTANCE;

    public void doSomething() {
        System.out.println("doSomething");
    }

}

//调用方式
Singleton.INSTANCE.doSomething();
```

```csharp
public enum SingletonByEnum
{
    Instance
}

public static class SingletonByEnumExtension
{
    public static void DoSomething(this SingletonByEnum instance) => Console.WriteLine("DoSomething");
}

//调用方式
SingletonByEnum.Instance.DoSomething();
```