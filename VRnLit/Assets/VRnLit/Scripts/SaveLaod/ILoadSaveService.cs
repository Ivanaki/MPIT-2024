using R3;

namespace PogruzhickURP.Scripts.SaveLaod
{
    public interface ILoadSaveService
    {
        public Observable<bool> Save(string key, object data);
        public Observable<LoadCallback> Load<T>(string key);
        public Observable<bool> Delete(string key);
    }
}