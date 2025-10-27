// Decompiled with JetBrains decompiler
// Type: GameFramework.GameObjectBase
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

using Microsoft.Xna.Framework;

#nullable disable
namespace GameFramework;

public abstract class GameObjectBase
{
  public GameObjectBase(Game game) => this.Game = game;

  protected Game Game { get; set; }

  public int UpdateCount { get; set; }

  public virtual void Update(GameTime gameTime) => ++this.UpdateCount;
}
