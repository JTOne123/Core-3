﻿using System;
using CreativeCoders.Core.Weak;
using Xunit;
using Xunit.Abstractions;

namespace CreativeCoders.Core.UnitTests.Weak
{
    public class WeakActionTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        [Fact]
        public void WeakActionCtorTest()
        {
            var weakAction = new WeakAction(() => { });
            var weakAction2 = new WeakAction(null, () => { });

            weakAction.Execute();
            weakAction2.Execute();

            Assert.Throws<ArgumentNullException>(() => new WeakAction(null));
        }

        [Fact]
        public void WeakActionExecuteTest()
        {
            var actionExecuted = false;

            var weakAction = new WeakAction(() => actionExecuted = true);

            Assert.False(actionExecuted);

            weakAction.Execute();

            Assert.True(actionExecuted);
        }

        [Fact]
        public void WeakActionExecuteTestWithoutTarget()
        {
            StaticActionExecuted  = false;
            var weakAction = new WeakAction(null, StaticActionExecute);

            weakAction.Execute();

            Assert.True(StaticActionExecuted);
        }

        private static bool StaticActionExecuted;

        public WeakActionTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        private static void StaticActionExecute()
        {
            StaticActionExecuted = true;
        }

        [Fact]
        public void WeakActionCreateActionTest()
        {
            var actionExecuted = false;

            var weakAction = new WeakAction(() => actionExecuted = true);

            Assert.False(actionExecuted);

            var action = weakAction.CreateAction<Action>();

            Assert.NotNull(action);

            action();

            Assert.True(actionExecuted);
        }

        [Fact]
        public void WeakActionGenericCtorTest()
        {
            var iValue = 0;
            var weakAction = new WeakAction<int>(i => iValue = i);
            weakAction.Execute(10);
            Assert.True(iValue == 10);

            weakAction = new WeakAction<int>(i => _testOutputHelper.WriteLine(i.ToString()));
            weakAction.Execute(10);
        }

        [Fact]
        public void WeakActionGenericExecuteTest()
        {
            var iValue = 0;
            var weakAction = new WeakAction<int>(i => iValue = i);

            weakAction.Execute(10);

            Assert.True(iValue == 10);

            weakAction.Execute();

            Assert.True(iValue == 0);
        }

        [Fact]
        public void CtorKeepAliveActionTarget()
        {
            // ReSharper disable once ConvertToLocalFunction
            Action action = () => { };
            var weakAction = new WeakAction(action, KeepActionTargetAliveMode.NotKeepAlive);

            Assert.False(weakAction.KeepActionTargetAlive);

            var weakAction2 = new WeakAction(action, KeepActionTargetAliveMode.KeepAlive);

            Assert.True(weakAction2.KeepActionTargetAlive);

            var weakAction3 = new WeakAction(action, KeepActionTargetAliveMode.AutoGuess);

            Assert.True(weakAction3.KeepActionTargetAlive);
        }

        [Fact]
        public void CtorKeepAliveActionTargetGeneric()
        {
            // ReSharper disable once ConvertToLocalFunction
            Action<string> action = s => { };
            var weakAction = new WeakAction<string>(action, KeepActionTargetAliveMode.NotKeepAlive);

            Assert.False(weakAction.KeepActionTargetAlive);

            var weakAction2 = new WeakAction<string>(action, KeepActionTargetAliveMode.KeepAlive);

            Assert.True(weakAction2.KeepActionTargetAlive);

            var weakAction3 = new WeakAction<string>(action, KeepActionTargetAliveMode.AutoGuess);

            Assert.True(weakAction3.KeepActionTargetAlive);
        }

        [Fact]
        public void DisposeTest()
        {
            // ReSharper disable once ConvertToLocalFunction
            Action<string> action = s => { };
            var weakAction = new WeakAction<string>(action, KeepActionTargetAliveMode.KeepAlive);

            weakAction.Dispose();

            Assert.False(weakAction.IsAlive);            
        }
    }
}