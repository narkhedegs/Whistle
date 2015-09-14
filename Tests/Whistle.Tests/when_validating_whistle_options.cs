using System;
using Narkhedegs.Diagnostics.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Diagnostics.Tests
{
    [TestFixture]
    public class when_validating_whistle_options
    {
        private WhistleOptionsValidator _whistleOptionsValidator;

        [SetUp]
        public void SetUp()
        {
            _whistleOptionsValidator = new WhistleOptionsValidator();
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_whistleOptions_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => _whistleOptionsValidator.Validate(null));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_ExecutableName_option_is_null()
        {
            Assert.Throws<ArgumentException>(
                () => _whistleOptionsValidator.Validate(WhistleOptionsGenerator.Default().WithNullExecutableName()));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_ExecutableName_option_is_empty()
        {
            Assert.Throws<ArgumentException>(
                () => _whistleOptionsValidator.Validate(WhistleOptionsGenerator.Default().WithEmptyExecutableName()));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_ExecutableName_option_is_a_non_existent_path()
        {
            Assert.Throws<ArgumentException>(
                () => _whistleOptionsValidator.Validate(WhistleOptionsGenerator.Default().WithNonExistentExecutableName()));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_WorkingDirectory_option_is_a_non_existent_path()
        {
            Assert.Throws<ArgumentException>(
                () => _whistleOptionsValidator.Validate(WhistleOptionsGenerator.Default().WithNonExistentWorkingDirectory()));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_ExitTimeout_option_is_zero()
        {
            Assert.Throws<ArgumentException>(
                () => _whistleOptionsValidator.Validate(WhistleOptionsGenerator.Default().WithExitTimeout(0)));
        }

        [Test]
        public void it_should_throw_ArgumentException_if_the_value_of_the_ExitTimeout_option_is_less_than_zero()
        {
            Assert.Throws<ArgumentException>(
                () => _whistleOptionsValidator.Validate(WhistleOptionsGenerator.Default().WithExitTimeout(-2)));
        }
    }
}
