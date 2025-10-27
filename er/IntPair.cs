// Decompiled with JetBrains decompiler
// Type: er.IntPair
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

namespace er
{

    public struct IntPair(int _first, int _second)
    {
      public int first = _first;
      public int second = _second;

      public static IntPair operator -(IntPair lhs, IntPair rhs)
      {
        return new IntPair(lhs.first - rhs.first, lhs.second - rhs.second);
      }

      public static IntPair operator +(IntPair lhs, IntPair rhs)
      {
        return new IntPair(lhs.first + rhs.first, lhs.second + rhs.second);
      }
    }
}
