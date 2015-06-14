using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace IsartPolarium
{
	static public class AdvancedMouse
	{
		public static bool OnClicState;
		public static bool OnDragState;
		public static bool OnReleaseState;

		static public Rectangle hitBox;

		static public void Update()
		{
			hitBox.X = (int)AdvancedMouse.Position.X;
			hitBox.Y = (int)AdvancedMouse.Position.Y;

			if (Mouse.GetState ().LeftButton == ButtonState.Pressed)
			{
				if (OnClicState && !OnDragState) {
					OnClicState = false;
					OnDragState = true;
				} else if (!OnDragState)
					OnClicState = true;
			}

			if (Mouse.GetState ().LeftButton == ButtonState.Released)
			{
				if (OnClicState || OnDragState)
					OnReleaseState = true;
				else
					OnReleaseState = false;
				OnClicState = OnDragState = false;
			}
		}

		// Clic on the mouse
		static public bool OnClic()
		{
			return OnClicState;
		}

		// Is on clic
		static public bool OnDrag()
		{
			return OnDragState;
		}

		// Release Clic
		static public bool OnRelease()
		{
			return OnReleaseState;
		}

		// Give Mouse Position
		static public Vector2 Position
		{
			get { return Mouse.GetState().Position.ToVector2(); }
		}

		static public void ChangeHitBox(int w, int h)
		{
			hitBox.Width = w;
			hitBox.Height = h;
		}
	}
}

