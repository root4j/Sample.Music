using Sample.Music.Model.Common;

namespace Sample.Music.Model.Exceptions
{
    [Serializable]
    public class UniqueKeyDuplicatedException : SystemException
    {
        public UniqueKeyDuplicatedException() : base(Constants.EXCEPTION_MESSAGEKEY_EQUALUNIQUEROW)
        {
        }
    }
}