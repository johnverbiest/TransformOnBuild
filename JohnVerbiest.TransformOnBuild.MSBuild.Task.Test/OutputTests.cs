using FluentAssertions;
using JohnVerbiest.TransformOnBuild.MSBuild.Task.Test.TextTemplate1;
using Xunit;
using Xunit.Abstractions;

namespace JohnVerbiest.TransformOnBuild.MSBuild.Task.Test
{
    public class OutputTests
    {
        private readonly ITestOutputHelper _output;

        public OutputTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void MSBuildTask_OnBuild_ShouldTransformTextTemplate1_FooTest()
        {

            // Arrange
            // Done during build

            // Act
            var foo = Output.TestFoo;

            // Log
            _output.WriteLine($"Foo Test result: {foo}");

            // Assert
            foo.Should().Be("bar");
        }

        [Fact]
        public void MSBuildTask_OnBuild_ShouldTransformTextTemplate1_ConfigTest()
        {

            // Arrange
            // Done during build

            // Act
            var config = Output.TestConfig;

            // Log
            _output.WriteLine($"Config Test result: {config}");

            // Assert
            config.Should().NotBe("");

        }
    }
}
