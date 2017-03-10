using System;
using System.Net;

namespace NetKegg {

    public abstract class KeggDb: IDisposable {

        protected WebClient _web = new WebClient();
        protected static string _keggHostName = "rest.kegg.jp";
        public string HostName => _keggHostName;

        #region KEGG Members

        /// <summary>
        /// Displays the current statistics of the given database.
        /// </summary>
        /// <returns></returns>
        public abstract string GetInfo();
        /// <summary>
        /// Returns a list of entry identifiers and associated definition for a given database or a given set of database entries.
        /// </summary>
        /// <returns></returns>
        public abstract string List();
        /// <summary>
        /// Finds entries with matching query keywords or other query data in a given database.
        /// </summary>
        /// <returns></returns>
        public abstract string Find();
        /// <summary>
        /// Retrieves given database entries.
        /// </summary>
        /// <returns></returns>
        public abstract string Get();
        /// <summary>
        /// Convert KEGG identifiers to/from outside identifiers.
        /// </summary>
        /// <returns></returns>
        public abstract string ConvertIds();
        /// <summary>
        /// Find related entries by using database cross-references.
        /// </summary>
        /// <returns></returns>
        public abstract string LinkDbs();

        /// <summary>
        /// Displays the current statistics of the given database.  This method does not block the calling thread.
        /// </summary>
        /// <returns></returns>
        public abstract string GetInfoAsync();
        /// <summary>
        /// Returns a list of entry identifiers and associated definition for a given database or a given set of database entries.
        /// </summary>
        /// <returns></returns>
        public abstract string ListAsync();
        /// <summary>
        /// Finds entries with matching query keywords or other query data in a given database.  This method does not block the calling thread.
        /// </summary>
        /// <returns></returns>
        public abstract string FindAsync();
        /// <summary>
        /// Retrieves given database entries.  This method does not block the calling thread.
        /// </summary>
        /// <returns></returns>
        public abstract string GetAsync();
        /// <summary>
        /// Convert KEGG identifiers to/from outside identifiers.  This method does not block the calling thread.
        /// </summary>
        /// <returns></returns>
        public abstract string ConvertIdsAsync();
        /// <summary>
        /// Find related entries by using database cross-references.  This method does not block the calling thread.
        /// </summary>
        /// <returns></returns>
        public abstract string LinkDbsAsync();

        #endregion

        #region Dispose Members

        private bool _disposed = false;

        public bool IsDisposed => _disposed;
        public void Dispose() {
            if (_disposed)
                return;

            doDispose(true);
            GC.SuppressFinalize(this);
        }

        private void doDispose(bool safeToDispose) {
            _disposed = true;

            // Dispose of managed resources, if it is safe to do so
            if (safeToDispose) {
                _web.Dispose();
            }

            // Dispose of unmanaged resources...
        }
        ~KeggDb() {
            doDispose(false);
        }

        #endregion

    }

}
