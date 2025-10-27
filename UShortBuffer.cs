// Decompiled with JetBrains decompiler
// Type: UShortBuffer
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

public class UShortBuffer(ByteBuffer buffer) : ByteBuffer(buffer.data, buffer.offset)
{
  public ushort this[int index]
  {
    get => this.GetUShort(index * 2);
    set => this.PutUShort(value, index * 2);
  }
}
