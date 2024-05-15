namespace Tests
{
    using FluentAssertions;
    using ElementalWords = Kata.ElementalWords;

    public class ElementalWordsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void ElementalForms_ReturnsEmptyCollection_WhenNoWordProvided(string word)
        {
            var results = ElementalWords.ElementalForms(word);

            results.Should().BeEmpty();
        }

        [Theory]
        [InlineData("X")]
        [InlineData("Odd")]
        public void ElementalForms_ReturnsEmptyCollection_WhenFullWordCannotBeConverted(string word)
        {
            var results = ElementalWords.ElementalForms(word);

            results.Should().BeEmpty();
        }

        [Fact]
        public void ElementalForms_ReturnsFormattedElements_WhenFullWordCanBeConverted()
        {
            var word = "this";
            var results = ElementalWords.ElementalForms(word);

            var expectedResult = new string[][]
            {
                new[] { "Thorium (Th)", "Iodine (I)", "Sulfur (S)" }
            };

            results.Should().BeEquivalentTo(expectedResult);
        }

        [Theory]
        [InlineData("Na")]
        [InlineData("NA")]
        [InlineData("na")]
        [InlineData("nA")]
        public void ElementalForms_ReturnsTheSame_IrrespectiveOfCase(string word)
        {
            var results = ElementalWords.ElementalForms(word);

            var expectedResult = new string[][]
            {
                new[] { "Sodium (Na)" }
            };

            results.Should().BeEquivalentTo(expectedResult);
        }

        [Fact]
        public void ElementalForms_AccommodatesMultipleCombinations()
        {
            var word = "score";
            var results = ElementalWords.ElementalForms(word);

            var expectedResult = new string[][]
            {
                new[] { "Sulfur (S)", "Carbon (C)", "Oxygen (O)", "Rhenium (Re)" },
                new[] { "Sulfur (S)", "Cobalt (Co)", "Rhenium (Re)" },
                new[] { "Scandium (Sc)", "Oxygen (O)", "Rhenium (Re)" }
            };

            results.Should().BeEquivalentTo(expectedResult);
        }
    }
}