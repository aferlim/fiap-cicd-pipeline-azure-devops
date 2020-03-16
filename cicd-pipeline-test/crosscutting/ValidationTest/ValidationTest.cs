using crosscutting.validation;
using NUnit.Framework;

namespace cicd_pipeline_test
{
    public class ValidationTest
    {
        [SetUp]
        public void Setup() { }

        [Test]
        public void Should_NotBe_A_Valid_Validation()
        {

            var validation = new ValidationResult();
            validation.AddError("error");

            Assert.False(validation.Valid, "false");
        }

        [Test]
        public void Should_Be_A_Valid_Validation()
        {

            Assert.True(new ValidationResult().Valid, "true");
        }
    }
}