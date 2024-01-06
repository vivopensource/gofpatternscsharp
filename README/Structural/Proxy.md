
# Proxy Pattern

- The proxy pattern is a structural design pattern that provides a surrogate or placeholder for another object to control access to it.
- A proxy is a wrapper or agent object that is being called by the client to access the real serving object behind the scenes.

## Structure

- It consists of subject, real subject and proxy.
- Subject: An interface that will contain the method to be implemented by the real subject and proxy.
- Real Subject: A class that will contain the actual implementation of the method.
- Proxy: A class that will contain the reference to the real subject and will implement the same interface implemented by the real subject so that it can be used by the client.

## Examples

### Type 1: Proxy with bounded access

#### Code

```csharp
// Create Inputs
enum EnumNewsChannel { Acy, Uzt, Mko }

// Create Component
interface INewsChannel : IProxyComponent<EnumNewsChannel> { }

class NewsChannel : INewsChannel
{
    public void Process(EnumNewsChannel input) =>
        Console.WriteLine($"Broadcasting news from '{input}' channel");
}

// Create Proxy - with Bounded Access
interface INewsChannelProxy : INewsChannel, IProxyBoundedAccess<EnumNewsChannel> { }

class NewsChannelProxy : ProxyBoundedAccess<EnumNewsChannel>, INewsChannelProxy
{
    public NewsChannelProxy() :
        base(new NewsChannel(), new[] { Acy, Uzt }) { }
}

// Pattern execution
var newsChannel = new NewsChannelProxy();
newsChannel.Process(EnumNewsChannel.Acy);
newsChannel.Process(EnumNewsChannel.Mko); // throws exception, 'Mko' is out of bounds
```
```
// Output
Broadcasting news from 'Acy' channel
Unhandled exception. System.ArgumentException: 'Mko' is out of bounds
   at GofPatterns.Structural.ProxyPattern.ProxyBoundedAccess`1.Process(TInput input) in ProxyBoundedAccess.cs
   at GofConsoleApp.Program.Main(String[] args) in Program.cs

```

#### Full example

[NewsChannelExampleBoundedInput](./../../GofConsoleApp/Examples/Structural/ProxyPattern/NewsChannelExampleBoundedAccess.cs)


### Type 2: Proxy with bounded access and output

#### Code

```csharp
// Create Inputs
enum EnumUserType { Admin, Standard, Guest }

enum EnumOperationOption { Read, Create, Mkdir, Remove, Rmdir }

// Create Component
interface IUserInterface : IProxyComponent<EnumOperationOption, string> { }

class UserInterface : IUserInterface
{
    public string Process(EnumOperationOption input)
    {
        return $"'{input}' executed successfully.";
    }
}

// Create Proxy - with Bounded Access
interface IUserInterfaceProxy : IUserInterface, IProxyBoundedAccess<EnumOperationOption, string> { }

class UserInterfaceProxyAdmin : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyAdmin(IUserInterface userInterface) :
        base(userInterface, new[] { Read, Create, Mkdir, Remove, Rmdir }) { }
}

class UserInterfaceProxyStandard : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyStandard(IUserInterface userInterface) : 
        base(userInterface, new[] { Read, Create, Mkdir }) { }
}

class UserInterfaceProxyGuest : ProxyBoundedAccess<EnumOperationOption, string>, IUserInterfaceProxy
{
    public UserInterfaceProxyGuest(IUserInterface userInterface) :
        base(userInterface, new[] { Read }) { }
}

// Pattern execution
EnumUserType userType = EnumUserType.Standard;
IUserInterface userInterface = new UserInterface();

IUserInterfaceProxy proxyInterface = userType switch
{
    Admin => new UserInterfaceProxyAdmin(userInterface),
    Standard => new UserInterfaceProxyStandard(userInterface),
    _ => new UserInterfaceProxyGuest(userInterface)
};

