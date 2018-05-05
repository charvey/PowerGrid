using System;
using System.Linq;
using PowerGrid.Decide;
using PowerGrid.Domain.Actions;
using PowerGrid.Domain.Game;
using Xunit;

namespace Test.Decide
{
    public class BasicDeciderTests
    {
        [Fact]
        public void AlwaysKeepPlaying()
        {
            var subject=new BasicDecider();

            var actions=subject.DecideActions(null);

            Assert.Contains(actions.OfType<UserRecommendation>(),r=>r.Recommendation=="Keep playing!");
        }
    }
}
