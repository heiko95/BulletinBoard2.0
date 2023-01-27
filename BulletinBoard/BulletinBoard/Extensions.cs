namespace BulletinBoard
{
    public static class Extensions
    {
        #region Public Methods

        public static void AddIfNotNull<T>(this List<T> list, T? element)
        {
            if (element != null) list.Add(element);
        }

        #endregion Public Methods
    }
}