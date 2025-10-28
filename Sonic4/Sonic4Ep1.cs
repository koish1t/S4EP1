// Decompiled with JetBrains decompiler
// Type: Sonic4Ep1
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using mpp;
using System;

public class Sonic4Ep1 : Game
{
  public static Sonic4Ep1 pInstance;
  private GraphicsDeviceManager graphics;
  private SpriteFont fntKootenay;
  public SpriteFont[] fnts = new SpriteFont[3];
  private int GCCount;
  private WeakReference wr = new WeakReference(new object());
  private double _lastUpdateMilliseconds;
  public static bool cheat = false;
  public RasterizerState scissorState;
  //private Accelerometer accelerometer;
  private AppMain appMain;
  public SpriteBatch spriteBatch;
  protected float deviceMusicVolume;
  protected bool storeSystemVolume = true;
  private Vector3 accel;
  private static bool inputDataRead = true;

  public Sonic4Ep1()
  {
    Sonic4Ep1.pInstance = this;
    this.graphics = new GraphicsDeviceManager((Game) this);
    this.graphics.PreferredBackBufferWidth = 480;
    this.graphics.PreferredBackBufferHeight = 288;
    this.graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft;
    this.graphics.PreparingDeviceSettings += new EventHandler<PreparingDeviceSettingsEventArgs>(this.graphics_PreparingDeviceSettings);
    this.graphics.SynchronizeWithVerticalRetrace = true;
    this.graphics.IsFullScreen = true;
    this.IsMouseVisible = true;
    this.Content.RootDirectory = "Content";
    this.TargetElapsedTime = TimeSpan.FromTicks(333333L);
    //this.Activated += new EventHandler<EventArgs>(((Game) this).OnActivated);
    //this.Deactivated += new EventHandler<EventArgs>(((Game) this).OnDeactivated);
  }

  private void graphics_PreparingDeviceSettings(object sender, PreparingDeviceSettingsEventArgs e)
  {
    PresentationParameters presentationParameters = e.GraphicsDeviceInformation.PresentationParameters;
  }

  protected override void Initialize()
  {
    this.scissorState = new RasterizerState()
    {
      ScissorTestEnable = true,
      CullMode = CullMode.None
    };
    Guide.IsScreenSaverEnabled = false;
    LiveFeature.GAME = this;
    LiveFeature.getInstance();
    base.Initialize();
  }

  protected override void LoadContent()
  {
    this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
    this.fntKootenay = this.Content.Load<SpriteFont>("Kootenay");
    this.fnts[0] = this.Content.Load<SpriteFont>("small");
    this.fnts[1] = this.Content.Load<SpriteFont>("medium");
    this.fnts[2] = this.Content.Load<SpriteFont>("large");
    try
    {
      this.appMain = new AppMain((Game) this, this.graphics, this.GraphicsDevice);
      this.appMain.AppInit("");
            /*
      if (this.accelerometer == null)
        this.accelerometer = new Accelerometer();
      this.accelerometer.ReadingChanged += new EventHandler<AccelerometerReadingEventArgs>(this.accelerometer_ReadingChanged);
      try
      {
        this.accelerometer.Start();
      }
      catch (AccelerometerFailedException ex)
      {
      }
            */
    }
    catch (Exception ex)
    {
    }
  }

  protected override void OnDeactivated(object sender, EventArgs args)
  {
    AppMain.isForeground = false;
    if (SaveState.saveLater)
      SaveState._saveFile((object) SaveState.save);
    if (!Guide.IsVisible)
    {
      this.storeSystemVolume = true;
      try
      {
        if (!AppMain.g_ao_sys_global.is_playing_device_bgm_music)
          MediaPlayer.Pause();
        MediaPlayer.Volume = this.deviceMusicVolume;
      }
      catch (Exception ex)
      {
      }
    }
    else
      this.storeSystemVolume = false;
  }

  protected override void OnActivated(object sender, EventArgs args)
  {
    AppMain.isForeground = true;
    if (this.storeSystemVolume)
      this.deviceMusicVolume = MediaPlayer.Volume;
    if (((int) AppMain.g_gm_main_system.game_flag & 64 /*0x40*/) != 0)
      return;
    AppMain.g_pause_flag = true;
  }

    /*
  private void accelerometer_ReadingChanged(object sender, AccelerometerReadingEventArgs e)
  {
    this.accel.X = (float) e.X;
    this.accel.Y = (float) e.Y;
    this.accel.Z = (float) e.Z;
  }
    */

  protected override void UnloadContent()
  {
  }

  protected override void Update(GameTime gameTime)
  {
    AppMain.lastGameTime = gameTime;
    if (!AppMain.g_ao_sys_global.is_show_ui)
    {
      if (Sonic4Ep1.inputDataRead)
      {
        Sonic4Ep1.inputDataRead = false;
        if (!LiveFeature.getInstance().InputOverride() && !Upsell.inputUpsellScreen())
          AppMain.onTouchEvents();
        AppMain.amIPhoneAccelerate(ref this.accel);
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
          AppMain.back_key_is_pressed = true;
      }
    }
    try
    {
      base.Update(gameTime);
    }
    catch (GameUpdateRequiredException ex)
    {
      XBOXLive.HandleGameUpdateRequired(ex);
    }
  }

  protected override void Draw(GameTime gameTime)
  {
    Sonic4Ep1.inputDataRead = true;
    OpenGL.drawPrimitives_Count = 0;
    OpenGL.drawVertexBuffer_Count = 0;
    this.appMain.AppMainLoop();
    this.spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.Opaque);
    this.spriteBatch.End();
    LiveFeature.getInstance().ShowOverride();
    Upsell.drawUpsellScreen();
    base.Draw(gameTime);
  }
}
