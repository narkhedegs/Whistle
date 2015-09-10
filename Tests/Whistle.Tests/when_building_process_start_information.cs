using System;
using System.Collections.Generic;
using System.Linq;
using Narkhedegs.Diagnostics.Tests.Helpers;
using NUnit.Framework;

namespace Narkhedegs.Diagnostics.Tests
{
    [TestFixture]
    public class when_building_process_start_information
    {
        private ProcessStartInformationBuilder _processStartInformationBuilder;

        [SetUp]
        public void SetUp()
        {
            _processStartInformationBuilder = new ProcessStartInformationBuilder();
        }

        [Test]
        public void it_should_set_UseShellExecute_property_to_false()
        {
            var whistleOptions = WhistleOptionsGenerator.Default();

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions);

            Assert.AreEqual(false, processStartInformation.UseShellExecute);
        }

        [Test]
        public void it_should_set_RedirectStandardError_property_to_true()
        {
            var whistleOptions = WhistleOptionsGenerator.Default();

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions);

            Assert.AreEqual(true, processStartInformation.RedirectStandardError);
        }

        [Test]
        public void it_should_set_RedirectStandardInput_property_to_true()
        {
            var whistleOptions = WhistleOptionsGenerator.Default();

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions);

            Assert.AreEqual(true, processStartInformation.RedirectStandardInput);
        }

        [Test]
        public void it_should_set_RedirectStandardOutput_property_to_true()
        {
            var whistleOptions = WhistleOptionsGenerator.Default();

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions);

            Assert.AreEqual(true, processStartInformation.RedirectStandardOutput);
        }

        [Test]
        public void it_should_populate_FileName_property_with_the_value_of_ExecutableName_whistle_option()
        {
            var whistleOptions = WhistleOptionsGenerator.Default().WithExecutableName("TestApp.exe");

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions);

            Assert.AreEqual(whistleOptions.ExecutableName, processStartInformation.FileName);
        }

        [Test]
        public void it_should_populate_WorkingDirectory_property_with_the_value_of_WorkingDirectory_whistle_option()
        {
            var whistleOptions = WhistleOptionsGenerator.Default().WithWorkingDirectory("/TestDirectory");

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions);

            Assert.AreEqual(whistleOptions.WorkingDirectory, processStartInformation.WorkingDirectory);
        }

        [Test]
        public void it_should_populate_Arguments_property_with_the_value_of_Arguments_whistle_option()
        {
            var whistleOptions =
                WhistleOptionsGenerator.Default().WithArguments(new List<string> {"http://www.google.com/", "-t 1000"});

            var expected = "http://www.google.com/ -t 1000";

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions);

            Assert.AreEqual(expected, processStartInformation.Arguments);
        }

        [Test]
        public void it_should_append_the_value_of_arguments_parameter_to_Arguments_property()
        {
            var whistleOptions =
                WhistleOptionsGenerator.Default().WithArguments(new List<string> {"http://www.google.com/", "-t 1000"});
            var extraArguments = new List<string> { "-c true", "-f sample.png" };

            var expected = "http://www.google.com/ -t 1000 -c true -f sample.png";

            var processStartInformation = _processStartInformationBuilder.Build(whistleOptions, extraArguments);

            Assert.AreEqual(expected, processStartInformation.Arguments);
        }
    }
}
