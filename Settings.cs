using System;
using System.Windows.Forms;
using GTA;

namespace AmazingScreenshot
{
	// Token: 0x02000004 RID: 4
	public class Settings : Script
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002CAA File Offset: 0x00000EAA
		public Settings()
		{
			this.iniFile = ScriptSettings.Load("scripts\\IngameScreenshot.ini");
			Settings.toggleKey = this.iniFile.GetValue<Keys>("Keys", "toggle_key", Keys.J);
		}

		// Token: 0x04000005 RID: 5
		private ScriptSettings iniFile;

		// Token: 0x04000006 RID: 6
		public static Keys toggleKey;
	}
}
