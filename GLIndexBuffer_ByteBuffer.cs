// Decompiled with JetBrains decompiler
// Type: GLIndexBuffer_ByteBuffer
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

using mpp;

#nullable disable
public struct GLIndexBuffer_ByteBuffer(ByteBuffer data, int dataSize) : OpenGL.GLIndexBuffer
{
  private ByteBuffer data_ = data;
  private int dataSize_ = dataSize;

  public int Size => this.dataSize_ / 2;

  public void ExtractTo(ushort[] dst)
  {
    int index = 0;
    for (int getOffset = 0; getOffset < this.dataSize_; getOffset += 2)
    {
      dst[index] = this.data_.GetUShort(getOffset);
      ++index;
    }
  }
}
