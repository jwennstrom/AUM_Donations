using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AUM.Core.Data;
using NHibernate;

namespace AUM.Data
{
    public class NHibernateUnitOfWork : IUnitOfWork, IDisposable
    {
        #region Fields

        private bool _disposed;
        private ISession _session;
        private ITransaction _transaction;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateUnitOfWork"/> class.
        /// </summary>
        public NHibernateUnitOfWork()
        {
            _session = NHibernateHelper.OpenSession();
            _transaction = _session.BeginTransaction();
        }

        #endregion Ctor

        #region Properties

        /// <summary>
        /// Gets the session.
        /// </summary>
        public ISession Session
        {
            get { return _session; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Commits the updates to the session
        /// </summary>
        public void Commit()
        {
            _transaction.Commit();
        }

        /// <summary>
        /// Reverts the updates to the session
        /// </summary>
        public void RollBack()
        {
            _transaction.Rollback();
        }

        #endregion Methods

        #region IDisposable Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        public void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    // Dispense with the transaction
                    if (_transaction != null)
                    {
                        if (_transaction.IsActive)
                        {
                            _transaction.Rollback();
                        }
                        _transaction.Dispose();
                    }
                    if (_session !=null)
                        _session.Dispose();
                }

                _session = null;
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="NHibernateUnitOfWork"/> is reclaimed by garbage collection.
        /// </summary>
        ~NHibernateUnitOfWork()
        {
            Dispose(false);
        }

        #endregion IDisposable Members
    }
}
