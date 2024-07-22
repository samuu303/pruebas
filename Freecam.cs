using System;
using GTA;
using GTA.Math;
using GTA.Native;

namespace AmazingScreenshot
{
	// Token: 0x02000003 RID: 3
	public class Freecam : Script
	{
		// Token: 0x06000004 RID: 4 RVA: 0x0000265F File Offset: 0x0000085F
		public Freecam()
		{
			base.Tick += this.OnTick;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x0000267C File Offset: 0x0000087C
		private void OnTick(object sender, EventArgs e)
		{
			bool flag = World.RenderingCamera == Freecam.freeCam && !Main.isPaused;
			if (flag)
			{
				Function.Call(3824154378443735381L, new InputArgument[]
				{
					0,
					1
				});
				Function.Call(3824154378443735381L, new InputArgument[]
				{
					0,
					2
				});
				Function.Call(3824154378443735381L, new InputArgument[]
				{
					0,
					239
				});
				Function.Call(3824154378443735381L, new InputArgument[]
				{
					0,
					240
				});
				Function.Call(3824154378443735381L, new InputArgument[]
				{
					0,
					200
				});
				Function.Call(3824154378443735381L, new InputArgument[]
				{
					0,
					15
				});
				Function.Call(3824154378443735381L, new InputArgument[]
				{
					0,
					14
				});
				float num = Function.Call<float>(-1424092350868114077L, new InputArgument[]
				{
					0,
					1
				});
				float num2 = Function.Call<float>(-1424092350868114077L, new InputArgument[]
				{
					0,
					2
				});
				Freecam.freeCam.Rotation = Freecam.freeCam.Rotation + new Vector3(num2 * -10f, 0f, num * -10f);
				bool flag2 = Freecam.freeCam.Rotation.X < -90f;
				if (flag2)
				{
					Freecam.freeCam.Rotation = Freecam.freeCam.Rotation + new Vector3(1f, 0f, 0f);
				}
				bool flag3 = Freecam.freeCam.Rotation.X > 90f;
				if (flag3)
				{
					Freecam.freeCam.Rotation = Freecam.freeCam.Rotation + new Vector3(-1f, 0f, 0f);
				}
				float num3 = 0.25f;
				bool flag4 = Game.IsControlPressed(2, 21);
				if (flag4)
				{
					num3 = 1f;
				}
				Vector3 vector = Freecam.freeCam.Position;
				Vector3 vector2 = Freecam.RotationToDirection(Freecam.freeCam.Rotation);
				float z = Freecam.freeCam.Position.Z;
				Vector3 rotation = Freecam.freeCam.Rotation + new Vector3(0f, 0f, -10f);
				Vector3 rotation2 = Freecam.freeCam.Rotation + new Vector3(0f, 0f, 10f);
				Vector3 vector3 = Freecam.RotationToDirection(rotation2) - Freecam.RotationToDirection(rotation);
				bool flag5 = Game.IsControlPressed(0, 32);
				if (flag5)
				{
					vector += vector2 * num3;
				}
				bool flag6 = Game.IsControlPressed(0, 33);
				if (flag6)
				{
					vector -= vector2 * num3;
				}
				bool flag7 = Game.IsControlPressed(0, 34);
				if (flag7)
				{
					vector += vector3 * (num3 * 2f);
				}
				bool flag8 = Game.IsControlPressed(0, 35);
				if (flag8)
				{
					vector -= vector3 * (num3 * 2f);
				}
				bool flag9 = Game.IsControlPressed(0, 174);
				if (flag9)
				{
					Freecam.freeCam.Rotation -= new Vector3(0f, 0.5f, 0f);
				}
				bool flag10 = Game.IsControlPressed(0, 175);
				if (flag10)
				{
					Freecam.freeCam.Rotation += new Vector3(0f, 0.5f, 0f);
				}
				bool flag11 = Game.IsControlPressed(0, 172);
				if (flag11)
				{
					Freecam.freeCam.FieldOfView -= 0.5f;
				}
				bool flag12 = Game.IsControlPressed(0, 173);
				if (flag12)
				{
					Freecam.freeCam.FieldOfView += 0.5f;
				}
				bool flag13 = Game.IsControlJustPressed(0, 45);
				if (flag13)
				{
					Freecam.freeCam.FieldOfView = 50f;
					Freecam.freeCam.Rotation = GameplayCamera.Rotation;
					Freecam.freeCam.Position = GameplayCamera.Position;
				}
				Freecam.freeCam.Position = vector;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002B34 File Offset: 0x00000D34
		public static Vector3 GetRaycastCoords()
		{
			return World.Raycast(Freecam.freeCam.Position, Freecam.freeCam.Direction, 1000f, -1, Game.Player.Character).HitCoords;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002B78 File Offset: 0x00000D78
		public static bool IsEnabled()
		{
			bool flag = Freecam.freeCam != null;
			return flag && Freecam.freeCam.IsActive;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002BA8 File Offset: 0x00000DA8
		public static void Toggle()
		{
			bool flag = Freecam.IsEnabled();
			if (flag)
			{
				Freecam.Disable();
			}
			else
			{
				Freecam.Enable();
			}
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002BD1 File Offset: 0x00000DD1
		public static void Enable()
		{
			Freecam.freeCam = World.CreateCamera(GameplayCamera.Position, GameplayCamera.Rotation, 50f);
			World.RenderingCamera = Freecam.freeCam;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002BF8 File Offset: 0x00000DF8
		public static void Disable()
		{
			Freecam.freeCam.Destroy();
			World.RenderingCamera = null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002C10 File Offset: 0x00000E10
		private static double DegToRad(double deg)
		{
			return deg * 3.141592653589793 / 180.0;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002C38 File Offset: 0x00000E38
		private static Vector3 RotationToDirection(Vector3 rotation)
		{
			double num = Freecam.DegToRad((double)rotation.Z);
			double num2 = Freecam.DegToRad((double)rotation.X);
			double num3 = Math.Abs(Math.Cos(num2));
			Vector3 result = default(Vector3);
			result.X = (float)(-(float)Math.Sin(num) * num3);
			result.Y = (float)(Math.Cos(num) * num3);
			result.Z = (float)Math.Sin(num2);
			return result;
		}

		// Token: 0x04000004 RID: 4
		private static Camera freeCam;
	}
}
