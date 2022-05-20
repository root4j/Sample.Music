using Sample.Music.Model.Common;

namespace Sample.Music.Model.Exceptions
{
    [Serializable]
    public class ObjectsAreNotEqualException : SystemException
    {
        public ObjectsAreNotEqualException() : base(Constants.EXCEPTION_MESSAGEKEY_NONEQUALOBJECT)
        {
        }
    }
}