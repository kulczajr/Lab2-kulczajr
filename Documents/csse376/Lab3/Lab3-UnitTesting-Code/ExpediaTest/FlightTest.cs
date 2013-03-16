using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
	{
        private readonly int flightDistance = 100;
        private DateTime flightEnd = new DateTime(2013, 3, 15);
        private DateTime flightStart = new DateTime(2013, 3, 12);

        [Test()]
        public void TestThatFlightInitializes()
        {
            var target = new Flight(flightStart, flightEnd, flightDistance);
            Assert.IsNotNull(target);
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForOneDayFlight()
        {
            var target = new Flight(new DateTime(2013, 3, 15), new DateTime(2013, 3, 16), 300);
            Assert.AreEqual(220, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTwoDayFlight()
        {
            var target = new Flight(new DateTime(2013, 4, 15), new DateTime(2013, 4, 17), 300);
            Assert.AreEqual(240, target.getBasePrice());
        }

        [Test()]
        public void TestThatFlightHasCorrectBasePriceForTenDayFlight()
        {
            var target = new Flight(new DateTime(2013, 4, 15), new DateTime(2013, 4, 25), 300);
            Assert.AreEqual(400, target.getBasePrice());
        }

        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightThrowsOnBadDates()
        {
            new Flight(new DateTime(2013, 4, 15), new DateTime(2013, 4, 10), 300);
        }

        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightThrowsOnBadMiles()
        {
            new Flight(new DateTime(2013, 4, 15), new DateTime(2013, 4, 17), -200);
        }
	}
}
