using Akka.Actor;
using BuildingMonitor.Messages;

namespace BuildingMonitor.Actors
{
    public class TemperatureSensor : UntypedActor
    {
        private string _sensorId;
        private string _floorId;
        private double? _lastRecordedTemperature;

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RequestMetadata m:
                    Sender.Tell(new RespondMetadata(m.RequestId, _floorId, _sensorId));
                    break;

                case RequestTemperature m:
                    Sender.Tell(new RespondTemperature(m.RequestId, _lastRecordedTemperature));
                    break;

                case RequestUpdateTemperature m:
                    _lastRecordedTemperature = m.Temperature;
                    Sender.Tell(new RespondTemperatureUpdated(m.RequestId));
                    break;

                case RequestRegisterTemperatureSensor m when m.FloorId == _floorId && m.SensorId == _sensorId:
                    Sender.Tell(new RespondSensorRegistered(m.RequestId, Context.Self));
                    break;

                default:
                    Unhandled(message);
                    break;
            }
        }

        public TemperatureSensor(string floorId, string sensorId)
        {
            _floorId = floorId;
            _sensorId = sensorId;
        }

        public static Props Props(string floorId, string sensorId) =>
            Akka.Actor.Props.Create(() => new TemperatureSensor(floorId, sensorId));
    }
}