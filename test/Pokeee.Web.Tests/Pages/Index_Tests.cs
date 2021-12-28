using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Pokeee.Pages
{
    public class Index_Tests : PokeeeWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