Console.WriteLine(proxyInterface.Process(EnumOperationOption.Create));
Console.WriteLine(proxyInterface.Process(EnumOperationOption.Mkdir));
Console.WriteLine(proxyInterface.Process(EnumOperationOption.Remove));
```
```
// Output
'Create' executed successfully.
'Mkdir' executed successfully.
Unhandled exception. System.ArgumentException: 'Remove' is out of bounds
   at GofPatterns.Structural.ProxyPattern.ProxyBoundedAccess`2.Process(TInput input) in ProxyBoundedAccess.cs
   at GofConsoleApp.Program.Main(String[] args) in Program.cs

```

#### Full example

[UserInterfaceExampleBoundedAccess](./../../GofConsoleApp/Examples/Structural/ProxyPattern/UserInterfaceExampleBoundedAccess.cs)


### Type 3: Proxy with cached output

#### Code

```csharp
// Create Inputs
enum EnumConfigEnv { Dev, Prod, Test }

// Create Output Component
class Config
{
    public EnumConfigEnv EnvType { get; init; }
    public string DatabaseConnection { get; init; } = string.Empty;
}

// Create Subject (also Real Subject here)
class ConfigProvider : IProxyComponent<EnumConfigEnv, Config>
{
    public Config Process(EnumConfigEnv input)
    {
        Console.WriteLine($"Loading '{input}'.");

        return new Config
        {
            EnvType = input,
            DatabaseConnection = input + "-DatabaseConnection"
        };
    }
}

// Pattern execution
var component = new ConfigProvider();
var proxy = new ProxyCachedOutput<EnumConfigEnv, Config>(component);

EnumConfigEnv type = EnumConfigEnv.Dev;
Console.WriteLine($"Loading '{type}'.");
Config conf = proxy.Process(type);
Console.WriteLine($"Env={conf.EnvType}, DatabaseConnection={conf.DatabaseConnection}");

type = EnumConfigEnv.Test;
Console.WriteLine($"Loading '{type}'.");
conf = proxy.Process(type);
Console.WriteLine($"Env={conf.EnvType}, DatabaseConnection={conf.DatabaseConnection}");


type = EnumConfigEnv.Dev;
Console.WriteLine($"Loading '{type}'.");
conf = proxy.Process(type); // 'Dev' was already in loaded and saved in cached, so  its picked up from cache.
Console.WriteLine($"Env={conf.EnvType}, DatabaseConnection={conf.DatabaseConnection}");

type = EnumConfigEnv.Prod;
Console.WriteLine($"Loading '{type}'.");
conf = proxy.Process(type);
Console.WriteLine($"Env={conf.EnvType}, DatabaseConnection={conf.DatabaseConnection}");
```
```
// Output
--- Loading 'Dev' ---
Env=Dev, DatabaseConnection=Dev-DatabaseConnection
--- Loading 'Test' ---
Env=Test, DatabaseConnection=Test-DatabaseConnection
Env=Dev, DatabaseConnection=Dev-DatabaseConnection
--- Loading 'Prod' ---
Env=Prod, DatabaseConnection=Prod-DatabaseConnection
```

#### Full example

[ConfigProviderExampleCachedOutput](./../../GofConsoleApp/Examples/Structural/ProxyPattern/ConfigProviderExampleCachedOutput.cs)


## Benefits

- It provides the protection to the original object from the outside world.
- It adds the security to the original object of an application.
- It provides the controlled access of the functionality to the original object.
- It manages the life cycle of the object.
- It can be used as a gateway to remote resources.
- It can be used as a wrapper to add extra functionality.

## Comparison with other patterns

- Adapter provides a different interface to the wrapped object, Proxy provides it with the same interface, and Decorator provides it with an enhanced interface.
- Decorator and Proxy have different purposes but similar structures. Both describe how to provide a level of indirection to another object, and the implementations keep a reference to the object to which they forward requests.
- Decorator supports recursive composition, which isn't possible when you use Proxy or Adapter.
- Decorator and Proxy are similar in structure, but they solve different problems.

