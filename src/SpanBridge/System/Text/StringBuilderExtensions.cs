#if !NETCOREAPP2_1
using System.Runtime.InteropServices;

namespace System.Text
{
    public static class StringBuilderExtensions
    {
        public static unsafe StringBuilder Append(this StringBuilder @this, ReadOnlySpan<char> value)
        {
            if (value.Length > 0)
            {
                fixed (char* c = &MemoryMarshal.GetReference(value))
                {
                    @this.Append(c, value.Length);
                }
            }

            return @this;
        }

        public static unsafe StringBuilder Insert(this StringBuilder @this, int index, ReadOnlySpan<char> value)
        {
            if (index > @this.Length)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (value.Length > 0)
            {
                fixed (char* c = &MemoryMarshal.GetReference(value))
                {
                    @this.Insert(index, new string(c, 0, value.Length));
                }
            }

            return @this;
        }

        public static bool Equals(this StringBuilder @this, ReadOnlySpan<char> span)
        {
            if (span.Length != @this.Length)
                return false;

            return span.Equals(@this.ToString().AsSpan(), StringComparison.Ordinal);
        }
    }
}
#endif

