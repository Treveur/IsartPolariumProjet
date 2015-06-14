using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace IsartPolarium
{
	public class Player : AEntity
	{
		// Etats du Sprite du Player
		public enum f_state
		{
			NONE,
			ON_DRAG_DOWN,
			ON_DRAG_UP,
			ON_DRAG_RIGHT,
			ON_DRAG_LEFT,
			ON_RELEASE_DOWN,
			ON_RELEASE_UP,
			ON_RELEASE_RIGHT,
			ON_RELEASE_LEFT
		}

		// Position du Player
		public static Vector2 activePos = new Vector2();
		public Player (AScene scene) : base(scene)
		{
		}

		//Current state of the Sprite
		public static f_state actualStateP = f_state.NONE;
		//Keeping in case of need
		//f_state saveStateP = f_state.NONE;
		//Previous state of the Sprite
		f_state previousStateP = f_state.NONE;

		public override void Initialize()
		{
			base.Initialize ();
		}

		public override void LoadContent()
		{
			LinkSprite ("Character_Front_Static");
			sprite.scale = 1f;
			sprite.position = new Vector2 (_scene.sceneManager.graphics.PreferredBackBufferWidth / 2, _scene.sceneManager.graphics.PreferredBackBufferHeight / 2);
			sprite.depth = 0f;

			base.LoadContent ();
		}

		public override void Update(GameTime gameTime)
		{
			/*if (AdvancedMouse.OnClic ())
				//sprite.color = Color.Red;
			else */

			if (AdvancedMouse.OnDrag ())
				sprite.position = new Vector2 (Mouse.GetState ().Position.X, Mouse.GetState ().Position.Y);
			else if (AdvancedMouse.OnRelease ())
				sprite.color = Color.White;
			sprite.position = activePos;

			linkPlayer ();

			base.Update (gameTime);
		}

		// Reception de GameCase Les bons états
		public static void ChangePlayerState(string s)
		{
			// Lance l'une des animations avec le Drag
			if (s == "ON_DRAG_DOWN") {
				actualStateP = f_state.ON_DRAG_DOWN;
				Console.WriteLine (f_state.ON_DRAG_DOWN);
			}
			if (s == "ON_DRAG_UP") {
				actualStateP = f_state.ON_DRAG_UP;
				Console.WriteLine (f_state.ON_DRAG_UP);
			}
			if (s == "ON_DRAG_RIGHT") {
				actualStateP = f_state.ON_DRAG_RIGHT;
				Console.WriteLine (f_state.ON_DRAG_RIGHT);
			}
			if (s == "ON_DRAG_LEFT") {
				actualStateP = f_state.ON_DRAG_LEFT;
				Console.WriteLine (f_state.ON_DRAG_LEFT);
			}
			// Arrête l'animation avec la Release
			if (s == "ON_RELEASE_DOWN") {
				actualStateP = f_state.ON_RELEASE_DOWN;
				Console.WriteLine (f_state.ON_RELEASE_DOWN);
			}
			if (s == "ON_RELEASE_UP") {
				actualStateP = f_state.ON_RELEASE_UP;
				Console.WriteLine (f_state.ON_RELEASE_UP);
			}
			if (s == "ON_RELEASE_RIGHT") {
				actualStateP = f_state.ON_RELEASE_RIGHT;
				Console.WriteLine (f_state.ON_RELEASE_RIGHT);
			}
			if (s == "ON_RELEASE_LEFT") {
				actualStateP = f_state.ON_RELEASE_LEFT;
				Console.WriteLine (f_state.ON_RELEASE_LEFT);
			}
		}
		public static void MovePlayer(Vector2 pos)
		{
			//Permet de déterminer la position du Character
			activePos = new Vector2(pos.X,pos.Y - 20);
		}
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}

		//Link image to the Player
		private void linkPlayer(){

			if (actualStateP == previousStateP) {
				return;
			}

			switch (actualStateP) {
			case f_state.ON_DRAG_DOWN:
				LinkSprite ("Character_Front", 1, 4, 4, 250);
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_DRAG_UP:
				LinkSprite ("Character_Back", 1, 4, 4, 250);
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_DRAG_RIGHT:
				LinkSprite ("Character_Right", 1, 4, 4, 250);
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_DRAG_LEFT:
				LinkSprite ("Character_Left", 1, 4, 4, 250);
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_RELEASE_DOWN:
				LinkSprite ("Character_Front_Static");
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_RELEASE_UP:
				LinkSprite ("Character_Back_Static");
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_RELEASE_RIGHT:
				LinkSprite ("Character_Right_Static");
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_RELEASE_LEFT:
				LinkSprite ("Character_Left_Static");
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;
			}
		}
	}
}
