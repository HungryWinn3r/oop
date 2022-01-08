namespace Backups
{
    public class SimpleAlgorithmFactory
    {
        private IRepository _repository;

        public SimpleAlgorithmFactory(IRepository repository)
        {
            _repository = repository;
        }

        public Algorithm CreateAlgorithm(string type)
        {
            Algorithm algorithm = null;
            type = type.ToLower();
            if (type == "split" || type == "split storages")
                algorithm = new SplitStorageAlgorithm(_repository);
            else if (type == "single" || type == "single storage")
                algorithm = new SingleStorageAlgorithm(_repository);

            return algorithm;
        }
    }
}
