
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
// TODO: Code
```
```
// TODO: Output
```

#### Full example

[NewsChannelExampleBoundedInput](./../../GofConsoleApp/Examples/Structural/ProxyPattern/NewsChannelExampleBoundedAccess.cs)


### Type 2: Proxy with bounded access and output

#### Code

```csharp
// TODO: Code
```
```
// TODO: Output
```

#### Full example

[UserInterfaceExampleBoundedAccess](./../../GofConsoleApp/Examples/Structural/ProxyPattern/UserInterfaceExampleBoundedAccess.cs)


### Type 3: Proxy with cached output

#### Code

```csharp
// TODO: Code
```
```
// TODO: Output
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
- A Proxy provides a surrogate or placeholder for another object to control access to it.

