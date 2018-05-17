namespace BuildingMonitor.Messages
{
    public class RequestTemperature
    {
        public RequestTemperature(long requestId)
        {
            RequestId = requestId;
        }

        public long RequestId { get; }
    }
}