using System.Collections.Generic;
using System.IO;
using System.Linq;
using Backups;

namespace BackupsExtra.DeleterAlgorithm
{
    public class Merge
    {
        public void Run(List<RestorePoint> restorePoints, List<RestorePoint> restorePointsToRemove, string storage)
        {
            string startDir = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(storage);
            RestorePoint newRestorePoint = restorePoints.Except(restorePointsToRemove).First();
            foreach (RestorePoint oldRestorePoint in restorePointsToRemove)
            {
                foreach (string jobObject in oldRestorePoint.Files)
                {
                    if (newRestorePoint.Files.Exists(jobObject1 => jobObject1 == jobObject)) continue;
                    File.Copy($"./{oldRestorePoint.Name}/{jobObject}", $"./{newRestorePoint.Name}/{jobObject}");
                    newRestorePoint.Files.Add(jobObject);
                }

                Directory.Delete($"./{oldRestorePoint.Name}", true);
                restorePoints.Remove(oldRestorePoint);
            }

            Directory.SetCurrentDirectory(startDir);
        }
    }
}