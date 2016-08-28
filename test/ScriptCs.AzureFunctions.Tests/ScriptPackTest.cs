using System.Collections.Generic;

using Aliencube.ScriptCs.AzureFunctions.Tests.Fixtures;

using FluentAssertions;

using ScriptCs.Contracts;

using Xunit;

namespace Aliencube.ScriptCs.AzureFunctions.Tests
{
    /// <summary>
    /// This represents the test entity for the <see cref="ScriptPack"/> class.
    /// </summary>
    public class ScriptPackTest : IClassFixture<ScriptPackFixture>
    {
        private readonly IScriptPack _scriptPack;
        private readonly IEnumerable<IScriptPack> _scriptPacks;
        private readonly IScriptPackSession _scriptPackSession;

        /// <summary>
        /// Initialises a new instance of the <see cref="ScriptPackTest"/> class.
        /// </summary>
        /// <param name="fixture"><see cref="ScriptPackFixture"/> instance.</param>
        public ScriptPackTest(ScriptPackFixture fixture)
        {
            this._scriptPack = fixture.ScriptPack;
            this._scriptPacks = fixture.ScriptPacks;
            this._scriptPackSession = fixture.ScriptPackSession;
        }

        /// <summary>
        /// Tests whether the method should return result or not.
        /// </summary>
        [Fact]
        public void Given_NameSpacesAndAssemblies_Initialize_ShouldReturn_Result()
        {
            this._scriptPack.Initialize(this._scriptPackSession);

            var session = this._scriptPackSession as ScriptPackSession;

            var references = session.References;
            references.Should().HaveCount(ScriptPack.References.Count);

            var namespaces = session.Namespaces;
            namespaces.Should().HaveCount(ScriptPack.Namespaces.Count + 1);
        }
    }
}
