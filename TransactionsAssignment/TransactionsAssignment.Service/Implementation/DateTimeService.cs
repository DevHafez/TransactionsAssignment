using System;
using TransactionsAssignment.Service.Contract;

namespace TransactionsAssignment.Service.Implementation
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}