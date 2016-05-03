using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using ReactiveSearch.Core;
using Xunit;

namespace ReactiveSearch.UnitTests.Core
{
    public class BlobCacheKeysFixtures
    {

        [InlineData("hello world", "searchQuery-hello world")]
        [InlineData("hello", "searchQuery-hello")]
        [InlineData("", "searchQuery-")]
        [Theory]
        public void SearchQueryKeyShouldBeExpected(string query, string expected)
        {
            var sut = BlobCacheKeys.GetKeyForSearch(query);

            sut.Should().Be(expected);
        }
    }
}
