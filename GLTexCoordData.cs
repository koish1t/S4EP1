// Decompiled with JetBrains decompiler
// Type: GLTexCoordData
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

using Microsoft.Xna.Framework;
using mpp;

#nullable disable
public class GLTexCoordData : OpenGL.GLVertexData
{
  protected readonly Vector2[] data_;
  protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[1]
  {
    OpenGL.GLVertexElementType.TextureCoordinate0
  };

  public GLTexCoordData(ByteBuffer buffer, int size, uint type, int stride, int elCount)
  {
    stride = stride == 0 ? OpenGL.SizeOf(type) * size : stride;
    this.data_ = new Vector2[elCount];
    switch (type)
    {
      case 5121:
        this.extractByteData(buffer, stride);
        break;
      case 5123:
        this.extractUShortData(buffer, stride);
        break;
      case 5126:
        this.extractFloatData(buffer, stride);
        break;
    }
  }

  public OpenGL.GLVertexElementType[] DataComponents => this.compType_;

  public int VertexCount => this.data_.Length;

  public void ExtractTo(OpenGL.Vertex[] dst, int count)
  {
    for (int index = 0; index < count; ++index)
      dst[index].TextureCoordinate = this.data_[index];
  }

  public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
  {
    for (int index = 0; index < count; ++index)
      dst[index + dstOffset].TextureCoordinate = this.data_[index];
  }

  private void extractFloatData(ByteBuffer buffer, int stride)
  {
    int length = this.data_.Length;
    int getOffset = 0;
    for (int index = 0; index < length; ++index)
    {
      float x = buffer.GetFloat(getOffset);
      float y = buffer.GetFloat(getOffset + 4);
      this.data_[index] = new Vector2(x, y);
      getOffset += stride;
    }
  }

  private void extractUShortData(ByteBuffer buffer, int stride)
  {
    int length = this.data_.Length;
    int getOffset = 0;
    for (int index = 0; index < length; ++index)
    {
      ushort x = buffer.GetUShort(getOffset);
      ushort y = buffer.GetUShort(getOffset + 2);
      this.data_[index] = new Vector2((float) x, (float) y);
      getOffset += stride;
    }
  }

  private void extractByteData(ByteBuffer buffer, int stride)
  {
    int length = this.data_.Length;
    int i = 0;
    for (int index = 0; index < length; ++index)
    {
      byte x = buffer[i];
      byte y = buffer[i + 1];
      this.data_[index] = new Vector2((float) x, (float) y);
      i += stride;
    }
  }
}
