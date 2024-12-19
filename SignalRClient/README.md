# SignalRClient

SignalRClient is a C# application that connects to a SignalR hub to receive and send real-time heart rate variability (HRV) data.

## Prerequisites

- .NET 9.0 SDK

## Installation

1. To include the SignalR dependency in your Unity Project, please refer to the NuGet for Unity package:  
   https://github.com/GlitchEnzo/NuGetForUnity

2. Look at the `Program.cs` file to see how to connect to the SignalR hub and send/receive data.

3. The `RealtimeDataResult.cs` file contains the data structure for the HRV data received from the SignalR hub.

## Configuration

Update the `Host` constant in `Program.cs` to point to your SignalR server URL:
```csharp
private const string Host = "http://localhost:8080/";
```

Update the `Passphrase` constant in `Program.cs` to match the passphrase set in the SignalR server:
```csharp
private const string Passphrase = "test";
```

## Project Structure

- `SignalRClient.csproj`: Project file containing dependencies and build configurations.
- `Program.cs`: Main entry point of the application, handles connection to the SignalR hub and data transmission.
- `RealtimeDataResult.cs`: Defines the data structure for the HRV data received from the SignalR hub.

## Dependencies

- `Microsoft.AspNetCore.SignalR.Client` version `9.0.0`