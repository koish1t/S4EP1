// Decompiled with JetBrains decompiler
// Type: FloatBuffer
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

public class FloatBuffer(ByteBuffer buffer) : ByteBuffer(buffer.data, buffer.offset)
{
  public float this[int index]
  {
    get => this.GetFloat(index * 4);
    set => this.PutFloat(value, index * 4);
  }
}
