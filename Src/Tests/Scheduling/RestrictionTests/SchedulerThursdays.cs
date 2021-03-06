using System;
using System.Threading.Tasks;
using Coravel.Scheduling.Schedule;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Tests.Scheduling.Helpers.SchedulingTestHelpers;

namespace Tests.Scheduling.RestrictionTests
{
    [TestClass]
    public class SchedulerThursdays
    {
        [TestMethod]
        [DataTestMethod]
        public async Task DailyOnThursdaysOnly() {
              var scheduler = new Scheduler();
            int taskRunCount = 0;

            scheduler.Schedule(() => taskRunCount++)
            .Daily()
            .Thursday();

            await scheduler.RunAtAsync(DateTime.Parse("2018/06/06")); 
            await scheduler.RunAtAsync(DateTime.Parse("2018/06/07")); //Thursday
            await scheduler.RunAtAsync(DateTime.Parse("2018/06/08"));
            await scheduler.RunAtAsync(DateTime.Parse("2018/06/13")); 
            await scheduler.RunAtAsync(DateTime.Parse("2018/06/14")); //Thursday
            await scheduler.RunAtAsync(DateTime.Parse("2018/06/15")); 

            Assert.IsTrue(taskRunCount == 2);
        }
    }
}