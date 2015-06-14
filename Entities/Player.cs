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
			ON_DRAG,
			ON_RELEASE
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
			if (AdvancedMouse.OnClic ())
				sprite.color = Color.Red;
			else if (AdvancedMouse.OnDrag ())
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
			// Lance l'animation si l'on Drag (from GameCase)
			if (s == "ON_DRAG") {
				actualStateP = f_state.ON_DRAG;
				//Console.WriteLine (f_state.ON_DRAG);
			}
			// Arrête l'animation avec le Drag (from GameCase)
			if (s == "ON_RELEASE") {
				actualStateP = f_state.ON_RELEASE;
				//Console.WriteLine (f_state.ON_RELEASE);
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
			case f_state.ON_DRAG:
				LinkSprite ("Character_Front", 1, 4, 4, 250);
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;

			case f_state.ON_RELEASE:
				LinkSprite ("Character_Front_Static");
				sprite.depth = 0f;
				Console.WriteLine ("Working");
				previousStateP = actualStateP;
				break;
			}
		}
	}
}
