﻿using Bogus;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace MaxProfit
{
    public abstract class UnitTestBase<TUnderTest>
        where TUnderTest : class
    {
        protected TUnderTest TestInstance { get; private set; }

        protected AutoMocker AutoMocker;

        [SetUp]
        public void SetUp()
        {
            AutoMocker = new AutoMocker(MockBehavior.Loose);
            TestInstance = AutoMocker.CreateInstance<TUnderTest>();
        }

        [TearDown]
        public void TearDown()
        {
            AutoMocker = null;
            TestInstance = null;
        }

        protected Faker Faker => new Faker();

        protected T CreateMock<T>(MockBehavior mockBehaviour = MockBehavior.Loose) where T : class
        {
            return new Mock<T>(mockBehaviour).Object;
        }

        protected T CreateMock<T>(MockBehavior mockBehaviour = MockBehavior.Loose, params object[] args) where T : class
        {
            return new Mock<T>(mockBehaviour, args).Object;
        }

        protected T GetDependency<T>() where T : class 
        {
            return AutoMocker.GetMock<T>().Object;
        }
    }
}