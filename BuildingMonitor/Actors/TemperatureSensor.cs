﻿using Akka.Actor;
using BuildingMonitor.Messages;

namespace BuildingMonitor.Actors
{
    public class TemperatureSensor : UntypedActor
    {
        private string _sensorId;
        private string _floorId;
        private double? lastRecordedTemperature;

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case RequestMetadata m:
                    Sender.Tell(new RespondMetadata(m.RequestId, _floorId, _sensorId));
                    break;

                case RequestTemperature m:
                    Sender.Tell(new RespondTemperature(m.RequestId, lastRecordedTemperature));
                    break;

                default:
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