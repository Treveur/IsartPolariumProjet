using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace IsartPolarium
{
	public class MainMenu: AScene
	{
		//Button
		Button playBtn;
		Button closeGameBtn;
		//GraphicsDeviceManager graphics;

		//Game1
		Game1 game;

		public MainMenu (SceneManager _SM) : base(_SM)
		{
		}

		public override void Initialize()
		{
			playBtn = new Button (this, "playBtn");
			playBtn.Position = new Vector2 (sceneManager.graphics.PreferredBackBufferWidth/2, (sceneManager.graphics.PreferredBackBufferHeight/2) - 55);
			closeGameBtn = new Button (this, "quitBtn");
			closeGameBtn.Position = new Vector2 (sceneManager.graphics.PreferredBackBufferWidth/2, (sceneManager.graphics.PreferredBackBufferHeight/2) +55);

			//Console.WriteLine ("Width : " + screenSize.Width + "Height :"+screenSize.Height);
			//Console.WriteLine ("Width : "+ sceneManager.graphics.PreferredBackBufferWidth +" Height : " + sceneManager.graphics.PreferredBackBufferHeight);

			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{
			//Chargement du niveau 1
			sceneManager.lvl1 = new Level1 (sceneManager);
			sceneManager.AddScene (sceneManager.lvl1, 4);
			sceneManager.lvl1.sceneState = SceneState.SLEEP;

			AddEntity (playBtn);
			AddEntity (closeGameBtn);


			base.LoadContent ();
		}

		/// <summary>
		/// We Update our scene.
		/// If it's the first time we enter in this function, we add our player and a grid.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Update (GameTime gameTime)
		{


			if (playBtn.changed && AdvancedMouse.OnRelease ()) {
				Console.WriteLine ("Youpi");

				sceneManager.mMenu.sceneState = SceneState.SLEEP;
				sceneManager.lvl1.sceneState = SceneState.UPDATEDRAW;
				sceneManager.igInterface.sceneState = SceneState.UPDATEDRAW;

			} else if (closeGameBtn.changed && AdvancedMouse.OnRelease ()) {
				//Non fonctionnel
				//game.Quit();
			}

			/*if (ULvl1.changed || DLvl1.changed) {
				ChangeSceneState (ULvl1._state, DLvl1._state, sceneManager.GetScene(1));
				ULvl1.changed = false;
				DLvl1.changed = false;
			}

			if (ULvl2.changed || DLvl2.changed) {
				sceneManager.GetScene(0).sceneState = ChangeSceneState (ULvl2._state, DLvl2._state);
				ULvl2.changed = false;
				DLvl2.changed = false;
			}*/

			base.Update (gameTime);
		}

		SceneState ChangeSceneState(bool upd, bool dra)
		{
			if (upd && dra)
				return SceneState.UPDATEDRAW;
			else if (upd == false && dra)
				return SceneState.DRAW;
			else if (upd && dra == false)
				return SceneState.UPDATE;
			else if (upd == false && dra == false)
				return SceneState.SLEEP;
			return SceneState.SLEEP;
		}

		void ChangeSceneState(bool upd, bool dra, AScene sceneToChange)
		{
			if (upd && dra)
				sceneToChange.sceneState = SceneState.UPDATEDRAW;
			else if (upd == false && dra)
				sceneToChange.sceneState = SceneState.DRAW;
			else if (upd && dra == false)
				sceneToChange.sceneState = SceneState.UPDATE;
			else if (upd == false && dra == false)
				sceneToChange.sceneState = SceneState.SLEEP;
		}

		/// <summary>
		/// We draw all the entity of our scene
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public override void Draw(GameTime gameTime)
		{
			base.Draw (gameTime);
		}
	}
}

