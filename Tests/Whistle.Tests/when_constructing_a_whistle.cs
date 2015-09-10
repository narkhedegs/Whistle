using System;
using Moq;
using Narkhedegs.Diagnostics.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Diagnostics.Tests
{
    [TestFixture]
    public class when_constructing_a_whistle
    {
        private WhistleOptions _whistleOptions;
        private Mock<IWhistleOptionsValidator> _whistleOptionsValidator;
        private Mock<IProcessStartInformationBuilder> _processStartInformationBuilder;

        [SetUp]
        public void SetUp()
        {
            _whistleOptions = WhistleOptionsGenerator.Default();
            _whistleOptionsValidator = new Mock<IWhistleOptionsValidator>();
            _processStartInformationBuilder = new Mock<IProcessStartInformationBuilder>();
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_whistleOptionsValidator_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Whistle(_whistleOptions, null,
                _processStartInformationBuilder.Object));
        }

        [Test]
        public void it_should_throw_ArgumentNullException_if_processStartInformationBuilder_parameter_is_null()
        {
            Assert.Throws<ArgumentNullException>(() => new Whistle(_whistleOptions, _whistleOptionsValidator.Object,
                null));
        }
    }
}
