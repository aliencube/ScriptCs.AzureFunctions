using System;
using System.Collections.Generic;

using ScriptCs.Contracts;

namespace Aliencube.ScriptCs.AzureFunctions.Tests.Fixtures
{
    /// <summary>
    /// This represents the fixture entity for the <see cref="ScriptPackTest"/> class.
    /// </summary>
    public class ScriptPackFixture : IDisposable
    {
        private bool _disposed;

        /// <summary>
        /// Initialises a new instance of the <see cref="ScriptPackFixture"/> class.
        /// </summary>
        public ScriptPackFixture()
        {
            this.ScriptPack = new ScriptPack();

            this.ScriptPacks = new List<IScriptPack>() { this.ScriptPack };

            this.ScriptPackSession = new ScriptPackSession(this.ScriptPacks, null);
        }

        /// <summary>
        /// Gets the <see cref="IScriptPack"/> instance.
        /// </summary>
        public IScriptPack ScriptPack { get; }

        /// <summary>
        /// Gets the <see cref="IEnumerable{IScriptPack}"/> instance.
        /// </summary>
        public IEnumerable<IScriptPack> ScriptPacks { get; }

        /// <summary>
        /// Gets the <see cref="IScriptPackSession"/> instance.
        /// </summary>
        public IScriptPackSession ScriptPackSession { get; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}
