namespace BuildingMonitor.Messages
{
    public sealed class RespondMetadata
    {
        public RespondMetadata(long requestId, string floorId, string sensorId)
        {
            RequestId = requestId;
            FloorId = floorId;
            SensorId = sensorId;
        }

        public long RequestId { get; }
        public string FloorId { get; }
        public string SensorId { get; }
    }
}