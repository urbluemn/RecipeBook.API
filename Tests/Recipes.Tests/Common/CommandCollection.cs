using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recipes.Tests.Common
{
    [CollectionDefinition("CommandCollection")]
    public class CommandCollection : ICollectionFixture<CommandTestFixture> { }
}