﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace cSharpTemplate
{
    [TestFixture]
    public class ClubEventTests
    {
        [Test]
        public void Date_Test()
        {
            var concertDate = new DateTime(2015, 5, 1, 18, 0, 0);

            var club_event = new ClubEvent();
            club_event.Date = concertDate;

            Assert.AreEqual(club_event.Date, concertDate.Date);
        }

        [Test]
        public void Time_Test()
        {
            var concertDate = new DateTime(2015, 5, 1, 18, 0, 0);

            var club_event = new ClubEvent();
            club_event.Time = concertDate;

            Assert.AreEqual(club_event.Time.Hour, concertDate.Hour);
            Assert.AreEqual(club_event.Time.Minute, concertDate.Minute);
            Assert.AreEqual(club_event.Time.Second, concertDate.Second);
        }

        [Test]
        public void PerformersList_Test()
        {
            var performers = new List<string>();
            performers.Add("Robbie Williams");
            performers.Add("Metallica");
            performers.Add("Scorpions");

            var club_event = new ClubEvent();
            club_event.Performers = performers;

            Assert.AreEqual(club_event.Performers, performers);
        }
    }
}