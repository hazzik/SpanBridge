# SpanBridge

A compatibility level to bring .NET Core 2.1 `Span<>` APIs to .NET Standard 2.0 world.

Currently supported methods:

## System.Text.StringBuilder

- StringBuilder.Append(ReadOnlySpan<char> value)
- StringBuilder.Insert(int index, ReadOnlySpan<char> value)
- StringBuilder.Equals(ReadOnlySpan<char> span)
