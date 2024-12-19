using Microsoft.AspNetCore.SignalR.Client;
using static System.Console;

namespace SignalRClient
{
    internal class ClientConnector
    {
        private const string Host = "https://localhost/";
        private const string Passphrase = "test";
        
        private readonly HubConnection _hubConnection = new HubConnectionBuilder()
            .WithUrl($"{Host}api/hrv-realtime", options =>
            {
                // Add the authorization token to the request headers
                options.Headers.Add("Authorization", Passphrase);
            })
            .WithAutomaticReconnect()
            .Build();

        private void Connect()
        {
            // Start the connection to the API
            _hubConnection.StartAsync().Wait();
            
            // Set the event handler for receiving HRV data
            _hubConnection.On<RealtimeDataResult>("ReceiveHRV", receivedObject =>
            {
                WriteLine($"Received HRV data: RMSSD={receivedObject.Rmssd}, HR={receivedObject.Hr}, Status={receivedObject.StatusCode}");
                HandleTextMessage(receivedObject);
            });
        }
        
        private static void HandleTextMessage(RealtimeDataResult receivedObject)
        {
            // Do something with the received data, you can do whatever you want here
            WriteLine(receivedObject.Rmssd);
        }
        
        private async void SendRealtimeData(int rrValue)
        {
            try
            {
                // Send the RR value to the API
                await _hubConnection.SendAsync("AddRR", rrValue);
                WriteLine($"Sent RR: {rrValue} to Vitals realtime API");
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }
        
        private static void Main()
        {
            // Connect to the API
            var clientConnector = new ClientConnector();
            clientConnector.Connect();
            
            // Generate a list of random RR values, which are the time between heartbeats
            var random = new Random();
            var rrValues = new List<int>();
            for (var i = 0; i < 100; i++)
            {
                rrValues.Add(random.Next(500, 1000));
            }
            
            // Send the RR values to the Vitals API
            foreach (var rrValue in rrValues)
            {
                // Simulate a delay between sending each RR value
                Thread.Sleep(rrValue);
                clientConnector.SendRealtimeData(rrValue);
            }
        }
        
    }
    
}

