using System;

namespace Foundation.Helpers
{
    public static class EnumExtensions
    {
        public static string GetName(this Enum context)
        {
            return Enum.GetName(typeof(Enum), context);
        }

    }
}
