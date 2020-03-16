using System;
using crosscutting.validation;
using crosscutting.extension;
using NUnit.Framework;

namespace cicd_pipeline_test
{
    public class DateTimeExtensionTest
    {

        [Test]
        public void Should_Get_A_BrazilianDatetime()
        {
            Console.WriteLine(DateTime.Now.GetBrazilianDateTime());

            Assert.IsInstanceOf<DateTime>(DateTime.Now.GetBrazilianDateTime());
        }

        [Test]
        public void Should_Be_A_Valid_Validation()
        {

            Assert.True(new ValidationResult().Valid, "true");
        }
    }
}