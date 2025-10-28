// Decompiled with JetBrains decompiler
// Type: er.web.erWeb
// Assembly: Sonic4 ep I, Version=1.2.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 093CE2FC-33E2-4332-B0FE-1EA1E44D3AE7
// Assembly location: C:\Users\Texture2D\Documents\WP\Sonic4 ep I.dll

using System.Diagnostics;

namespace er.web
{

    public class erWeb
    {
      public static void StartWeb(string url)
      {
        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }
        catch
        {
        }
      }
    }
}
