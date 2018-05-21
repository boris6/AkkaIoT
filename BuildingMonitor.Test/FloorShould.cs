using Akka.TestKit.Xunit2;
using BuildingMonitor.Actors;
using BuildingMonitor.Messages;
using Xunit;

namespace BuildingMonitor.Test
{
    public class FloorShould : TestKit
    {
        [Fact]
        public void RegisterNewTemperatureSensorWhenDoesNotAlreadyExist()
        {
            var probe = CreateTestProbe();
            var floor = Sys.ActorOf(Floor.Props("a"));

            floor.Tell(new RequestRegisterTemperatureSensor(1, "a", "42"), probe.Ref);

            var received = probe.ExpectMsg<RespondSensorRegistered>();
            Assert.Equal(1, received.RequestId);

            var sensorActor = probe.LastSender;

            sensorActor.Tell(new RequestUpdateTemperature(42, 100), probe.Ref);
        }
    }
}