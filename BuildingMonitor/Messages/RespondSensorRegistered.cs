using Akka.Actor;

namespace BuildingMonitor.Messages
{
    public sealed class RespondSensorRegistered
    {
        public long RequestId { get; set; }
        public IActorRef SensorReference { get; set; }

        public RespondSensorRegistered(long requestId, IActorRef sensorReference)
        {
            RequestId = requestId;
            SensorReference = sensorReference;
        }
    }
}