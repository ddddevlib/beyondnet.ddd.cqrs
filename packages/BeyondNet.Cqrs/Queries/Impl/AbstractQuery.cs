using BeyondNet.Cqrs.Core.Impl;
using BeyondNet.Cqrs.Models;
using BeyondNet.Cqrs.Queries.Interfaces;

namespace BeyondNet.Cqrs.Queries.Impl
{
    public abstract class AbstractQuery : AbstractMessage, IQuery<ResultSet>
    {
        public DateTime SentAt { get; private set; }

        protected AbstractQuery()
        {
            SentAt = DateTime.Now;
        }

    }
}
