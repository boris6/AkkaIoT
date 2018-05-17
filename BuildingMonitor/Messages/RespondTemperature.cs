namespace BuildingMonitor.Messages
{
    public class RespondTemperature
    {
        public long RequestId { get; }
        public double? Temperature { get; }

        public RespondTemperature(long requestId, double? temperature)
        {
            RequestId = requestId;
            Temperature = temperature;
        }
    }
}