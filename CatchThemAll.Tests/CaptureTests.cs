using CatchThemAll.Application.Interfaces;
using CatchThemAll.Application.Services;
using CatchThemAll.Infra.CrossCutting.IoC;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CatchThemAll.Tests
{
    [TestClass]
    public class CaptureTests
    {
        private readonly ICaptureAppService _service;

        public CaptureTests()
        {
            _service = new CaptureAppService();
        }

        [TestMethod]
        public void TestCaptureWithOneValidMoviment()
        {
            const int expectedResult = 2;
            var capturedPokemons = _service.Capture("E");

            Assert.AreEqual(capturedPokemons, expectedResult);
        }

        [TestMethod]
        public void TestCaptureWithOneRepeatedCell()
        {
            const int expectedResult = 4;
            var capturedPokemons = _service.Capture("NESO");

            Assert.AreEqual(capturedPokemons, expectedResult);
        }

        [TestMethod]
        public void TestCaptureWithMultipleRepeatedCells()
        {
            const int expectedResult = 2;
            var capturedPokemons = _service.Capture("NSNSNSNSNS");

            Assert.AreEqual(capturedPokemons, expectedResult);
        }

        [TestMethod]
        public void TestCaptureWithInvalidInput()
        {
            Assert.ThrowsException<ArgumentException>(() => _service.Capture("!QTMH"));
        }

        [TestMethod]
        public void TestCaptureWithValidsLowercaseLetters()
        {
            const int expectedResult = 4;
            var capturedPokemons = _service.Capture("neso");

            Assert.AreEqual(capturedPokemons, expectedResult);
        }

        [TestMethod]
        public void TestCaptureWithLargeValidInput()
        {
            const int expectedResult = 62;
            var capturedPokemons = _service.Capture("SONENOENONENOENSNEENEESESNOSSEEESNOSEESOEENSSONENOENONENOENSNEENEESESNOSSEEESNOSEESOEENS");

            Assert.AreEqual(capturedPokemons, expectedResult);
        }
    }
}
