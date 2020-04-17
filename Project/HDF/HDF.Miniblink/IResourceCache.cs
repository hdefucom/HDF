
namespace HDF.Miniblink
{
    public interface IResourceCache
    {
        bool Matchs(string url);

        byte[] Get(string url);

        void Save(string url, byte[] data);
    }
}
