using System;
using System.Windows.Forms;
using GTA;
using GTA.Native;

namespace AmazingScreenshot
{
	// Token: 0x02000002 RID: 2
	public class Main : Script
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Main()
		{
			base.Tick += this.OnTick;
			base.KeyDown += this.OnKeyDown;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002088 File Offset: 0x00000288
		private void OnTick(object sender, EventArgs e)
		{
			bool flag = Freecam.IsEnabled();
			if (flag)
			{
				Function.Call(6866697718202259867L, new InputArgument[]
				{
					0
				});
				Function.Call(8187532053442985248L, new InputArgument[0]);
				bool flag2 = this.isHud;
				if (flag2)
				{
					Scaleform scaleform = new Scaleform("instructional_buttons");
					scaleform.CallFunction("CLEAR_ALL", new object[0]);
					scaleform.CallFunction("TOGGLE_MOUSE_BUTTONS", new object[]
					{
						0
					});
					scaleform.CallFunction("CREATE_CONTAINER", new object[0]);
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						0,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							30,
							0
						}),
						""
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						1,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							31,
							0
						}),
						"Move"
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						2,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							1,
							0
						}),
						"Rotate"
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						3,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							74,
							0
						}),
						"Toggle HUD"
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						4,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							22,
							0
						}),
						"Toggle Pause"
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						5,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							58,
							0
						}),
						"Toggle Slowmotion"
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						6,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							175,
							0
						}),
						""
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						7,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							174,
							0
						}),
						"Roll"
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						8,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							173,
							0
						}),
						""
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						9,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							172,
							0
						}),
						"Zoom"
					});
					scaleform.CallFunction("SET_DATA_SLOT", new object[]
					{
						10,
						Function.Call<string>(331533201183454215L, new InputArgument[]
						{
							2,
							45,
							0
						}),
						"Reset"
					});
					scaleform.CallFunction("DRAW_INSTRUCTIONAL_BUTTONS", new object[]
					{
						-1
					});
					Function.Call(1005998793517194209L, new InputArgument[]
					{
						scaleform.Handle,
						255,
						255,
						255,
						255,
						0
					});
				}
				bool flag3 = Game.IsControlJustPressed(0, 74);
				if (flag3)
				{
					this.isHud = !this.isHud;
				}
				bool flag4 = Game.IsControlJustPressed(0, 22);
				if (flag4)
				{
					Main.isPaused = !Main.isPaused;
					Game.Pause(Main.isPaused);
				}
				bool flag5 = Game.IsControlJustPressed(0, 58);
				if (flag5)
				{
					this.isSlowMotion = !this.isSlowMotion;
					bool flag6 = this.isSlowMotion;
					if (flag6)
					{
						Game.TimeScale = 1f;
					}
					else
					{
						Game.TimeScale = 0f;
					}
				}
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000025F8 File Offset: 0x000007F8
		private void OnKeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Settings.toggleKey;
			if (flag)
			{
				Freecam.Toggle();
				bool flag2 = Freecam.IsEnabled();
				if (flag2)
				{
					Game.TimeScale = 0f;
				}
				else
				{
					this.isHud = true;
					Main.isPaused = false;
					this.isSlowMotion = true;
					Game.Pause(false);
					Game.TimeScale = 1f;
				}
			}
		}

		// Token: 0x04000001 RID: 1
		private bool isHud = true;

		// Token: 0x04000002 RID: 2
		public static bool isPaused;

		// Token: 0x04000003 RID: 3
		private bool isSlowMotion;
	}
}
