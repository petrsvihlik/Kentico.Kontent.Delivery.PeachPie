namespace kc_peachpie_test
{
    public static class Extensions
    {
        public static object GetPropertyValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }
    }
}
