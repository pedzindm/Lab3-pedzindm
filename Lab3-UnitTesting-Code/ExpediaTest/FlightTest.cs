using System;
using Expedia;
using NUnit.Framework;

namespace ExpediaTest
{
	[TestFixture()]
	public class FlightTest
    {
        private readonly DateTime dateThatFlightLeaves = new DateTime(2010, 11, 11);
        private readonly DateTime dateThatFlightReturns = new DateTime(2010, 11, 15);

        [Test()]
        public void TestFLightInitializes()
        {
            var target = new Flight(new DateTime(2011,11,15), new DateTime(2011,11,19),15000 );
            Assert.IsNotNull(target);
        }
        [Test()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TestThatFlightHasCorrectFLightTimes ()
        {
            var target = new Flight(new DateTime(2011, 11, 19),new DateTime(2011, 11, 15), 15000);     
        }
        [Test()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestThatFlightHasCorrectMileage()
        {
            var target = new Flight(new DateTime(2011, 11, 15), new DateTime(2011, 11, 19), -15000);
        }
        [Test()]
        public void TestThatFLightHasCorrectBasePriceForOneDaySpread()
        {
            var target = new Flight(new DateTime(2011, 11, 15), new DateTime(2011, 11, 16), 15000);
            Assert.AreEqual(220, target.getBasePrice());
        }
        [Test()]
        public void TestThatFLightHasCorrectBasePriceForFiveDaySpread()
        {
            var target = new Flight(new DateTime(2011, 11, 15), new DateTime(2011, 11, 20), 15000);
            Assert.AreEqual(300, target.getBasePrice());
        }
        [Test()]
        public void TestThatFLightHasCorrectBasePriceFor16DaySpread()
        {
            var target = new Flight(new DateTime(2011, 11, 15), new DateTime(2011, 12, 1), 15000);
            Assert.AreEqual(520, target.getBasePrice());
        }
        [Test()]
        public void TestThatFLightHasCorrectBasePriceForyearDaySpread()
        {
            var target = new Flight(new DateTime(2011, 11, 15), new DateTime(2012, 11, 15), 15000);
            Assert.AreEqual(7520, target.getBasePrice());
        }
	}
}
