namespace Backups
{
    public class SimpleAlgorithmFactory
    {
        private IRepository _repository;

        public SimpleAlgorithmFactory(IRepository repository)
        {
            _repository = repository;
        }

        public Algorithm CreateAlgorithm(AlgorithmType type)
        {
            Algorithm algorithm = null;

            switch (type)
            {
                case AlgorithmType.SPLIT:
                    algorithm = new SplitStorageAlgorithm(_repository);
                    break;
                case AlgorithmType.SINGLE:
                    algorithm = new SingleStorageAlgorithm(_repository);
                    break;
            }

            return algorithm;
        }
    }
}
