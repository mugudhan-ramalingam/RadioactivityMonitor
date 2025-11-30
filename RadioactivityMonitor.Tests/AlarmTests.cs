using Microsoft.VisualStudio.TestTools.UnitTesting;
using RadioactivityMonitor;
using RadioactivityMonitor.Core;

namespace RadioactivityMonitor.Tests
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void Alarm_ShouldBeOff_ByDefault()
        {
            // arrange
            var alarm = new Alarm(new FakeSensor(18.0)); // safe value

            // assert
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_ShouldRemainOff_WhenValueIsWithinRange()
        {
            // arrange
            var alarm = new Alarm(new FakeSensor(18.0)); // between 17 and 21

            // act
            alarm.Check();

            // assert
            Assert.IsFalse(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_ShouldTurnOn_WhenValueIsBelowLowThreshold()
        {
            // arrange
            var alarm = new Alarm(new FakeSensor(10.0)); // below 17

            // act
            alarm.Check();

            // assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_ShouldTurnOn_WhenValueIsAboveHighThreshold()
        {
            // arrange
            var alarm = new Alarm(new FakeSensor(25.0)); // above 21

            // act
            alarm.Check();

            // assert
            Assert.IsTrue(alarm.AlarmOn);
        }

        [TestMethod]
        public void Alarm_ShouldTreatBoundaryValues_AsSafe()
        {
            // 17 should be considered safe
            var alarmAtLow = new Alarm(new FakeSensor(17.0));
            alarmAtLow.Check();
            Assert.IsFalse(alarmAtLow.AlarmOn);

            // 21 should be considered safe
            var alarmAtHigh = new Alarm(new FakeSensor(21.0));
            alarmAtHigh.Check();
            Assert.IsFalse(alarmAtHigh.AlarmOn);
        }
    }

    internal class FakeSensor : ISensor
    {
        private readonly double _value;

        public FakeSensor(double value)
        {
            _value = value;
        }

        public double NextMeasure()
        {
            return _value;
        }
    }
}
