﻿// Decompiled with JetBrains decompiler
// Type: GLBlendIdxData
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

using Microsoft.Xna.Framework.Graphics.PackedVector;
using mpp;
using System;

#nullable disable
public class GLBlendIdxData : OpenGL.GLVertexData
{
  protected readonly Byte4[] data_;
  protected OpenGL.GLVertexElementType[] compType_ = new OpenGL.GLVertexElementType[1]
  {
    OpenGL.GLVertexElementType.BlendIndex
  };

  public GLBlendIdxData(ByteBuffer buffer, int size, uint type, int stride, int elCount)
  {
    stride = stride == 0 ? OpenGL.SizeOf(type) * size : stride;
    this.data_ = new Byte4[elCount];
    int i = 0;
    for (int index = 0; index < elCount; ++index)
    {
      byte x = buffer[i];
      byte y = size > 1 ? buffer[i + 1] : (byte) 0;
      byte z = size > 2 ? buffer[i + 2] : (byte) 0;
      byte w = size > 3 ? buffer[i + 3] : (byte) 0;
      this.data_[index] = new Byte4((float) x, (float) y, (float) z, (float) w);
      i += stride;
    }
  }

  public OpenGL.GLVertexElementType[] DataComponents => this.compType_;

  public int VertexCount => this.data_.Length;

  public void ExtractTo(OpenGL.Vertex[] dst, int count)
  {
    for (int index = 0; index < count; ++index)
      dst[index].BlendIndices = this.data_[index];
  }

  public void ExtractTo(OpenGL.VertexPosTexColNorm[] dst, int dstOffset, int count)
  {
    throw new InvalidOperationException();
  }
}
