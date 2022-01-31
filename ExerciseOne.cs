using System;
using NUnit.Framework;

namespace Gb.Test.HomeWork.One
{
    public class Tests
    {
        private string _testName = "TestName";
        private string _testSurname = "TestSurname";
        private ulong _testAge = ulong.MaxValue;
        private byte _testHeight = byte.MaxValue;
        private byte _testWeight = byte.MaxValue;
        
        private string _positiveString;
        
        [SetUp]
        public void Setup()
        {
            _positiveString = $"Name: {_testName}\tSurname: {_testSurname}\tAge: {_testAge}\tHeight: {_testHeight}\tWeight: {_testWeight}";
            Assert.Pass();
        }

        [Test]
        public void PositiveStringEquals()
        {
            Gb.HomeWork.One.ExOne hm1 = new Gb.HomeWork.One.ExOne();
            Assert.Equals(hm1.getStringA(_testName, _testSurname, _testAge, _testHeight, _testWeight), _positiveString);
        }
    }
}