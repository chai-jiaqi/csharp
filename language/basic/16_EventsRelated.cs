﻿using System;
using System.Diagnostics.CodeAnalysis;
using basic.Common;
using Xunit;

namespace basic
{
    public class EventsRelated
    {
        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction", 
            Justification = "We will not cover csharp 7 here")]
        public void event_is_subset_of_delegate_with_event_handler_type()
        {
            var demoObject = new BasicEventDemoClass();
            var eventIsCalled = false;

            EventHandler eventHandler = (sender, eventArgs) =>
            {
                eventIsCalled = true;
            };

            demoObject.Event += eventHandler;

            demoObject.TriggerEvent();

            // change the variable value to fix the test.
            const bool expectedIsEventCalled = true;

            Assert.Equal(expectedIsEventCalled, eventIsCalled);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void should_unbind_event()
        {
            var demoObject = new BasicEventDemoClass();
            var eventIsCalled = false;

            EventHandler eventHandler = (sender, eventArgs) =>
            {
                eventIsCalled = true;
            };

            demoObject.Event += eventHandler;
            demoObject.Event -= eventHandler;

            demoObject.TriggerEvent();

            // change the variable value to fix the test.
            const bool expectedIsEventCalled = false;

            Assert.Equal(expectedIsEventCalled, eventIsCalled);
        }

        [Fact]
        [SuppressMessage("ReSharper", "ConvertToLocalFunction")]
        public void should_be_able_to_customize_event_args()
        {
            var demoObject = new CustomizeEventArgsDemoClass();
            string greetingContent = string.Empty;

            EventHandler<GreetingEventArgs> eventHandler = (sender, eventArgs) =>
            {
                greetingContent = eventArgs.GreetingContent;
            };

            demoObject.Greeting += eventHandler;

            demoObject.Greet("World");

            // change the variable value to fix the test.
            const string expectedContent = "Hello World";

            Assert.Equal(expectedContent, greetingContent);
        }

        [Fact]
        public void should_customize_event_accessor()
        {
            var demoObject = new CustomizeEventAccessorDemoClass();

            // change the variable value to fix the test.
            var expectedExceptionType = typeof(ArgumentNullException);

            Assert.Throws(expectedExceptionType, () => demoObject.Event += null);
        }
    }
}