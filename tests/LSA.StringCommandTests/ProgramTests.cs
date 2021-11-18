using Xunit;
using LSA.StringCommand;
using System;
using System.Linq;

namespace LSA.StringCommandTests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData("-l", "HELLO WORLD!")]
        [InlineData("--lower", "HELLO WORLD!")]
        public void ShouldBeLower(string arg1, string arg2)
        {
            //arr
            var args = new string[2] { arg1, arg2 };

            //act
            var result = Program.Process(args);

            //assert
            Assert.Equal(arg2.ToLower(), result);
        }

        [Theory]
        [InlineData("-f", "HELLO WORLD!", "Hello world!")]
        [InlineData("--firstUpper", "HELLO WORLD!", "Hello world!")]
        [InlineData("--firstUpper", "hello world!", "Hello world!")]
        [InlineData("--firstUpper", "heLLo World!", "Hello world!")]
        [InlineData("--firstUpper", "Hello world!", "Hello world!")]
        [InlineData("--firstUpper", " HELLO WORLD!", "Hello world!")]
        [InlineData("--firstUpper", " HELLO WORLD! HELLO WORLD!", "Hello world! Hello world!")]
        [InlineData("--firstUpper", " HELLO WORLD. HELLO WORLD.", "Hello world. Hello world.")]
        [InlineData("--firstUpper", " HELLO WORLD? HELLO WORLD?", "Hello world? Hello world?")]
        [InlineData("--firstUpper", " HELLO WORLD... HELLO WORLD...", "Hello world... Hello world...")]
        public void ShouldBeFirstUper(string arg1, string arg2, string expected)
        {
            //arr
            var args = new string[2] { arg1, arg2 };

            //act
            var result = Program.Process(args);

            //assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("-u", "Hello world!")]
        [InlineData("-u", "hello world!")]
        [InlineData("-u", "helLO world!")]
        [InlineData("--upper", "HELLO WORLD!")]
        public void ShouldBeUpper(string arg1, string arg2)
        {
            //arr
            var args = new string[2] { arg1, arg2 };

            //act
            var result = Program.Process(args);

            //assert
            Assert.Equal(arg2.ToUpper(), result);
        }

        [Theory]
        [InlineData("-g", "")]
        [InlineData("--guid", "")]
        [InlineData("-g", "10")]
        public void ShouldBeGuid(string arg1, string arg2)
        {
            //arr
            var args = new string[2] { arg1, arg2 };

            //act
            var result = Program.Process(args);

            //assert
            if (int.TryParse(arg2, out var amount))
            {
                var guids = result.Split("\n");
                foreach (var guidIn in guids)
                {
                    Assert.True(Guid.TryParse(guidIn, out var guidOut));
                }
                Assert.Equal(amount, guids.Length);
            }
            else
            {
                Assert.True(Guid.TryParse(result, out var guidOut));
            }
        }

        [Theory]
        [InlineData("-h")]
        [InlineData("--help")]
        public void ShouldReturnHelp(string arg)
        {
            //arr
            var args = new string[1] { arg };

            //act
            var result = Program.Process(args);

            //assert
            Assert.True(!string.IsNullOrEmpty(result));
        }

        
        [Theory]
        [InlineData("-y")]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldReturnInvalidArguments(string arg)
        {
            //arr
            var args = new string[1] { arg };

            //act
            var result = Program.Process(args);

            //assert
            Assert.Contains("Invalid args", result);
        }
    }
}
