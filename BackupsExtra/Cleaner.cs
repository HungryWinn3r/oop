using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups;

namespace BackupsExtra
{
    public class Cleaner
    {
        private TimeSpan _maxTimeInterval;
        private int _limit;

        public Cleaner(int limit, TimeSpan maxTimeInterval)
        {
            if (limit <= 0)
                throw new ArgumentException();
            _limit = limit;
            if (maxTimeInterval == TimeSpan.Zero)
                throw new ArgumentException();
            _maxTimeInterval = maxTimeInterval;
        }

        public void ChangeTime(TimeSpan newInterval)
        {
            if (newInterval == TimeSpan.Zero)
                throw new ArgumentException("ByDateCleaner MaxTimeInterval can't be == 0");
            _maxTimeInterval = newInterval;
        }

        public void ChangeLimit(int limit)
        {
            if (limit <= 0)
                throw new ArgumentException();
            _limit = limit;
        }

        public List<RestorePoint> Run(List<RestorePoint> restorePoints)
        {
            List<RestorePoint> result;
            result = restorePoints.OrderBy(point => point.DateCreation).Take(restorePoints.Count - _limit).ToList();
            result = result.Where(point => DateTime.Now - point.DateCreation > _maxTimeInterval).ToList();
            return result;
        }
    }
}