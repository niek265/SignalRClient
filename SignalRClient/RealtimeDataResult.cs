namespace SignalRClient
{
    public class RealtimeDataResult
    {
        // Rmssd is the HRV value
        public float Rmssd { get; set; }
        // Hr is the heart rate value
        public float Hr { get; set; }
        // StatusCode has the status of the data
        // 1 means it is calibrating (takes about 90 seconds)
        // 2 means the data is low quality
        // 3 means the data is good quality
        public int StatusCode { get; set; }
    }
}