using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
namespace IsartPolarium
{
	public class MainMenu: AScene
	{

		Button playBtn;
		Button closeGameBtn;
		public GraphicsDeviceManager graphics;

		public MainMenu (SceneManager _SM) : base(_SM)
		{
		}

		public override void Initialize()
		{
			playBtn = new Button (this, "play_btn");
			playBtn.Position = new Vector2 (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2, (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2) - 100);
			closeGameBtn = new Button (this, "quit_btn");
			closeGameBtn.Position = new Vector2 (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width/2, (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height/2) + 100);

			Console.WriteLine ("Width : " + GraphicsDeviceManager.GraphicsDevice.DisplayMode.Width + "Height :"+ GraphicsDeviceManager.GraphicsDevice.DisplayMode.Height);

			base.Initialize ();
		}

		/// <summary>
		/// We load the content of our scene
		/// </summary>
		public override void LoadContent()
		{
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

