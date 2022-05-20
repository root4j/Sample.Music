using Sample.Music.Model.Common;

namespace Sample.Music.Model.Exceptions
{
    [Serializable]
    public class ObjectNotFoundException : SystemException
    {
        public ObjectNotFoundException() : base(Constants.EXCEPTION_MESSAGEKEY_NONOBJECTFOUND)
        {
        }
    }
}