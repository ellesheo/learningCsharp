namespace CP26_ogranicheniya_class_struct
{
    public class ReferenceCache<T> where T : class
    {
        private T? stored;

        public void Put(T item) => stored = item;

        public bool TryGet(out T? value)
        {
            value = stored;
            return stored is not null;
        }
    }

    public class ValueCache<T> where T : struct
    {
        private T? stored;

        public void Put(T item) => stored = item;

        public bool TryGet(out T? value)
        {
            value = stored;
            return stored.HasValue;
        }
    }
}